using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// ListaEmpresas es el experto en conocer a las empresas, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar Empresas y/o remover Empresas.
    /// </summary>
    public static class ListaEmpresas
    {
        /// <summary>
        /// Variable estatica empresas, porque es una lista de instancias de Empresa
        /// que lleva un registro de todos las empresas que hay.
        /// </summary>
        /// <returns></returns>
        public static List<Empresa> empresas = new List<Empresa>();

        /// <summary>
        /// AddEmpresa es un metodo que se encarga de agregar una empresa a la lista, 
        /// desginado  a esta clase por Expert.
        /// </summary>
        /// <param name="empresa"></param>
        public static void AddEmpresa(Empresa empresa)
        {
            empresas.Add(empresa);
        }

        /// <summary>
        /// RemoveEmpresa es un metodo que se encarga de eliminar una empresa de la lista.
        /// </summary>
        /// <param name="empresa"></param>
        public static void RemoveEmpresa(Empresa empresa)
        {
            empresas.Remove(empresa);
        }
    }
}