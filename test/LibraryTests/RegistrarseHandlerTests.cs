using NUnit.Framework;
using ClassLibrary;
using System;

namespace Tests
{
    /// <summary>
    /// Clase de test que se encarga de probar las distintas funciones del RegistrarseHandler.
    /// </summary>
    public class RegistrarseHandlerTests
    {
        Residuo Residuo;
        RegistrarseHandler Handler = new RegistrarseHandler(null);
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
        string Invitacion;
        
        /// <summary>
        /// El Setup de los test
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Residuo = new Residuo("Metal", 100, "kg", 250, "$");
            
            InvitationGenerator generator = new InvitationGenerator();
            Invitacion = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            UsuarioEmpresario = new Empresario(Invitacion, Empresa);
            UsuarioEmpresario.Id = 3439;

            UsuarioEmprendedor = new Emprendedor(3582);
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /registrarse.
        /// </summary>
        [Test]
        public void RegistrarseCanHandleTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, UsuarioEmpresario.Id, out response);

            Assert.That(response, Is.EqualTo("Usted ya esta registrado como un empresario"));
        }

        /// <summary>
        /// Este test se encarga de comprobar que funciona el comando /registrarse con un usuario que no es un emprendedor.
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
        /// Este test se encarga de comprobar la funcionalidad de registrarse como un empresario.
        /// </summary>
        [Test]
        public void WorkingRegistrarseHandlerTest()
        {
            Message = Handler.Keywords[0];
            string response;

            Console.WriteLine(Invitacion);

            IHandler result = Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            
            Assert.That(response, Is.EqualTo("Esta registrado como un emprendedor, ingrese una invitación si es parte de una empresa, en caso de no serlo responda con un no"));
            Message = Invitacion;
            Handler.Handle(Message, UsuarioEmprendedor.Id, out response);
            Assert.That(response, Is.EqualTo("Se te ha registrado correctamente, en caso de querer cambiar los datos predeterminados de la empresa use el comando /cambiardatos"));

            bool RealEmpresario = false;
            foreach(Empresario Empresario in ListaEmpresarios.GetInstance().Empresarios)
            {
                if(Empresario.Id == UsuarioEmprendedor.Id)
                {
                    RealEmpresario = true;
                }
            }
            Assert.That(RealEmpresario, Is.EqualTo(true));
        }
    }
}