using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// ListaEmpresas es el experto en conocer a las empresas, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar Empresas y/o remover Empresas.
    /// </summary>
    public class ListaEmpresas
    {
        /// <summary>
        /// Variable estatica empresas, porque es una lista de instancias de Empresa
        /// que lleva un registro de todos las empresas que hay.
        /// </summary>
        /// <returns></returns>
        private static List<Empresa> empresas {get; set;}
        /// <summary>
        /// Variable estatica empresas, porque es una lista de instancias de Empresa
        /// que lleva un registro de todos las empresas que hay.
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// AddEmpresa es un metodo que se encarga de agregar una empresa a la lista, 
        /// desginado  a esta clase por Expert.
        /// </summary>
        /// <param name="empresa"></param>
        public void AddEmpresa(Empresa empresa)
        {
            if(empresas != null)
            {
                empresas.Add(empresa);
            }
            else
            {
                this.GetInstance();
                empresas.Add(empresa);
            }
        }

        /// <summary>
        /// RemoveEmpresa es un metodo que se encarga de eliminar una empresa de la lista.
        /// </summary>
        /// <param name="empresa"></param>
        public void RemoveEmpresa(Empresa empresa)
        {
            empresas.Remove(empresa);
        }
        /// <summary>
        /// Constructor vacio para sumarle instancia a la clasica.
        /// </summary>
        public ListaEmpresas()
        {
        }

        public List<Empresa> GetInstance()
        {
            if (empresas == null)
            {
                empresas = new List<Empresa>();
            }
            return empresas;
        }
    }
}