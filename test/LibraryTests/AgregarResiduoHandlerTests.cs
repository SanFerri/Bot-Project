using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Test
    /// </summary>
    public class AgregarResiduoHandlerTests
    {
        Residuo residuo;
        AgregarResiduoHandler handler;
        string message;
        Empresa empresa;
        Empresario Usuario;
        Administrador Usuario2;
        Ubicacion ubicacion;
        int id;
        ListaEmpresarios empresarios = ListaEmpresarios.GetInstance();
        ListaAdministradores administradores = ListaAdministradores.GetInstance();

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

            handler = new AgregarResiduoHandler(null);
            int invitacion2 = InvitationGenerator.Generate();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.id = id;
            administradores.AddAdministrador(Usuario2);
        }

        /// <summary>
        /// Si el que trata de usar el comando /agregarresiduo es un empresario 
        /// (En este caso deberia pasar al menos el primer Handle).
        /// </summary>
        [Test]
        public void AgregarResiduoHandleTest()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);

            Assert.That(response, Is.EqualTo("Ingrese el tipo del residuo que quiere agregar."));
        }
        /// <summary>
        /// Si el que trata de usar el comando /agregarresiduos no es un empresario
        /// (En este caso no deberia pasar los handles y por eso devuelva)
        /// </summary>
        [Test]
        public void AgregarResiduoCantHandleTest()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, 38291203, out response);

            Assert.That(response, Is.EqualTo("Usted no es un empresario, no puede acceder a este comando"));
        }
        /// <summary>
        /// Aqui comprobamos que funcione el handler si se pasa por todo el
        /// proceso de la forma prevista.
        /// </summary>
        [Test]
        public void WorkingAgregarResiduoHandlerTest()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, Usuario2.id, out response);
            
            message = residuo.tipo;
            handler.Handle(message, Usuario2.id, out response);
            message = $"{residuo.cantidad}";
            handler.Handle(message, Usuario2.id, out response);
            message = residuo.unidad;
            handler.Handle(message, Usuario2.id, out response);
            message = $"{residuo.cost}";
            handler.Handle(message, Usuario2.id, out response);
            message = residuo.moneda;
            handler.Handle(message, Usuario2.id, out response);


            Assert.That(response, Is.EqualTo($"Se ha agregado el residuo {residuo.tipo}"));
        }
    }
}