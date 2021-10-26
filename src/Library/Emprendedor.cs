using System.Collections.Generic;
namespace ClassLibrary

{
    public class Emprendedor : IUsuario
    {
        public string nombre{get;set;}
        public int invitacion{get;set;}
        public int id{get;set;}

        public Emprendedor(int invitacion, string nombre)
        {
            this.nombre = nombre;
            this.invitacion = invitacion;
        }
    }

}