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
        int id;
        ListaEmpresarios empresarios = new ListaEmpresarios();
        ListaAdministradores administradores = new ListaAdministradores();

        /// <summary>
        /// SetUp de las instancias de clases y distintos elementos necesarios
        /// para llevar asi acabo los tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            residuo = new Residuo("metal", 100, "kg", 250, "$");
            
            int invitacion = InvitationGenerator.Generate();
            ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            empresa = new Empresa("MercadoPrivado", ubicacion, "099679938");
            empresa.residuos.AddResiduo(residuo);
            Usuario = new Empresario(invitacion, empresa);
            id = 12345678;
            Usuario.id = id;
            empresarios.AddEmpresario(Usuario);

            handler = new InvitarHandler(null);
            int invitacion2 = InvitationGenerator.Generate();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.id = id;
            administradores.AddAdministrador(Usuario2);
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

            IHandler result = handler.Handle(message, id, out response);

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

            IHandler result = handler.Handle(message, Usuario2.id, out response);
            
            message = "WCDONALDS";
            handler.Handle(message, Usuario2.id, out response);
            message = ubicacion.direccion;
            handler.Handle(message, Usuario2.id, out response);
            message = "099328938";
            handler.Handle(message, Usuario2.id, out response);
            message = "ok";
            handler.Handle(message, Usuario2.id, out response);


            Assert.That(response, Is.EqualTo($"Se ha creado el empresario y esta es la invitacion que debe usar para acceder a su status: {handler.invitacion}"));
        }
    }
}