using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// La clase mercado es estatica porque el esta conoce todas las publicaciones
    /// existentes, independientemente de a que empresa pertenezcan. Como esta es
    /// la experta en la informacion de todas las publicaciones tambien es la
    /// encargada a través de sus 2 metodo Add y Remove Mercado de agregar o remover publicaciones.
    /// </summary>
    public class Mercado
    {
        public List<Publicacion> ofertas {get; set;}

        private static Mercado _instance;
        /// <summary>
        /// AddMercado, metodo para agregar publicaciones al mercado, designado por Expert.
        /// </summary>
        /// <param name="publicacion"></param>
        public void AddMercado(Publicacion publicacion)
        {
            this.ofertas.Add(publicacion);
        }

        [JsonInclude]
        public IList<Publicacion> Steps { get; private set; } = new List<Publicacion>();

        /// <summary>
        /// RemoveMercado, metodo para remover publicaciones al mercado, designado por Expert.
        /// </summary>
        /// <param name="publicacion"></param>
        public void RemoveMercado(Publicacion publicacion)
        {
            this.ofertas.Remove(publicacion);
        }
        /// <summary>
        /// Constructor vacio para agregarle instancias a la clase.
        /// </summary>
        private Mercado()
        {
            this.ofertas = new List<Publicacion>();
        }

        /// <summary>
        /// Sirve para aplicar el singleton, verifica si mercado es nula y si no es nula te devuelve el 
        /// valor de la property.
        /// </summary>
        /// <returns></returns>
        public static Mercado GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Mercado();
            }
            return _instance;
        }
    }
}