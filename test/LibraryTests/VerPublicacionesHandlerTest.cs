using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Clase de test que se encarga de probar las distintas funciones del PublicarHandler.
    /// Los test individualmente utilizando "run test" funcionan correctamente, pero al intentar usar "run all tests" no detecta ninguno.
    /// </summary>
    public class VerPublicacionesHandlerTest
    {
        Residuo Residuo;
        VerPublicacionesHandler Handler;
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
            Empresa.Empresario = Usuario;

            Handler = new VerPublicacionesHandler(null);
            string invitacion2 = InvitationGenerator.Generate();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.Id = Id;
            Administradores.AddAdministrador(Usuario2);
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /publicar.
        /// </summary>
        [Test]
        public void VerPublicacionesCanHandleTest()
        {
            Publicacion Publicacion = new Publicacion(Residuo, Ubicacion, Empresa, "Permisos", false);
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Usuario.Id, out response);

            Assert.That(response, Is.EqualTo($"Estas son tus publicaciones:\n0. Ofrece: 100 kg de metal en Av. 8 de Octubre 2738. Ademas la habilitacion para conseguir estos residuos es: Permisos Fecha: {Publicacion.Fecha}\n¿Quieres eliminar alguna publicacion? o indicar que esta entregada? Responda elIminar, entregado, o no"));
        }

        /// <summary>
        /// Este test se encarga de comprobar que el comando /publicar no funciona con un usuario que no es un empresario.
        /// </summary>
        [Test]
        public void VerPublicacionesCantHandleTest()
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
        public void WorkingEliminadoVerPublicacionesHandlerTest()
        {
            Publicacion Publicacion = new Publicacion(Residuo, Ubicacion, Empresa, "Permisos", false);
            Empresario empresario = new Empresario("323234", Empresa);
            Message = Handler.Keywords[0];
            string response;

            Assert.That(empresario.Empresa.Publicaciones.Publicaciones.Contains(Publicacion));

            IHandler result = Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo($"Estas son tus publicaciones:\n0. Ofrece: 100 kg de metal en Av. 8 de Octubre 2738. Ademas la habilitacion para conseguir estos residuos es: Permisos Fecha: {Publicacion.Fecha}\n¿Quieres eliminar alguna publicacion? o indicar que esta entregada? Responda eliminar, entregado, o no"));

            Message = "eliminar";
            Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo("Ingrese el numero de la publicacion que quiera eliminar."));

            Message = "0";
            Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo("Se ha eliminado la publicacion"));

            Assert.That(!empresario.Empresa.Publicaciones.Publicaciones.Contains(Publicacion));
            Assert.That(!Mercado.GetInstance().Ofertas.Contains(Publicacion));
        }

        /// <summary>
        /// Este test se encarga de comprobar la funcionalidad de crear una publicación.
        /// </summary>
        [Test]
        public void WorkingEntregadoVerPublicacionesHandlerTest()
        {
            Publicacion Publicacion = new Publicacion(Residuo, Ubicacion, Empresa, "Permisos", false);
            Empresario empresario = new Empresario("323234", Empresa);

            Emprendedor emprendedor = new Emprendedor(323);
            Message = Handler.Keywords[0];
            string response;

            Assert.That(empresario.Empresa.Publicaciones.Publicaciones.Contains(Publicacion));

            IHandler result = Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo($"Estas son tus publicaciones:\n0. Ofrece: 100 kg de metal en Av. 8 de Octubre 2738. Ademas la habilitacion para conseguir estos residuos es: Permisos Fecha: {Publicacion.Fecha}\n¿Quieres eliminar alguna publicacion? o indicar que esta entregada? Responda eliminar, entregado, o no"));

            Message = "entregado";
            Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo("Ingrese el numero de la publicacion que quiera indicar como entregada."));

            Message = "0";
            Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo("¿Cual es el id del usuario al que le ha entregado esta publicacion?"));

            Message = "323";
            Handler.Handle(Message, empresario.Id, out response);
            Assert.That(response, Is.EqualTo("¿Cual es el id del usuario al que le ha entregado esta publicacion?"));

            Assert.That(ListaEntregadas.GetInstance().ListaPublicaciones.Contains(Publicacion));
            Assert.That(!Mercado.GetInstance().Ofertas.Contains(Publicacion));
        }
    }
}