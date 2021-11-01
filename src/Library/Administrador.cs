namespace ClassLibrary
{
    /// <summary>
    /// Clase Empresario del tipo IUsuario, posee, ademas de las property id, name e invitacion de toda clase 
    /// usuario, una property empresa que indica la empresa de la que participa el Empresario.
    /// </summary>
    public class Administrador : IUsuario
    {
        public string nombre { get; set; }
        public int id{get; set;}
        public int invitacion{get; set;}

        public Administrador(int invitacion, string nombre)
        {
            this.invitacion = invitacion;
            this.nombre = nombre;
        }
    }
}