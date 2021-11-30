using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Clase de test que se encarga de probar las distintas funciones del ResiduosConstantesHandler.
    /// Los test individualmente utilizando "run test" funcionan correctamente, pero al intentar usar "run all tests" no detecta ninguno.
    /// </summary>
    public class VerResiduosConsumidosTests
    {
        Residuo Residuo;
        VerResiduosConsumidosHandler Handler;
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
        /// El Setup de los test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Residuo = new Residuo("Metal", 100, "kg", 250, "$");
            Handler = new VerResiduosConsumidosHandler(null);

            InvitationGenerator generator = new InvitationGenerator();
            
            string invitacion = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            Usuario = new Empresario(invitacion, Empresa);
            Id = 12345678;
            Usuario.Id = Id;
            Empresarios.AddEmpresario(Usuario);
            string invitacion2 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.Id = Id;
            Administradores.AddAdministrador(Usuario2);
            Publicacion = new Publicacion(Residuo, Ubicacion, Empresa, "Tener un camion", true);
            Mercado.AddMercado(Publicacion);
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /residuosconstantes.
        /// </summary>
        [Test]
        public void VerResiduosConsumidosHandle()
        {
            Emprendedor emprendedor = new Emprendedor(3829);
            Empresa.Publicaciones.Publicaciones[0].Entregado = true;
            Empresa.Publicaciones.Publicaciones[0].IdEntregado = emprendedor.Id;
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, emprendedor.Id, out response);

            Assert.That(response, Is.EqualTo("¿Residuos entregados desde hace cuantos dias quieres ver?"));
            Message = "90";
            Handler.Handle(Message, emprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("Estas son tus residuos consumidos:\nConsumio: 100 de Metal, el costo de este es 250$\n"));
        }
        
        /// <summary>
        /// Este test se encarga de comprobar que el handler no responde nada si se utiliza 
        /// un comando distinto de /residuosconstantes.
        /// </summary>
        [Test]
        public void VerResiduosConsumidosCantHandle()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            Empresa.Publicaciones.Publicaciones[0].Entregado = true;
            Empresa.Publicaciones.Publicaciones[0].IdEntregado = emprendedor.Id;
            Message = "/residuospuntuales";
            string response;

            IHandler result = Handler.Handle(Message, emprendedor.Id, out response);

            Assert.That(response, Is.EqualTo(""));
        }
    }
}