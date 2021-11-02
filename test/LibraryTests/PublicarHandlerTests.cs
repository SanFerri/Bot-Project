using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    public class HandlerTests
    {
        Residuo residuo;
        PublicarHandler handler;
        string message;
        Empresa empresa;
        Empresario Usuario;
        Ubicacion ubicacion;
        int id;

        [SetUp]
        public void Setup()
        {
            residuo = new Residuo("metal", 100);
            handler = new PublicarHandler(null);
            int invitacion = InvitationGenerator.Generate();
            ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            empresa = new Empresa("MercadoPrivado", ubicacion, 099679938);
            empresa.residuos.AddResiduo(residuo);
            Usuario = new Empresario(invitacion, empresa);
            id = 12345678;
            Usuario.id = id;
            ListaEmpresarios.AddEmpresario(Usuario);
        }

        [Test]
        public void PublicarCanHandle()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);

            Assert.That(response, Is.EqualTo("Porfavor ingrese la direccion de los residuos."));
        }

        [Test]
        public void PublicarCantHandle()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, emprendedor.id, out response);

            Assert.That(response, Is.EqualTo("Usted no es un empresario, no puede usar el codigo..."));
        }

        [Test]
        public void WorkingPublicarHandler()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);
            
            message = ubicacion.direccion;
            handler.Handle(message, emprendedor.id, out response);
            message = residuo.tipo;
            handler.Handle(message, id, out response);


            Assert.That(response, Is.EqualTo($"Se ha publicado la oferta de {residuo.tipo} de la empresa {empresa.nombre}. En la ubicacion {ubicacion.direccion}"));
        }
    }
}