using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
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

        [SetUp]
        public void Setup()
        {
            residuo = new Residuo("metal", 100);
            handler = new OfertasHandler(null);
            int invitacion = InvitationGenerator.Generate();
            ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            ubicacion2 = new Ubicacion("Av. Italia 3479");
            empresa = new Empresa("MercadoPrivado", ubicacion, 099679938);
            empresa.residuos.AddResiduo(residuo);
            UsuarioEmpresario = new Empresario(invitacion, empresa);
            UsuarioEmprendedor = new Emprendedor(id);
            id = 12345678;
            id2 = 87654321;
            UsuarioEmprendedor.id = id;
            UsuarioEmpresario.id = id2;
            ListaEmpresarios.AddEmpresario(UsuarioEmpresario);
            ListaUsuarios.AddUsuario(UsuarioEmprendedor);
            contador = 0;
            publicacion = new Publicacion(residuo, ubicacion2, empresa);
        }

        [Test]
        public void OfertasCanHandle()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);

            Assert.That(response, Is.EqualTo("¿Cual es tu ubicación?"));
        }

        [Test]
        public void OfertasEmpresarioCanHandle()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, UsuarioEmpresario.id, out response);

            Assert.That(response, Is.EqualTo("¿Cual es tu ubicación?"));
        }

        [Test]
        public void WorkingOfertasHandler()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);
            
            message = ubicacion2.direccion;
            handler.Handle(message, UsuarioEmprendedor.id, out response);
            message = residuo.tipo;
            handler.Handle(message, id, out response);


            Assert.That(response, Is.EqualTo($"{contador}. {publicacion.empresa.nombre} ofrece: {publicacion.residuo.cantidad} kg de {publicacion.residuo.tipo} en {publicacion.ubicacion}\n"));
        }
    
    
    }

    









}
