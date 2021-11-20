using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Clase de test que se encarga de probar las distintas funciones del ResiduosConstantesHandler.
    /// Los test individualmente utilizando "run test" funcionan correctamente, pero al intentar usar "run all tests" no detecta ninguno.
    /// </summary>
    public class ResiduosConstantesTests
    {
        Residuo residuo;
        ResiduosConstantesHandler handler;
        string message;
        Empresa empresa;
        Empresario Usuario;
        Administrador Usuario2;
        Ubicacion ubicacion;
        int id;
        ListaEmpresarios empresarios = ListaEmpresarios.GetInstance();
        ListaAdministradores administradores = ListaAdministradores.GetInstance();
        ListaUsuarios usuarios = ListaUsuarios.GetInstance();
        Mercado mercado = Mercado.GetInstance();

        /// <summary>
        /// El Setup de los test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            residuo = new Residuo("metal", 100, "kg", 250, "$");
            handler = new ResiduosConstantesHandler(null);
            
            int invitacion = InvitationGenerator.Generate();
            ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            empresa = new Empresa("MercadoPrivado", ubicacion, "099679938");
            empresa.Residuos.AddResiduo(residuo);
            Usuario = new Empresario(invitacion, empresa);
            id = 12345678;
            Usuario.Id = id;
            empresarios.AddEmpresario(Usuario);
            int invitacion2 = InvitationGenerator.Generate();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.Id = id;
            administradores.AddAdministrador(Usuario2);
            Publicacion publicacion = new Publicacion(residuo, ubicacion, empresa, "Tener un camion", true);
            mercado.AddMercado(publicacion);
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /residuosconstantes.
        /// </summary>
        [Test]
        public void ResiduosConstantesCanHandle()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);

            Assert.That(response, Is.EqualTo("Estos son los residuos constantes:\nmetal"));
        }
        
        /// <summary>
        /// Este test se encarga de comprobar que el handler no responde nada si se utiliza 
        /// un comando distinto de /residuosconstantes.
        /// </summary>
        [Test]
        public void ResiduosConstantesCantHandle()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            message = "/residuospuntuales";
            string response;

            IHandler result = handler.Handle(message, emprendedor.Id, out response);

            Assert.That(response, Is.EqualTo(""));
        }
    }
}