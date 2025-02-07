using NUnit.Framework;
using ClassLibrary;
using Ucu.Poo.Locations.Client;

namespace Tests
{
    /// <summary>
    /// Clase de test que se encarga de probar las distintas funciones del VerEntregadosHandler.
    /// </summary>
    public class VerEntregadosHandlerTest
    {
        Residuo Residuo;
        VerEntregadosHandler Handler;
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

        Publicacion Publicacion;

        /// <summary>
        /// el set up de los test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Residuo = new Residuo("Metal", 100, "kg", 250, "$");

            InvitationGenerator generator = new InvitationGenerator();
            
            string invitacion = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            Usuario = new Empresario(invitacion, Empresa);
            Id = 12345678;
            Usuario.Id = Id;
            Empresarios.AddEmpresario(Usuario);

            Handler = new VerEntregadosHandler(null);
            string invitacion2 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.Id = Id;
            Administradores.AddAdministrador(Usuario2);
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /verentregados.
        /// </summary>
        [Test]
        public void VerEntregadosCanHandleTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Id, out response);

            Assert.That(response, Is.EqualTo("¿Publicaciones entregadas desde hace cuantos dias quieres ver?"));
        }

        /// <summary>
        /// Este test se encarga de comprobar que el comando /verentregados no funciona con un usuario que no es un empresario.
        /// </summary>
        [Test]
        public void VerEntregadosCantHandleTest()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, emprendedor.Id, out response);

            Assert.That(response, Is.EqualTo("Usted no es un empresario, no puede hacer uso de este comando"));
        }

        /// <summary>
        /// Este test se encarga de comprobar la funcionalidad de crear una publicación.
        /// </summary>
        [Test]
        public void WorkingVerEntregadosHandlerTest()
        {
            Empresa.Publicaciones.Publicaciones.Clear();
            ListaEntregadas.GetInstance().ListaPublicaciones.Clear();
            Mercado.GetInstance().Ofertas.Clear();

            Publicacion Publicacion2 = new Publicacion(Residuo, Ubicacion, Empresa, "Permisos", false);
            Publicacion2.Entregado = true;
            Publicacion2.IdEntregado = Id;
            Empresa.Publicaciones.AddPublicacion(Publicacion2);
            Empresario empresario = new Empresario("323234", Empresa);
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo("¿Publicaciones entregadas desde hace cuantos dias quieres ver?"));

            Message = "50";
            Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo($"Estas son tus publicaciones ya entregadas:\n0. Ofrece: 100 kg de Metal en Av. 8 de Octubre 2738. Ademas la habilitacion para conseguir estos residuos es: Permisos Fecha: {Publicacion.Fecha}\n"));

            Assert.That(ListaEntregadas.GetInstance().ListaPublicaciones.Contains(Publicacion));
        }
    }
}