using System.Collections.Generic;
namespace ClassLibrary
{
    public static class ListaEmpresarios
    {
        public static List<Empresario> empresarios{get; set;} = new List<Empresario>();
        public static void AddEmpresario(Empresario empresario)
        {
            empresarios.Add(empresario);
        }
        public static void RemoveEmpresario(Empresario empresario)
        {
            empresarios.Remove(empresario);
        }
    }
}


