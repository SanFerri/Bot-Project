using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// ListaPalabrasClave es una clase que contiene palabras clave que posee dos metodos AddPalabra y 
    /// RemovePalabra para añadir o remover elementos de una property de la clase llamada ListaPalabrasClave, es el encargado
    /// de llevar a cabo dichas tareas porque es el experto en conocer las palabras claves.
    /// </summary>
    public class ListaInvitaciones
    {
        [JsonInclude]
        /// <summary>
        /// Property string palabras, es una lista de instancias de palabras clave
        /// que lleva el registro de las palabras clave.
        /// </summary>
        /// <returns></returns>
        public List<string> Invitaciones = new List<string>();

        private static ListaInvitaciones _instance;

        /// <summary>
        /// AddPalabra es un metodo que se encarga de agregar palabras a la lista.
        /// </summary>
        /// <param name="palabra"></param>
        public void AddInvitacion(string invitacion)
        {
            this.Invitaciones.Add(invitacion);
        }

        //[JsonInclude]
        //public IList<string> Steps { get; private set; } = new List<string>();

        /// <summary>
        /// RemovePalabra es un metodo que se encarga de eliminar palabras de la lista.
        /// </summary>
        /// <param name="palabra"></param>
        public void RemoveInvitacion(string invitacion)
        {
            this.Invitaciones.Add(invitacion);
        }
        public static ListaInvitaciones GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ListaInvitaciones();
            }
            return _instance;
        }
        [JsonConstructor]
        private ListaInvitaciones()
        {
        }


        /// <summary>
        /// Sirve para serializar la clase y todas sus property.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public void LoadFromJson(string json)
        {
            ListaInvitaciones deserialized = JsonSerializer.Deserialize<ListaInvitaciones>(json);
            this.Invitaciones = deserialized.Invitaciones;
        }

    }
}