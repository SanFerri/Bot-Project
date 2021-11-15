using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// ListaEmpresarios es el experto en conocer a los empresarios, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar Empresarios y/o remover Empresarios.
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
        /// Metodo que agrega un empresario a la lista de empresarios, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="administrador"></param>
        public static void AddAdministrador(Administrador administrador)
        {
            administradores.Add(administrador);
        }

        /// <summary>
        /// Metodo que remove un empresario a la lista de empresarios, desginado a esta clase por Expert.
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
