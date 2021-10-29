using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Clase que conoce la conversacion del bot con usuarios 
    /// </summary>
    public class Conversacion
    {
        public List<string> conversacion{get;set;} = new List<string>();
        public Conversacion(string message)
        {
            this.conversacion.Add(message);
        }


        public void AddMessage(string message)
        {
            conversacion.Add(message);
        }

        public void RemoveMessage(string message)
        {
            conversacion.Remove(message);
        }
    }
}