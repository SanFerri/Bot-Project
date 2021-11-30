using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
    /// <summary>
    /// Test
    /// </summary>
    public class AgregarResiduoHandlerTests
    {
        Residuo Residuo;
        AgregarResiduoHandler Handler;
        string Message;
        Empresa Empresa;
        Empresario Usuario;
        Administrador Usuario2;
        Ubicacion Ubicacion;
        int Id;
        ListaEmpresarios Empresarios = ListaEmpresarios.GetInstance();
        ListaAdministradores Administradores = ListaAdministradores.GetInstance();

        /// <summary>
        /// SetUp de las instancias de clases y distintos elementos necesarios
        /// para llevar asi acabo los tests.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Residuo = new Residuo("Metal", 100, "kg", 250, "$");
            InvitationGenerator generator = new InvitationGenerator();
            
            string invitacion = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            Empresa = new Empresa("MercadoPrivado", Ubicacion, "099679938");
            Empresa.Residuos.AddResiduo(Residuo);
            Usuario = new Empresario(invitacion, Empresa);
            Id = 12345678;
            Usuario.Id = Id;
            Empresarios.AddEmpresario(Usuario);

            Handler = new AgregarResiduoHandler(null);
            string invitacion2 = ListaInvitaciones.GetInstance(generator).AddInvitacion();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.Id = Id;
            Administradores.AddAdministrador(Usuario2);
        }

        /// <summary>
        /// Si el que trata de usar el comando /agregarresiduo es un empresario 
        /// (En este caso deberia pasar al menos el primer Handle).
        /// </summary>
        [Test]
        public void AgregarResiduoHandleTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Id, out response);

            Assert.That(response, Is.EqualTo("Ingrese el tipo del residuo que quiere agregar:\n0. Metal\n1. Plastico (PET)\n2. Madera\n3. Goma\n4. Aluminio\n5. Cobre\n6. Nylon\n7. Papel\n8. Algodon\n9. Cuero\n10. Tela\n11. Fibra\n12. Organico\n13. Cables\n14. Pintura\n15. Carbon\n16. Componentes Electronicos\n17. Otros\n"));
        }
        /// <summary>
        /// Si el que trata de usar el comando /agregarresiduos no es un empresario
        /// (En este caso no deberia pasar los handles y por eso devuelva)
        /// </summary>
        [Test]
        public void AgregarResiduoCantHandleTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, 38291203, out response);

            Assert.That(response, Is.EqualTo("Usted no es un empresario, no puede acceder a este comando"));
        }
        /// <summary>
        /// Aqui comprobamos que funcione el handler si se pasa por todo el
        /// proceso de la forma prevista.
        /// </summary>
        [Test]
        public void WorkingAgregarResiduoHandlerTest()
        {
            Message = Handler.Keywords[0];
            string response;

            IHandler result = Handler.Handle(Message, Usuario2.Id, out response);
            
            Message = "0";
            Handler.Handle(Message, Usuario2.Id, out response);
            Message = $"{Residuo.Cantidad}";
            Handler.Handle(Message, Usuario2.Id, out response);
            Message = "1";
            Handler.Handle(Message, Usuario2.Id, out response);
            Message = $"{Residuo.Cost}";
            Handler.Handle(Message, Usuario2.Id, out response);
            Message = Residuo.Moneda;
            Handler.Handle(Message, Usuario2.Id, out response);


            Assert.That(response, Is.EqualTo($"Se ha agregado el residuo Metal"));
            Assert.That(Empresa.Residuos.Residuos.Contains(Handler.Residuo));
            Assert.That(Handler.Residuo.Tipo, Is.EqualTo(Residuo.Tipo));
            Assert.That(Handler.Residuo.Cantidad, Is.EqualTo(Residuo.Cantidad));
            Assert.That(Handler.Residuo.Cost, Is.EqualTo(Residuo.Cost));
            Assert.That(Handler.Residuo.Unidad, Is.EqualTo(Residuo.Unidad));
            Assert.That(Handler.Residuo.Moneda, Is.EqualTo(Residuo.Moneda));
        }
    }
}