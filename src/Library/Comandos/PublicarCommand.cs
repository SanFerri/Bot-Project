using System;
using System.IO;
/*
namespace ClassLibrary
{
    /// <summary>
    /// Comando que permite a los empresarios realizar publicaciones de sus residuos.
    /// </summary>
    public class PublicarCommand : ICommand
    {
        /// <summary>
        /// Proximo comando es Invitar
        /// </summary>
        public ICommand next{get;set;} = new InvitarCommand();
        public Residuo residuoElegido{get;set;}
        public int contacto{get;set;}
        public Ubicacion ubicacion{get;set;}

        /// <summary>
        /// Metodo que evalua si el usuario completa los requerimientos (ser un empresario) y ve si el mensaje es
        /// el indicado para este comando.
        /// </summary>
        /// <param name="empresario"></param>
        /// <param name="message"></param>
        public void Do(IUsuario empresario, string message)
        {
            // Verificamos que el mensaje sea el correcto
            if(message == "/publicar")
            {
                // Verificamos los requerimientos (ser un empresario)
                if(empresario.GetType() == typeof(Empresario))
                {
                    Registrado.VerifyConversation(empresario, message);
                    Console.WriteLine("¿Una publicacion de cual de sus residuos quiere hacer?");

                    int contador = 0;
                    foreach(Residuo residuo in empresario.empresa.residuos)
                    {
                        Console.WriteLine($"{contador}. {residuo.tipo} ");
                        contador += 1;
                    }
                }
                else
                {
                    Console.WriteLine("Usted no es un empresario");
                }
            }

            else
            {
                next.Do(empresario);
            }
        }
    }
}
*/