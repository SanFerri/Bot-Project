using System.Collections.Generic;
namespace ClassLibrary

{
    public class Emprendedor : IUsuario
    {
        public string nombre;
        public int invitacion;
        public int id;

        public Emprendedor(int invitacion, string nombre)
        {
            this.nombre = nombre;
            this.invitacion = invitacion;
        }
    }

}