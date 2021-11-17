using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase Empresario del tipo IUsuario, posee, ademas de las property id e invitacion de toda clase 
    /// usuario, una property empresa que indica la empresa de la que participa el Empresario.
    /// </summary>
    public class Empresario : IUsuario
    {
        /// <summary>
        /// Constructor de Empresario.
        /// </summary>
       
        [JsonConstructor]
        public Empresario()
        {
            // Intencionalmente en blanco
        }
        /// <summary>
        /// Es el encargado de conocer la empresa de la que es parte.
        /// </summary>
        /// <value></value>
        public Empresa Empresa{get; set;}
        
        /// <summary>
        /// Es el encargado de conocer el id del empresario.
        /// </summary>
        /// <value></value>
        public int Id{get; set;}
        
        /// <summary>
        /// Es el encargado de conocer el valor de una invitación de acceso.
        /// </summary>
        /// <value></value>
        public int Invitacion{get; set;}
       
        /// <summary>
        /// Constructor de una instancia de Empresario.
        /// </summary>
        /// <param name="invitacion"></param>
        /// <param name="empresa"></param>
        public Empresario(int invitacion, Empresa empresa)
        {
            this.Empresa = empresa;
            this.Invitacion = invitacion;
        }
    }
}