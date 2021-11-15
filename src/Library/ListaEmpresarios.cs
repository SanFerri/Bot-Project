using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// ListaEmpresarios es el experto en conocer a los empresarios, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar Empresarios y/o remover Empresarios.
    /// </summary>
    public class ListaEmpresarios
    {
        /// <summary>
        /// Variable estatica empresarios, porque es una lista de instancias de Empresario
        /// que lleva un registro de todos los empresarios que hay.
        /// </summary>
        /// <returns></returns>
        private static List<Empresario> empresarios
        {            
            get
            {
                if (empresarios == null)
                {
                    empresarios = new List<Empresario>();
                }

                return empresarios;
            }
            set
            {
                empresarios = value;
            }
        }
        /// <summary>
        /// Variable estatica empresarios, porque es una lista de instancias de Empresario
        /// que lleva un registro de todos los empresarios que hay.
        /// </summary>
        /// <returns></returns>


        /// <summary>
        /// Metodo que agrega un empresario a la lista de empresarios, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="empresario"></param>
        public static void AddEmpresario(Empresario empresario)
        {
            empresarios.Add(empresario);
        }

        /// <summary>
        /// Metodo que remove un empresario a la lista de empresarios, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="empresario"></param>
        public static void RemoveEmpresario(Empresario empresario)
        {
            empresarios.Remove(empresario);
        }
        /// <summary>
        /// Constructor vacio para sumarle instancias en la clase.
        /// </summary>
        public ListaEmpresarios()
        {
        }
    }
}