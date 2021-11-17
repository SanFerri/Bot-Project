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
        private static List<Empresario> empresarios { get; set; }
        /// <summary>
        /// Variable estatica empresarios, porque es una lista de instancias de Empresario
        /// que lleva un registro de todos los empresarios que hay.
        /// </summary>
        /// <returns></returns>


        /// <summary>
        /// Metodo que agrega un empresario a la lista de empresarios, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="empresario"></param>
        public void AddEmpresario(Empresario empresario)
        {
            if(empresarios != null)
            {
                empresarios.Add(empresario);
            }
            else
            {
                this.GetInstance();
                empresarios.Add(empresario);
            }
        }

        [JsonInclude]
        public IList<Empresario> Steps { get; private set; } = new List<Empresario>();

        /// <summary>
        /// Metodo que remove un empresario a la lista de empresarios, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="empresario"></param>
        public void RemoveEmpresario(Empresario empresario)
        {
            empresarios.Remove(empresario);
        }

        /// <summary>
        /// Sirve para aplicar el singleton, verifica si empresarios es nula y si no es nula te devuelve el 
        /// valor de la property.
        /// </summary>
        /// <returns></returns>

        public List<Empresario> GetInstance()
        {
            if (empresarios == null)
            {
                empresarios = new List<Empresario>();
            }
            return empresarios;
        }

        /// <summary>
        /// Constructor vacio para sumarle instancias en la clase.
        /// </summary>
        public ListaEmpresarios()
        {
        }
    }
}