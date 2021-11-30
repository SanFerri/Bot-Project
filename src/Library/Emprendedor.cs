using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary

{
    /// <summary>
    /// Clase Emprendedor del tipo IUsuario, posee el nombre, invitacion e id del emprendedor.
    /// </summary>
    public class Emprendedor : IUsuario, IJsonConvertible
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        /// <value></value>
        public string State { get; set; } = "start";
        /// <summary>
        /// Constructor de Emprendedor.
        /// </summary>

        [JsonConstructor]
        public Emprendedor()
        {
            // Intencionalmente en blanco
        }

        /// <summary>
        /// Property id, es el id que se le asigna al emprededor para poder reconocerlo como tal.
        /// </summary>
        /// <value></value>
        public int Id{get;set;}
        /// <summary>
        /// Constructor de una instancia de Emprendedor. 
        /// </summary>
        /// <param name="id"></param>

        public Emprendedor(int id)
        {
            this.Id = id;
            ListaUsuarios LosUsuarios = ListaUsuarios.GetInstance();
            LosUsuarios.AddUsuario(this);
        }

        /// <summary>
        /// Metodo que convierte una clase en string Json (serializa).
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }

}