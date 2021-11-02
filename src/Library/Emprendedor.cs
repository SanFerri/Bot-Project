using System.Collections.Generic;
namespace ClassLibrary

{
    /// <summary>
    /// Clase Emprendedor del tipo IUsuario, posee el nombre, invitacion e id del emprendedor.
    /// </summary>
    public class Emprendedor : IUsuario
    {
        /// <summary>
        /// Property invitación, es la invitación que se le hace al emprendedor para ingresar y poder 
        /// acceder a los residuos publicados por las empresas.
        /// </summary>
        /// <value></value>
        public int invitacion{get;set;}
        /// <summary>
        /// Property id, es el id que se le asigna al emprededor para poder reconocerlo como tal.
        /// </summary>
        /// <value></value>
        public int id{get;set;}
        /// <summary>
        /// Constructor de una instancia de Emprendedor. 
        /// </summary>
        /// <param name="id"></param>

        public Emprendedor(int id)
        {
            this.id = id;
        }
    }

}