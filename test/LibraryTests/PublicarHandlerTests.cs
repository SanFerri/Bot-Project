using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Clase de test que se encarga de probar las distintas funciones del PublicarHandler.
    /// Los test individualmente utilizando "run test" funcionan correctamente, pero al intentar usar "run all tests" no detecta ninguno.
    /// </summary>
    public class PublicarHandlerTests
    {
        Residuo residuo;
        PublicarHandler handler;
        InvitarHandler handler2;
        string message;
        Empresa empresa;
        Empresario Usuario;
        Administrador Usuario2;
        Ubicacion ubicacion;
        int id;

        /// <summary>
        /// el set up de los test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            residuo = new Residuo("metal", 100, "kg", 250, "$");
            handler = new PublicarHandler(null);
            
            int invitacion = InvitationGenerator.Generate();
            ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            empresa = new Empresa("MercadoPrivado", ubicacion, 099679938);
            empresa.residuos.AddResiduo(residuo);
            Usuario = new Empresario(invitacion, empresa);
            id = 12345678;
            Usuario.id = id;
            ListaEmpresarios.AddEmpresario(Usuario);

            handler2 = new InvitarHandler(null);
            int invitacion2 = InvitationGenerator.Generate();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.id = id;
            ListaAdministradores.AddAdministrador(Usuario2);
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /publicar.
        /// </summary>
        [Test]
        public void PublicarCanHandleTest()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);

            Assert.That(response, Is.EqualTo("Ingrese el numero de la palabra clave que quiera agregar:\n0. Barato.\n1. Envio Gratis.\n2. Usado.\n3. Nuevo.\n"));
        }

        /// <summary>
        /// Este test se encarga de comprobar que el comando /publicar no funciona con un usuario que no es un empresario.
        /// </summary>
        [Test]
        public void PublicarCantHandleTest()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, emprendedor.id, out response);

            Assert.That(response, Is.EqualTo("Usted no es un empresario, no puede usar el codigo..."));
        }

        /// <summary>
        /// Este test se encarga de comprobar la funcionalidad de crear una publicación.
        /// </summary>
        [Test]
        public void WorkingPublicarHandlerTest()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);
            Assert.That(response, Is.EqualTo("Ingrese el numero de la palabra clave que quiera agregar:\n0. Barato.\n1. Envio Gratis.\n2. Usado.\n3. Nuevo.\n"));

            message = "1";
            handler.Handle(message, emprendedor.id, out response);
            Assert.That(response, Is.EqualTo("Porfavor ingrese la habilitacion para los residuos."));

            message = "Necesitara un camion o vehiculo";
            handler.Handle(message, emprendedor.id, out response);
            Assert.That(response, Is.EqualTo("Porfavor responda si o no, ¿Estos residuos que se generaron se generan de forma constante? Si fue puntual responda no."));

            message = "si";
            handler.Handle(message, emprendedor.id, out response);
            Assert.That(response, Is.EqualTo("Porfavor ingrese la direccion de los residuos."));

            message = ubicacion.direccion;
            handler.Handle(message, emprendedor.id, out response);
            Assert.That(response, Is.EqualTo("Ahora dime sobre cual de tus residuos quieres publicar"));

            message = residuo.tipo;
            handler.Handle(message, id, out response);
            Assert.That(response, Is.EqualTo($"Se ha publicado la oferta de {residuo.tipo} de la empresa {empresa.nombre}. En la ubicacion {ubicacion.direccion}"));
        }
    }
}