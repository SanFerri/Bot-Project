using System.Collections.Generic;
namespace ClassLibrary
{
    public static class ListaEmpresas
    {
        public static List<Empresa> listaEmpresas = new List<Empresa>();

        /// <summary>
        /// AddEmpresa es un metodo que se encarga de agregar empresas a la lista.
        /// </summary>
        /// <param name="empresa"></param>
        public static void AddEmpresa(Empresa empresa)
        {
            listaEmpresas.Add(empresa);
        }

        /// <summary>
        /// RemoveEmpresa es un metodo que se encarga de eliminar empresas de la lista.
        /// </summary>
        /// <param name="empresa"></param>
        public static void RemoveEmpresa(Empresa empresa)
        {
            listaEmpresas.Remove(empresa);
        }
    }
}