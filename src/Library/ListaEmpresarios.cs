using System.Collections.Generic;
namespace ClassLibrary
{
    public class ListaEmpresarios
    {
        public List<Empresario> empresarios{get; set;} = new List<Empresario>();
        public void AddEmpresario(Empresario empresario)
        {
            empresarios.Add(empresario);
        }
        public void RemoveEmpresario(Empresario empresario)
        {
            empresarios.Remove(empresario);
        }
    }
}


