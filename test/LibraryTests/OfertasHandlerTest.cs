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
        Residuo Residuo;
        OfertasHandler Handler;
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
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /ofertas.
        /// </summary>
        [Test]
        public void OfertasCanHandleTest()
        {
            Mercado.GetInstance().Ofertas.Clear();
            Residuo = new Residuo("Metal", 100, "kg", 250, "$");
            Handler = new OfertasHandler(null);

            InvitationGenerator generator = new InvitationGenerator();
            string Invitacion = ListaInvitaciones.GetInstance(generator).AddInvitacion();
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
            Contador = 0;
            Publicacion = new Publicacion(Residuo, Ubicacion2, Empresa, "tener un camion", true);
            Publicacion.AgregarPalabraClave("Envio Gratis");

            Mercado.GetInstance().Ofertas.Clear();
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Id, out response);

            Assert.That(response, Is.EqualTo("¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no"));
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /ofertas con un usuario que no es un emprendedor.
        /// </summary>
        [Test]
        public void OfertasEmpresarioCanHandleTest()
        {
            Mercado.GetInstance().Ofertas.Clear();
            Residuo = new Residuo("Metal", 100, "kg", 250, "$");
            Handler = new OfertasHandler(null);

            InvitationGenerator generator = new InvitationGenerator();
            string Invitacion = ListaInvitaciones.GetInstance(generator).AddInvitacion();
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
            Contador = 0;
            Publicacion = new Publicacion(Residuo, Ubicacion2, Empresa, "tener un camion", true);
            Publicacion.AgregarPalabraClave("Envio Gratis");

            Mercado.GetInstance().Ofertas.Clear();
            Message = Handler.Keywords[0];
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
            Mercado.GetInstance().Ofertas.Clear();
            Residuo = new Residuo("Metal", 100, "kg", 250, "$");
            Handler = new OfertasHandler(null);

            InvitationGenerator generator = new InvitationGenerator();
            string Invitacion = ListaInvitaciones.GetInstance(generator).AddInvitacion();
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
            Contador = 0;
            Publicacion = new Publicacion(Residuo, Ubicacion2, Empresa, "tener un camion", true);
            Publicacion.AgregarPalabraClave("Envio Gratis");



            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Id, out response);
            
            Assert.That(response, Is.EqualTo("¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no"));
            Message = "si";
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("Ingrese el numero de la palabra clave que buscar:\n0. Barato.\n1. Envio Gratis.\n2. Usado.\n3. Nuevo.\n"));
            Message = "1";
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("¿Cual es tu direccion? (Asi encontraremos publicaciones por proximidad)"));
            Message = Ubicacion2.Direccion;
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("Ingrese el tipo del residuo que quiere buscar:\n0. Metal\n1. Plastico (PET)\n2. Madera\n3. Goma\n4. Aluminio\n5. Cobre\n6. Nylon\n7. Papel\n8. Algodon\n9. Cuero\n10. Tela\n11. Fibra\n12. Organico\n13. Cables\n14. Pintura\n15. Carbon\n16. Componentes Electronicos\n17. Otros\n"));
            Message = "0";
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo($"Ingrese el número de la publicación para ver más información de la misma:\n0. {Publicacion.Empresa.Nombre} ofrece: {Publicacion.Residuo.Cantidad} {Publicacion.Residuo.Unidad} de {Publicacion.Residuo.Tipo} en {Publicacion.Ubicacion.Direccion}. Ademas la habilitacion para conseguir estos residuos es: {Publicacion.Habilitacion}\n"));

            Assert.That(Mercado.GetInstance().Ofertas.Contains(Publicacion));
            Assert.That(Publicacion.PalabraClave, Is.EqualTo(ListaPalabrasClave.GetInstance().Palabras[1]));
        }
        /// <summary>
        /// Este test se encarga de comprobar la funcionalidad de buscar una publicación sin usar una palabra clave.
        /// </summary>
        [Test]
        public void WithoutKeywordOfertasHandlerTest()
        {
            Mercado.GetInstance().Ofertas.Clear();
            Residuo = new Residuo("Metal", 100, "kg", 250, "$");
            Handler = new OfertasHandler(null);

            InvitationGenerator generator = new InvitationGenerator();
            string Invitacion = ListaInvitaciones.GetInstance(generator).AddInvitacion();
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
            Contador = 0;
            Publicacion = new Publicacion(Residuo, Ubicacion2, Empresa, "tener un camion", true);
            Publicacion.AgregarPalabraClave("Envio Gratis");
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Id, out response);
            
            Assert.That(response, Is.EqualTo("¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no"));
            Message = "no";
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("¿Cual es tu direccion? (Asi encontraremos publicaciones por proximidad)"));
            Message = Ubicacion2.Direccion;
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);  
            Assert.That(response, Is.EqualTo("Ingrese el tipo del residuo que quiere buscar:\n0. Metal\n1. Plastico (PET)\n2. Madera\n3. Goma\n4. Aluminio\n5. Cobre\n6. Nylon\n7. Papel\n8. Algodon\n9. Cuero\n10. Tela\n11. Fibra\n12. Organico\n13. Cables\n14. Pintura\n15. Carbon\n16. Componentes Electronicos\n17. Otros\n"));
            Message = "0";
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo($"Ingrese el número de la publicación para ver más información de la misma:\n0. {Publicacion.Empresa.Nombre} ofrece: {Publicacion.Residuo.Cantidad} {Publicacion.Residuo.Unidad} de {Publicacion.Residuo.Tipo} en {Publicacion.Ubicacion.Direccion}. Ademas la habilitacion para conseguir estos residuos es: {Publicacion.Habilitacion}\n"));

            Assert.That(Mercado.GetInstance().Ofertas.Contains(Publicacion));
        }
    }
}
