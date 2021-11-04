using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Clase de test que se encarga de probar las distintas funciones del ResiduosPuntualesHandler.
    /// Los test individualmente utilizando "run test" funcionan correctamente, pero al intentar usar "run all tests" no detecta ninguno.
    /// </summary>
    public class ResiduosPuntualesTests
    {
        Residuo residuo;
        ResiduosPuntualesHandler handler;
        string message;
        Empresa empresa;
        Empresario Usuario;
        Administrador Usuario2;
        Ubicacion ubicacion;
        int id;

        /// <summary>
        /// El Setup de los test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            handler = new ResiduosPuntualesHandler(null);
            
            int invitacion = InvitationGenerator.Generate();
            ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            empresa = new Empresa("MercadoPrivado", ubicacion, 099679938);
            Residuo residuo = empresa.residuos.AddResiduo("metal", 100, "kg", 250, "$");
            id = 12345678;
            Usuario = ListaEmpresarios.AddEmpresario(invitacion, empresa, id);
            Usuario.id = id;
            
            int invitacion2 = InvitationGenerator.Generate();
            Usuario2 = ListaAdministradores.AddAdministrador(invitacion2, id);
            
            ListaPublicaciones publicaciones = new ListaPublicaciones();
            Publicacion publicacion = publicaciones.AddPublicacion(residuo, ubicacion, empresa, "tener un camion", false);
            Mercado.AddMercado(publicacion);
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /residuospuntuales.
        /// </summary>
        [Test]
        public void PuntualesCanHandleTest()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);

            Assert.That(response, Is.EqualTo("Estos son los residuos puntuales:\nmetal"));
        }

        /// <summary>
        /// Este test se encarga de comprobar que el handler no responde nada si se utiliza 
        /// un comando distinto de /residuospuntuales.
        /// </summary>
        [Test]
        public void PuntualesCantHandleTest()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            message = "/residuosconsantes";
            string response;

            IHandler result = handler.Handle(message, emprendedor.id, out response);

            Assert.That(response, Is.EqualTo(""));
        }
    }
}