using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    public class HandlerTests
    {
        Residuo residuo;
        PublicarHandler handler;
        InvitarHandler handler2;
        string message;
        Empresa empresa;
        Empresario Usuario;
        Administrador Usuario2;
        Ubicacion ubicacion;
        int id;

        [SetUp]
        public void Setup()
        {
            residuo = new Residuo("metal", 100, "kg", 250, "$");
            handler = new PublicarHandler(null);
            
            int invitacion = InvitationGenerator.Generate();
            ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            empresa = new Empresa("MercadoPrivado", ubicacion, 099679938);
            empresa.residuos.AddResiduo(residuo);
            Usuario = new Empresario(invitacion, empresa);
            id = 12345678;
            Usuario.id = id;
            ListaEmpresarios.AddEmpresario(Usuario);

            handler2 = new InvitarHandler(null);
            int invitacion2 = InvitationGenerator.Generate();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.id = id;
            ListaAdministradores.AddAdministrador(Usuario2);
        }

        [Test]
        public void PublicarCanHandle()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);

            Assert.That(response, Is.EqualTo("Ingrese el numero de la palabra clave que quiera agregar:\n0. Barato.\n1. Envio Gratis.\n2. Usado.\n3. Nuevo.\n"));
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
            Assert.That(response, Is.EqualTo("Ingrese el numero de la palabra clave que quiera agregar:\n0. Barato.\n1. Envio Gratis.\n2. Usado.\n3. Nuevo.\n"));

            message = "1";
            handler.Handle(message, emprendedor.id, out response);
            Assert.That(response, Is.EqualTo("Porfavor ingrese la habilitacion para los residuos."));

            message = "Necesitara un camion o vehiculo";
            handler.Handle(message, emprendedor.id, out response);
            Assert.That(response, Is.EqualTo("Porfavor responda si o no, ¿Estos residuos que se generaron se generan de forma constante? Si fue puntual responda no."));

            message = "si";
            handler.Handle(message, emprendedor.id, out response);
            Assert.That(response, Is.EqualTo("Porfavor ingrese la direccion de los residuos."));

            message = ubicacion.direccion;
            handler.Handle(message, emprendedor.id, out response);
            Assert.That(response, Is.EqualTo("Ahora dime sobre cual de tus residuos quieres publicar"));

            message = residuo.tipo;
            handler.Handle(message, id, out response);
            Assert.That(response, Is.EqualTo($"Se ha publicado la oferta de {residuo.tipo} de la empresa {empresa.nombre}. En la ubicacion {ubicacion.direccion}"));
        }

        [Test]
        public void InvitarAdministradorHandle()
        {
            message = handler2.Keywords[0];
            string response;

            IHandler result = handler2.Handle(message, id, out response);

            Assert.That(response, Is.EqualTo("¿Cual es el nombre de la empresa que quiere invitar?"));
        }

        [Test]
        public void InvitarUsuarioHandle()
        {
            message = handler2.Keywords[0];
            string response;

            IHandler result = handler2.Handle(message, 38291203, out response);

            Assert.That(response, Is.EqualTo("Usted no es un administrador, no puede usar el codigo..."));
        }

        [Test]
        public void WorkingInvitarHandler()
        {
            message = handler2.Keywords[0];
            string response;

            IHandler result = handler2.Handle(message, Usuario2.id, out response);
            
            message = "WCDONALDS";
            handler2.Handle(message, Usuario2.id, out response);
            message = ubicacion.direccion;
            handler2.Handle(message, Usuario2.id, out response);
            message = "099328938";
            handler2.Handle(message, Usuario2.id, out response);
            message = "ok";
            handler2.Handle(message, Usuario2.id, out response);


            Assert.That(response, Is.EqualTo($"Se ha creado el empresario y esta es la invitacion que debe usar para acceder a su status: {handler2.invitacion}"));
        }
    }
}