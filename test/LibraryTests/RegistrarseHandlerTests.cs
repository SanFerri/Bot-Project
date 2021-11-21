using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Clase de test que se encarga de probar las distintas funciones del OfertasHandler.
    /// Los test individualmente utilizando "run test" funcionan correctamente, pero al intentar usar "run all tests" no detecta ninguno.
    /// </summary>
    public class RegistrarseHandlerTests
    {
        Residuo Residuo;
        RegistrarseHandler Handler;
        string Message;
        Empresa Empresa;
        Empresario UsuarioEmpresario;
        Emprendedor UsuarioEmprendedor;
        Ubicacion Ubicacion;
        int Id;
        int Contador;
        Publicacion Publicacion;
        Ubicacion Ubicacion2;

        int Id2;
        ListaEmpresarios Empresarios = ListaEmpresarios.GetInstance();
        ListaAdministradores Administradores = ListaAdministradores.GetInstance();
        ListaUsuarios Usuarios = ListaUsuarios.GetInstance();
        Mercado Mercado = Mercado.GetInstance();
        
        /// <summary>
        /// El Setup de los test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Residuo = new Residuo("metal", 100, "kg", 250, "$");
            Handler = new RegistrarseHandler(null);
            int Invitacion = InvitationGenerator.Generate();
            Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Ubicacion2 = new Ubicacion("Av. Italia 3479");
            Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            UsuarioEmpresario = new Empresario(Invitacion, Empresa);
            UsuarioEmprendedor = new Emprendedor(Id);
            Id = 12345678;
            Id2 = 87654321;
            UsuarioEmprendedor.Id = Id;
            UsuarioEmpresario.Id = Id2;
            Empresarios.AddEmpresario(UsuarioEmpresario);
            Usuarios.AddUsuario(UsuarioEmprendedor);
            Contador = 0;
            Publicacion = new Publicacion(Residuo, Ubicacion2, Empresa, "tener un camion", true);
            Publicacion.AgregarPalabraClave("Envio Gratis");
            Mercado.AddMercado(Publicacion);
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /ofertas.
        /// </summary>
        [Test]
        public void RegitrarseCanHandleTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, UsuarioEmpresario.Id, out response);

            Assert.That(response, Is.EqualTo("Usted ya esta registrado como un empresario"));
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /ofertas con un usuario que no es un emprendedor.
        /// </summary>
        [Test]
        public void RegistrarseCantHandleTest()
        {
            Message = "/registroo";
            string response;

            IHandler result = Handler.Handle(Message, UsuarioEmpresario.Id, out response);

            Assert.That(response, Is.EqualTo(string.Empty));
        }
        /// <summary>
        /// Este test se encarga de comprobar la funcionalidad de buscar una publicación con palabra clave.
        /// </summary>
        [Test]
        public void WithKeywordOfertasHandlerTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            
            Assert.That(response, Is.EqualTo("Esta registrado como un emprendedor, ingrese una invitación si es parte de una empresa, en caso de no serlo responda con un no"));
            Message = "si";
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("Ingrese el numero de la palabra clave que buscar:\n0. Barato.\n1. Envio Gratis.\n2. Usado.\n3. Nuevo.\n"));
            Message = "1";
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("¿Cual es tu direccion? (Asi encontraremos publicaciones por proximidad)"));
            Message = Ubicacion2.Direccion;
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("Ahora dime que tipo de residuos estas buscando?"));
            Message = Residuo.Tipo;
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo($"Ingrese el número de la publicación para ver más información de la misma:\n0. {Publicacion.Empresa.Nombre} ofrece: {Publicacion.Residuo.Cantidad} {Publicacion.Residuo.Unidad} de {Publicacion.Residuo.Tipo} en {Publicacion.Ubicacion.Direccion}. Ademas la habilitacion para conseguir estos residuos es: {Publicacion.Habilitacion}\n"));
        }
        /// <summary>
        /// Este test se encarga de comprobar la funcionalidad de buscar una publicación sin usar una palabra clave.
        /// </summary>
        [Test]
        public void WithoutKeywordOfertasHandlerTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Id, out response);
            
            Assert.That(response, Is.EqualTo("¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no"));
            Message = "no";
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("¿Cual es tu direccion? (Asi encontraremos publicaciones por proximidad)"));
            Message = Ubicacion2.Direccion;
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);  
            Assert.That(response, Is.EqualTo("Ahora dime que tipo de residuos estas buscando?"));
            Message = Residuo.Tipo;
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo($"Ingrese el número de la publicación para ver más información de la misma:\n0. {Publicacion.Empresa.Nombre} ofrece: {Publicacion.Residuo.Cantidad} {Publicacion.Residuo.Unidad} de {Publicacion.Residuo.Tipo} en {Publicacion.Ubicacion.Direccion}. Ademas la habilitacion para conseguir estos residuos es: {Publicacion.Habilitacion}\n"));
        }
    }
}