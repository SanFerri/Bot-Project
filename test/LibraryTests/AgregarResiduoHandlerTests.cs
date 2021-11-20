using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Test
    /// </summary>
    public class AgregarResiduoHandlerTests
    {
        Residuo Residuo;
        AgregarResiduoHandler Handler;
        string Message;
        Empresa Empresa;
        Empresario Usuario;
        Administrador Usuario2;
        Ubicacion Ubicacion;
        int Id;
        ListaEmpresarios Empresarios = ListaEmpresarios.GetInstance();
        ListaAdministradores Administradores = ListaAdministradores.GetInstance();

        /// <summary>
        /// SetUp de las instancias de clases y distintos elementos necesarios
        /// para llevar asi acabo los tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Residuo = new Residuo("metal", 100, "kg", 250, "$");
            
            int invitacion = InvitationGenerator.Generate();
            Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            Usuario = new Empresario(invitacion, Empresa);
            Id = 12345678;
            Usuario.Id = Id;
            Empresarios.AddEmpresario(Usuario);

            Handler = new AgregarResiduoHandler(null);
            int invitacion2 = InvitationGenerator.Generate();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.Id = Id;
            Administradores.AddAdministrador(Usuario2);
        }

        /// <summary>
        /// Si el que trata de usar el comando /agregarresiduo es un empresario 
        /// (En este caso deberia pasar al menos el primer Handle).
        /// </summary>
        [Test]
        public void AgregarResiduoHandleTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Id, out response);

            Assert.That(response, Is.EqualTo("Ingrese el tipo del residuo que quiere agregar."));
        }
        /// <summary>
        /// Si el que trata de usar el comando /agregarresiduos no es un empresario
        /// (En este caso no deberia pasar los handles y por eso devuelva)
        /// </summary>
        [Test]
        public void AgregarResiduoCantHandleTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, 38291203, out response);

            Assert.That(response, Is.EqualTo("Usted no es un empresario, no puede acceder a este comando"));
        }
        /// <summary>
        /// Aqui comprobamos que funcione el handler si se pasa por todo el
        /// proceso de la forma prevista.
        /// </summary>
        [Test]
        public void WorkingAgregarResiduoHandlerTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Usuario2.Id, out response);
            
            Message = Residuo.Tipo;
            Handler.Handle(Message, Usuario2.Id, out response);
            Message = $"{Residuo.Cantidad}";
            Handler.Handle(Message, Usuario2.Id, out response);
            Message = Residuo.Unidad;
            Handler.Handle(Message, Usuario2.Id, out response);
            Message = $"{Residuo.Cost}";
            Handler.Handle(Message, Usuario2.Id, out response);
            Message = Residuo.Moneda;
            Handler.Handle(Message, Usuario2.Id, out response);


            Assert.That(response, Is.EqualTo($"Se ha agregado el residuo {Residuo.Tipo}"));
        }
    }
}