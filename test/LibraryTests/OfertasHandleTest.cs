using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Clase de test que se encarga de probar las distintas funciones del OfertasHandler.
    /// Los test individualmente utilizando "run test" funcionan correctamente, pero al intentar usar "run all tests" no detecta ninguno.
    /// </summary>
    public class OfertasHandlerTests
    {
        Residuo residuo;
        OfertasHandler handler;
        string message;
        Empresa empresa;
        Empresario UsuarioEmpresario;
        Emprendedor UsuarioEmprendedor;
        Ubicacion ubicacion;
        int id;
        int contador;
        Publicacion publicacion;
        Ubicacion ubicacion2;

        int id2;
        ListaEmpresarios empresarios = new ListaEmpresarios();
        ListaAdministradores administradores = ListaAdministradores.GetInstance();
        ListaUsuarios usuarios = new ListaUsuarios();
        Mercado mercado = new Mercado();
        
        /// <summary>
        /// El Setup de los test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            residuo = new Residuo("metal", 100, "kg", 250, "$");
            handler = new OfertasHandler(null);
            int invitacion = InvitationGenerator.Generate();
            ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            ubicacion2 = new Ubicacion("Av. Italia 3479");
            empresa = new Empresa("MercadoPrivado", ubicacion, "099679938");
            empresa.residuos.AddResiduo(residuo);
            UsuarioEmpresario = new Empresario(invitacion, empresa);
            UsuarioEmprendedor = new Emprendedor(id);
            id = 12345678;
            id2 = 87654321;
            UsuarioEmprendedor.id = id;
            UsuarioEmpresario.id = id2;
            empresarios.AddEmpresario(UsuarioEmpresario);
            usuarios.AddUsuario(UsuarioEmprendedor);
            contador = 0;
            publicacion = new Publicacion(residuo, ubicacion2, empresa, "tener un camion", true);
            publicacion.AgregarPalabraClave("Envio Gratis");
            mercado.AddMercado(publicacion);
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /ofertas.
        /// </summary>
        [Test]
        public void OfertasCanHandleTest()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);

            Assert.That(response, Is.EqualTo("¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no"));
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /ofertas con un usuario que no es un emprendedor.
        /// </summary>
        [Test]
        public void OfertasEmpresarioCanHandleTest()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, UsuarioEmpresario.id, out response);

            Assert.That(response, Is.EqualTo("¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no"));
        }
        /// <summary>
        /// Este test se encarga de comprobar la funcionalidad de buscar una publicación con palabra clave.
        /// </summary>
        [Test]
        public void WithKeywordOfertasHandlerTest()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);
            
            Assert.That(response, Is.EqualTo("¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no"));
            message = "si";
            handler.Handle(message, UsuarioEmprendedor.id, out response);
            Assert.That(response, Is.EqualTo("Ingrese el numero de la palabra clave que buscar:\n0. Barato.\n1. Envio Gratis.\n2. Usado.\n3. Nuevo.\n"));
            message = "1";
            handler.Handle(message, UsuarioEmprendedor.id, out response);
            Assert.That(response, Is.EqualTo("¿Cual es tu direccion? (Asi encontraremos publicaciones por proximidad)"));
            message = ubicacion2.direccion;
            handler.Handle(message, UsuarioEmprendedor.id, out response);
            Assert.That(response, Is.EqualTo("Ahora dime que tipo de residuos estas buscando?"));
            message = residuo.tipo;
            handler.Handle(message, UsuarioEmprendedor.id, out response);
            Assert.That(response, Is.EqualTo($"Ingrese el número de la publicación para ver más información de la misma:\n0. {publicacion.empresa.nombre} ofrece: {publicacion.residuo.cantidad} {publicacion.residuo.unidad} de {publicacion.residuo.tipo} en {publicacion.ubicacion.direccion}. Ademas la habilitacion para conseguir estos residuos es: {publicacion.habilitacion}\n"));
        }
        /// <summary>
        /// Este test se encarga de comprobar la funcionalidad de buscar una publicación sin usar una palabra clave.
        /// </summary>
        [Test]
        public void WithoutKeywordOfertasHandlerTest()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);
            
            Assert.That(response, Is.EqualTo("¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no"));
            message = "no";
            handler.Handle(message, UsuarioEmprendedor.id, out response);
            Assert.That(response, Is.EqualTo("¿Cual es tu direccion? (Asi encontraremos publicaciones por proximidad)"));
            message = ubicacion2.direccion;
            handler.Handle(message, UsuarioEmprendedor.id, out response);  
            Assert.That(response, Is.EqualTo("Ahora dime que tipo de residuos estas buscando?"));
            message = residuo.tipo;
            handler.Handle(message, UsuarioEmprendedor.id, out response);
            Assert.That(response, Is.EqualTo($"Ingrese el número de la publicación para ver más información de la misma:\n0. {publicacion.empresa.nombre} ofrece: {publicacion.residuo.cantidad} {publicacion.residuo.unidad} de {publicacion.residuo.tipo} en {publicacion.ubicacion.direccion}. Ademas la habilitacion para conseguir estos residuos es: {publicacion.habilitacion}\n"));
        }
    
    }

    









}
