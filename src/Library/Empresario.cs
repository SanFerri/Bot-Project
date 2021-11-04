namespace ClassLibrary
{
    /// <summary>
    /// Clase Empresario del tipo IUsuario, posee, ademas de las property id e invitacion de toda clase 
    /// usuario, una property empresa que indica la empresa de la que participa el Empresario.
    /// </summary>
    public class Empresario : IUsuario
    {
       
        /// <summary>
        /// Es el encargado de conocer la empresa de la que es parte.
        /// </summary>
        /// <value></value>
        public Empresa empresa{get; set;}
        
        /// <summary>
        /// Es el encargado de conocer el id del empresario.
        /// </summary>
        /// <value></value>
        public int id{get; set;}
        
        /// <summary>
        /// Es el encargado de conocer el valor de una invitación de acceso.
        /// </summary>
        /// <value></value>
        public int invitacion{get; set;}
       
        /// <summary>
        /// Constructor de una instancia de Empresario.
        /// </summary>
        /// <param name="invitacion"></param>
        /// <param name="empresa"></param>
        public Empresario(int invitacion, Empresa empresa, int id)
        {
            this.empresa = empresa;
            this.invitacion = invitacion;
            this.id = id;
        }
    }
}