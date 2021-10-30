using System;

namespace ClassLibrary
{
    /// <summary>
    /// Clase InvitarCommand es una clase que implementa ICommand, esta se encarga de asociar a un usuario nuevo una
    /// invitacion, la responsabilidad de crear dicha invitacion es delegada a InvitationGenerator.
    /// </summary>
    public class InvitarCommand : ICommand
    {
        /// <summary>
        /// Proximo comando es para ver las ofertas
        /// </summary>
        public ICommand next{get;set;} = new OfertasCommand();

        /// <summary>
        /// Metodo Do que se encarga de crear un nuevo usuario y su ID
        /// </summary>
        /// <param name="administrador"></param>
        /// <param name="message"></param>
        public void Do(IUsuario administrador, string message)
        {
            if(message == "/invitar")
            {
                if(administrador.GetType() == typeof(Administrador))
                {
                    Registrado.VerifyConversation(administrador, message);
                    int invitacion = InvitationGenerator.Generate();
                    Console.WriteLine($"Esta es la invitacion {invitacion}");
                    Console.WriteLine("¿Cual es el nombre?");
                }
            }
            else
            {
                next.Do(administrador, message);
            }
        }
    }
}