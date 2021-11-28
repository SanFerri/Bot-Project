using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// PosiblesResiduos es el experto en conocer a las Residuos, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar Residuos y/o remover Residuos.
    /// </summary>
    public class PosiblesResiduos
    {
        /// <summary>
        /// Variable estatica Residuos, porque es una lista de instancias de Empresa
        /// que lleva un registro de todos las Residuos que hay.
        /// </summary>
        /// <returns></returns>
        public List<string> Residuos {get; set;}
        private static PosiblesResiduos _instance;

        /// <summary>
        /// AddEmpresa es un metodo que se encarga de agregar una empresa a la lista, 
        /// desginado  a esta clase por Expert.
        /// </summary>
        /// <param name="residuo"></param>
        public void AddResiduo(string residuo)
        {
            Residuos.Add(residuo);
        }
        //[JsonInclude]
        //public IList<Empresa> Steps { get; private set; } = new List<Empresa>();
        /// <summary>
        /// RemoveEmpresa es un metodo que se encarga de eliminar una empresa de la lista.
        /// </summary>
        /// <param name="residuo"></param>
        public void RemoveResiduo(string residuo)
        {
            Residuos.Remove(residuo);
        }
        
        /// <summary>
        /// Constructor vacio para sumarle instancia a la clasica.
        /// </summary>
        private PosiblesResiduos()
        {
            this.Residuos = new List<string>{"Metal", "Plastico (PET)", "Madera", "Goma", "Aluminio", "Cobre", "Nylon", "Papel", "Algodon", "Cuero", "Tela", "Fibra", "Organico", "Cables", "Pintura", "Carbon", "Componentes Electronicos", "Otros"};
        }

        /// <summary>
        /// Sirve para aplicar el singleton, verifica si Residuos es nula y si no es nula te devuelve el 
        /// valor de la property.
        /// </summary>
        /// <returns></returns>
        public static PosiblesResiduos GetInstance()
        {
            if (_instance == null)
            {
                _instance = new PosiblesResiduos();
            }
            return _instance;
        }
    }
}