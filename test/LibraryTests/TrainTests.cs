using NUnit.Framework;
using ClassLibrary;
using Telegram.Bot.Types;

namespace Tests
{
    public class HandlerTests
    {
        PublicarHandler handler;
        string message;
        Empresa empresa;
        Empresario Usuario;
        Ubicacion ubicacion;
        int id;

        [SetUp]
        public void Setup()
        {
            handler = new PublicarHandler(null);
            int invitacion = InvitationGenerator.Generate();
            ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            empresa = new Empresa("MercadoPrivado", ubicacion, 099679938);
            Usuario = new Empresario(invitacion, empresa);
            id = 12345678;
            Usuario.id = id;
            ListaEmpresarios.AddEmpresario(Usuario);
        }

        [Test]
        public void PublicarHandle()
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
    }
}