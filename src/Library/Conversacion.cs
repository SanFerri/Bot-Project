using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Clase que conoce la conversacion del bot con usuarios 
    /// </summary>
    public class Conversacion
    {

        public List<string> conversacion{get; set;} = new List<string>();
        public static Dictionary<IUsuario, Conversacion> usuarioConversacion = new Dictionary<IUsuario, Conversacion>();

        public void AddMessage(string message)
        {
            conversacion.Add(message);
        }

        public void RemoveMessage(string message)
        {
            conversacion.Remove(message);
        }

        public void AddConversacionUsuario(IUsuario usuario, Conversacion conversacion)
        {
            usuarioConversacion.Add(usuario, conversacion);
        }

        public void RemoveConversacionUsuario(IUsuario usuario)
        {
            usuarioConversacion.Remove(usuario);
        }
    }
}