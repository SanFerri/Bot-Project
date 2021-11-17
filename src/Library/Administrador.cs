using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase Administrador del tipo IUsuario, posee, ademas de las property id, name e invitacion de toda clase 
    /// usuario, una property empresa que indica la empresa de la que participa el Empresario.
    /// </summary>
    public class Administrador : IUsuario
    {   
        /// <summary>
        /// Constructor de Administrador
        /// </summary>

        [JsonConstructor]
        public Administrador()
        {
            // Intencionalmente en blanco
        }
        /// <summary>
        /// Property id, es el encargado de conocer el numero entero del id del administrador.
        /// </summary>
        /// <value></value>
        public int Id{get; set;}
        /// <summary>
        /// Property invitacion, es el encargado de conocer el numero entero de la invitacion del 
        /// administrador.
        /// </summary>
        /// <value></value>
        public int Invitacion{get; set;}
        /// <summary>
        /// Constructor de una instancia de administrador. 
        /// </summary>
        /// <param name="invitacion"></param>

        public Administrador(int invitacion)
        {
            this.Invitacion = invitacion;
        }
    }
}