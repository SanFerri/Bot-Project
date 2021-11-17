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
        public List<Empresa> Empresas {get; set;}
        private static ListaEmpresas _instance;

        /// <summary>
        /// AddEmpresa es un metodo que se encarga de agregar una empresa a la lista, 
        /// desginado  a esta clase por Expert.
        /// </summary>
        /// <param name="empresa"></param>
        public void AddEmpresa(Empresa empresa)
        {
            if(Empresas != null)
            {
                Empresas.Add(empresa);
            }
            else
            {
                this.GetInstance();
                Empresas.Add(empresa);
            }
            this.Empresas.Add(empresa);
        }
        [JsonInclude]
        public IList<Empresa> Steps { get; private set; } = new List<Empresa>();
        /// <summary>
        /// RemoveEmpresa es un metodo que se encarga de eliminar una empresa de la lista.
        /// </summary>
        /// <param name="empresa"></param>
        public void RemoveEmpresa(Empresa empresa)
        {
            Empresas.Remove(empresa);
        }
        /// <summary>
        /// Constructor vacio para sumarle instancia a la clasica.
        /// </summary>
        private ListaEmpresas()
        {
            this.Empresas = new List<Empresa>();
        }

        /// <summary>
        /// Sirve para aplicar el singleton, verifica si empresas es nula y si no es nula te devuelve el 
        /// valor de la property.
        /// </summary>
        /// <returns></returns>
        public static ListaEmpresas GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ListaEmpresas();
            }
            return _instance;
        }
    }
}