using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Test
    /// </summary>
    public class InvitarHandlerTests
    {
        Residuo Residuo;
        InvitarHandler Handler;
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
            
            InvitationGenerator generator = new InvitationGenerator();
            string invitacion = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            Usuario = new Empresario(invitacion, Empresa);
            Id = 12345678;
            Usuario.Id = Id;
            Empresarios.AddEmpresario(Usuario);

            Handler = new InvitarHandler(null);
            string invitacion2 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.Id = Id;
            Administradores.AddAdministrador(Usuario2);
        }

        /// <summary>
        /// Si el que trata de usar el comando /invitar es un administrador 
        /// (En este caso deberia pasar al menos el primer Handle).
        /// </summary>
        [Test]
        public void InvitarAdministradorHandleTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Id, out response);

            Assert.That(response, Is.EqualTo("¿Cual es el nombre de la empresa que quiere invitar?"));
        }
        /// <summary>
        /// Si el que trata de usar el comando /invitar no es un administrador
        /// (En este caso no deberia pasar los handles y por eso devuelva)
        /// </summary>
        [Test]
        public void InvitarUsuarioHandleTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, 38291203, out response);

            Assert.That(response, Is.EqualTo("Usted no es un administrador, no puede usar el codigo..."));
        }
        /// <summary>
        /// Aqui comprobamos que funcione el handler si se pasa por todo el
        /// proceso de la forma prevista.
        /// </summary>
        [Test]
        public void WorkingInvitarHandlerTest()
        {
            InvitationGenerator generator = new InvitationGenerator();
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Usuario2.Id, out response);
            
            Message = "WCDONALDS";
            Handler.Handle(Message, Usuario2.Id, out response);
            Message = Ubicacion.Direccion;
            Handler.Handle(Message, Usuario2.Id, out response);
            Message = "099328938";
            Handler.Handle(Message, Usuario2.Id, out response);
            Message = "ok";
            Handler.Handle(Message, Usuario2.Id, out response);


            Assert.That(response, Is.EqualTo($"Se ha creado el empresario y esta es la invitacion que debe usar para acceder a su status: {Handler.Invitacion}"));
            Assert.That(ListaInvitaciones.GetInstance(generator).Invitaciones.Contains(Handler.Invitacion));
            Assert.That(Handler.Empresario.Empresa, Is.EqualTo(Handler.EmpresaData));
            Assert.That(Handler.Empresario.Invitacion, Is.EqualTo(Handler.Invitacion));
            Assert.That(ListaEmpresarios.GetInstance().Empresarios.Contains(Handler.Empresario));
            Assert.That(ListaEmpresas.GetInstance().Empresas.Contains(Handler.EmpresaData));
            Assert.That(Handler.EmpresaData.Empresario, Is.EqualTo(Handler.Empresario));
        }
    }
}