using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Clase de test que se encarga de probar las distintas funciones del PublicarHandler.
    /// Los test individualmente utilizando "run test" funcionan correctamente, pero al intentar usar "run all tests" no detecta ninguno.
    /// </summary>
    public class CambiarDatosHandlerTests
    {
        Residuo Residuo;
        CambiarDatosHandler Handler;
        string Message;
        Empresa Empresa;
        Empresario Usuario;
        Administrador Usuario2;
        Ubicacion Ubicacion;
        int Id;
        ListaEmpresarios Empresarios = ListaEmpresarios.GetInstance();
        ListaAdministradores Administradores = ListaAdministradores.GetInstance();
        ListaUsuarios Usuarios = ListaUsuarios.GetInstance();
        Mercado Mercado = Mercado.GetInstance();

        /// <summary>
        /// el set up de los test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Residuo = new Residuo("metal", 100, "kg", 250, "$");
            
            string invitacion = InvitationGenerator.Generate();
            Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            Usuario = new Empresario(invitacion, Empresa);
            Id = 12345678;
            Usuario.Id = Id;
            Empresarios.AddEmpresario(Usuario);

            Handler = new CambiarDatosHandler(null);
            string invitacion2 = InvitationGenerator.Generate();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.Id = Id;
            Administradores.AddAdministrador(Usuario2);
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /publicar.
        /// </summary>
        [Test]
        public void CambiarDatosCanHandleTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Id, out response);

            Assert.That(response, Is.EqualTo("Ingrese el nombre de su empresa."));
        }

        /// <summary>
        /// Este test se encarga de comprobar que el comando /publicar no funciona con un usuario que no es un empresario.
        /// </summary>
        [Test]
        public void CambiarDatosCantHandleTest()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, emprendedor.Id, out response);

            Assert.That(response, Is.EqualTo("Usted no es un empresario, no puede usar el codigo..."));
        }

        /// <summary>
        /// Este test se encarga de comprobar la funcionalidad de crear una publicación.
        /// </summary>
        [Test]
        public void WorkingCambiarDatosHandlerTest()
        {
            Empresario empresario = new Empresario("323234", Empresa);
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo("Ingrese el nombre de su empresa."));

            Message = "TestNombre";
            Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo("Ahora dime la ubicacion de dicha empresa"));

            Message = "Estados Unidos";
            Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo("Por ultimo dime el contacto de la empresa"));

            Message = "099547123";
            Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo("Se han actualizado sus datos..."));


            Assert.That(empresario.Empresa.Nombre, Is.EqualTo("TestNombre"));
            Assert.That(empresario.Empresa.Ubicacion.Direccion, Is.EqualTo("Estados Unidos"));
            Assert.That(empresario.Empresa.Contacto, Is.EqualTo("099547123"));
        }
    }
}