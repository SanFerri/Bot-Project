using NUnit.Framework;
using ClassLibrary;

namespace Tests
{
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

        [SetUp]
        public void Setup()
        {
            residuo = new Residuo("metal", 100, "kg", 250, "$");
            handler = new ResiduosPuntualesHandler(null);
            
            int invitacion = InvitationGenerator.Generate();
            ubicacion = new Ubicacion("Av. 8 de Octubre 2738");
            empresa = new Empresa("MercadoPrivado", ubicacion, 099679938);
            empresa.residuos.AddResiduo(residuo);
            Usuario = new Empresario(invitacion, empresa);
            id = 12345678;
            Usuario.id = id;
            ListaEmpresarios.AddEmpresario(Usuario);
            int invitacion2 = InvitationGenerator.Generate();
            Usuario2 = new Administrador(invitacion2);
            Usuario2.id = id;
            ListaAdministradores.AddAdministrador(Usuario2);
            Publicacion publicacion = new Publicacion(residuo, ubicacion, empresa, "Tener un camion", false);
            Mercado.AddMercado(publicacion);
        }

        [Test]
        public void PuntualesCanHandle()
        {
            message = handler.Keywords[0];
            string response;

            IHandler result = handler.Handle(message, id, out response);

            Assert.That(response, Is.EqualTo("Estos son los residuos puntuales:\nmetal"));
        }

        [Test]
        public void PuntualesCantHandle()
        {
            Emprendedor emprendedor = new Emprendedor(34314458);
            message = "/residuosconsantes";
            string response;

            IHandler result = handler.Handle(message, emprendedor.id, out response);

            Assert.That(response, Is.EqualTo(""));
        }
    }
}