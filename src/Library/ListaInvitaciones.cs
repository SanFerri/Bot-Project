using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// ListaInvitaciones es una clase que contiene invitaciones que posee dos metodos AddInvitacion y 
    /// RemoveInvitacion para añadir o remover invitaciones de una property de la clase llamada ListaInvitaciones, es el encargado
    /// de llevar a cabo dichas tareas porque es el experto en conocer las invitaciones.
    /// </summary>
    public class ListaInvitaciones
    {
        /// <summary>
        /// Property string invitaciones, es una lista de instancias de invitaciones
        /// que lleva el registro de las invitaciones.
        /// </summary>
        /// <returns></returns>
        [JsonInclude]
        public List<string> Invitaciones = new List<string>();

        private static ListaInvitaciones _instance;

        /// <summary>
        /// AddInvitacion es un metodo que se encarga de agregar invitaciones a la lista.
        /// </summary>
        /// <param name="invitacion"></param>
        public void AddInvitacion(string invitacion)
        {
            this.Invitaciones.Add(invitacion);
        }

        //[JsonInclude]
        //public IList<string> Steps { get; private set; } = new List<string>();

        /// <summary>
        /// RemoveInvitacion es un metodo que se encarga de eliminar invitaciones de la lista.
        /// </summary>
        /// <param name="invitacion"></param>
        public void RemoveInvitacion(string invitacion)
        {
            this.Invitaciones.Add(invitacion);
        }
        /// <summary>
        /// Sirve para aplicar el singleton, verifica si ListaInvitaciones es nula y si no es nula te 
        /// devuelve el valor de la property.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Sirve para deserializar un string de json para asi 
        /// asignarle una nueva clase ListaInvitaciones los valores 
        /// previos a ponerle un stop al program para asi mantener la información.
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            ListaInvitaciones deserialized = JsonSerializer.Deserialize<ListaInvitaciones>(json);
            this.Invitaciones = deserialized.Invitaciones;
        }

    }
}