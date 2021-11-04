using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Test
    /// </summary>
    public class InvitarHandlerTests
    {
        Residuo residuo;
        InvitarHandler handler;
        string message;
        Empresa empresa;
        Empresario Usuario;
        Administrador Usuario2;
        Ubicacion ubicacion;
        ListaResiduos residuos;
        int id;
        int id2;

        /// <summary>
        /// SetUp de las instancias de clases y distintos elementos necesarios
        /// para llevar asi acabo los tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {            
            ListaResiduos residuos = new ListaResiduos();
            int invitacion = InvitationGenerator.Generate();
            ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            empresa = new Empresa("MercadoPrivado", ubicacion, 099679938);
            empresa.residuos = residuos;
            empresa.residuos.AddResiduo("metal", 100, "kg", 250, "$");
            id = 12345678;
            Empresario Usuario = ListaEmpresarios.AddEmpresario(invitacion, empresa, id);
            id2 = 3455653;
            Usuario.id = id;

            handler = new InvitarHandler(null);
            int invitacion2 = InvitationGenerator.Generate();
            Administrador Usuario2 = ListaAdministradores.AddAdministrador(invitacion2, id2);
        }

        /// <summary>
        /// Si el que trata de usar el comando /invitar es un administrador 
        /// (En este caso deberia pasar al menos el primer Handle).
        /// </summary>
        [Test]
        public void InvitarAdministradorHandleTest()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, Usuario2.id, out response);

            Assert.That(response, Is.EqualTo("¿Cual es el nombre de la empresa que quiere invitar?"));
        }
        /// <summary>
        /// Si el que trata de usar el comando /invitar no es un administrador
        /// (En este caso no deberia pasar los handles y por eso devuelva)
        /// </summary>
        [Test]
        public void InvitarUsuarioHandleTest()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, 38291203, out response);

            Assert.That(response, Is.EqualTo("Usted no es un administrador, no puede usar el codigo..."));
        }
        /// <summary>
        /// Aqui comprobamos que funcione el handler si se pasa por todo el
        /// proceso de la forma prevista.
        /// </summary>
        [Test]
        public void WorkingInvitarHandlerTest()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id2, out response);
            
            message = "WCDONALDS";
            handler.Handle(message, id, out response);
            message = ubicacion.direccion;
            handler.Handle(message, id, out response);
            message = "099328938";
            handler.Handle(message, id, out response);
            message = "ok";
            handler.Handle(message, id, out response);


            Assert.That(response, Is.EqualTo($"Se ha creado el empresario y esta es la invitacion que debe usar para acceder a su status: {handler.invitacion}"));
        }
    }
}