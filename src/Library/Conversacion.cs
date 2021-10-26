using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Clase que conoce la conversacion del bot con usuarios 
    /// </summary>
    public class Conversacion
    {
        
        public List<string> conversacion{get; set;} = new List<string>();
        public static Dictionary<Usuario, Conversacion> usuarioConversacion = new Dictionary<Usuario, Conversacion>();

        public void AddMessage(string message)
        {
            conversacion.Add(message);
        }

        public void RemoveMessage(string message)
        {
            conversacion.Remove(message);
        }

        public void AddConversacionUsuario(Usuario usuario, Conversacion conversacion)
        {
            usuarioConversacion.Add(usuario, conversacion);
        }

        public void RemoveConversacionUsuario(Usuario usuario, Conversacion conversacion)
        {
            usuarioConversacion.Remove(usuario, conversacion);
        }
    }
}