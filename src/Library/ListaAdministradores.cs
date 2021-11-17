using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace ClassLibrary
{
    /// <summary>
    /// ListaAdministradores es el experto en conocer a los administradores, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar administradores y/o removerlos.
    /// </summary>
    public class ListaAdministradores : IJsonConvertible
    {
        /// <summary>
        /// Variable estatica administrador, porque es una lista de instancias de administrador
        /// que lleva un registro de todos los administradores que hay.
        /// </summary>
        /// <returns></returns>
        public static List<Administrador> administradores {get; set;}
        private static ListaAdministradores _instance;

        /// <summary>
        /// Metodo que agrega un administrador a la lista de administradores, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="administrador"></param>
        public void AddAdministrador(Administrador administrador)
        {
            administradores.Add(administrador);
        }

        /// <summary>
        /// Metodo que remove un administrador a la lista de administradores, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="administrador"></param>
        public void RemoveAdministrador(Administrador administrador)
        {
            administradores.Remove(administrador);
        }
        /// <summary>
        /// Constructor vacio para sumarle instancias a la clase.
        /// </summary>
        [JsonConstructor]
        private ListaAdministradores()
        {
            this.administradores = new List<Administrador>();
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
        /// Sirve para aplicar el singleton, verifica si _intance es nula y si no es nula te devuelve el 
        /// valor de la property.
        /// </summary>
        /// <returns></returns>
        public static ListaAdministradores GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ListaAdministradores();
            }
            return _instance;
        }

        /// <summary>
        /// Sirve para deserializar un string de json para asi 
        /// asignarle una nueva clase ListaAdministradores los valores 
        /// previos a ponerle un stop al program para asi mantener la información.
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            ListaAdministradores deserialized = JsonSerializer.Deserialize<ListaAdministradores>(json);
            this.administradores = deserialized.administradores;
        }
    }
}
