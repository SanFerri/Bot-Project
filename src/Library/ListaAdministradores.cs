using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// ListaAdministradores es el experto en conocer a los administradores, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar administradores y/o removerlos.
    /// </summary>
    public class ListaAdministradores
    {
        /// <summary>
        /// Variable estatica administrador, porque es una lista de instancias de administrador
        /// que lleva un registro de todos los administradores que hay.
        /// </summary>
        /// <returns></returns>

        private static List<Administrador> administradores
        {            
            get
            {
                if (administradores == null)
                {
                    administradores = new List<Administrador>();
                }

                return administradores;
            }
            set
            {
                administradores = value;
            }
        }

        /// <summary>
        /// Metodo que agrega un administrador a la lista de administradores, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="administrador"></param>
        public static void AddAdministrador(Administrador administrador)
        {
            administradores.Add(administrador);
        }

        /// <summary>
        /// Metodo que remove un administrador a la lista de administradores, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="administrador"></param>
        public static void RemoveAdministrador(Administrador administrador)
        {
            administradores.Remove(administrador);
        }
        /// <summary>
        /// Constructor vacio para sumarle instancias a la clase.
        /// </summary>
        public ListaAdministradores()
        {
        }
    }
}
