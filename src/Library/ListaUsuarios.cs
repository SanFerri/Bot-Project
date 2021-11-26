using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// ListaUsuarios es el experto en conocer a todos los Usuario, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar y/o remover Usuario.
    /// A su vez depende de IUsuario para agregar cualquier tipo de usuario (emprendedor,
    /// administrador o Usuario).
    /// </summary>
    public class ListaUsuarios : IJsonConvertible
    {
        [JsonInclude]
        /// <summary>
        /// Variable estatica Usuario, porque es una lista de instancias de Usuario
        /// que lleva un registro de todos las Usuario que hay.
        /// </summary>
        /// <returns></returns>
        public List<Emprendedor> Usuarios {get; set;}
        private static ListaUsuarios _instance;

        /// <summary>
        /// AddUsuario es el encargado de agregar Usuario a la lista.
        /// </summary>
        /// <param name="usuario"></param>
        public void AddUsuario(Emprendedor usuario)
        {
            Usuarios.Add(usuario);
        }

        //[JsonInclude]
        //public IList<IUsuario> Steps { get; private set; } = new List<IUsuario>();

        /// <summary>
        /// RemoveUsuario es el encargado de remover Usuario de la lista.
        /// </summary>
        /// <param name="usuario"></param>
        public void RemoveUsuario(Emprendedor usuario)
        {
            Usuarios.Remove(usuario);
        }

        /// <summary>
        /// Constructor vacio para agregarle instancias a la clase.
        /// </summary>
        [JsonConstructor]
        private ListaUsuarios()
        {
            this.Usuarios = new List<Emprendedor>();
        }

        /// <summary>
        /// Sirve para serializar la clase y todas sus property.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this, options);
        }

        /// <summary>
        /// Sirve para deserializar un string de json para asi 
        /// asignarle una nueva clase ListaInvitaciones los valores 
        /// previos a ponerle un stop al program para asi mantener la información.
        /// </summary>
        /// <param name="json"></param>
        public void LoadFromJson(string json)
        {
            ListaUsuarios deserialized = JsonSerializer.Deserialize<ListaUsuarios>(json);
            this.Usuarios = deserialized.Usuarios;
        }

        /// <summary>
        /// Sirve para aplicar el singleton, verifica si la property ListaUsuarios es nula y si no es nula te devuelve el 
        /// valor de la property.
        /// </summary>
        /// <returns></returns>
        public static ListaUsuarios GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ListaUsuarios();
            }
            return _instance;
        }
    }
}