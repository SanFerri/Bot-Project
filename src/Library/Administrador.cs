namespace ClassLibrary
{
    /// <summary>
    /// Clase Empresario del tipo IUsuario, posee, ademas de las property id, name e invitacion de toda clase 
    /// usuario, una property empresa que indica la empresa de la que participa el Empresario.
    /// </summary>
    public class Administrador : IUsuario
    {
        public string name{get; set;}
        public int id{get; set;}
        public int invitacion{get; set;}

        public Administrador(int invitacion, string name)
        {
            this.invitacion = invitacion;
            this.name = name;
        }
    }
}