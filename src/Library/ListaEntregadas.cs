using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Lista entregadas es un structurer que posee dos metodos AddPublicacion y removePublicacion
    /// para añadir o remover elementos de una property de la clase llamada ListaPublicaciones, es el encargado
    /// de llevar a cabo dichas tareas porque es el experto en conocer los residuos.
    /// </summary>
    public class ListaEntregadas
    {
        /// <summary>
        /// Property publicación, es una lista de instancias de Publicacion
        /// que lleva el registro de las publicaciones de una empresa.
        /// </summary>
        /// <returns></returns>
        public List<Publicacion> ListaPublicaciones { get; set; }

        private static ListaEntregadas _instance;

        /// <summary>
        /// AddPublicacion es un metodo que se encarga de agregar publicaciones a la lista
        /// </summary>
        /// <param name="publicacion"></param>
        public void AddPublicacion(Publicacion publicacion)
        {
            ListaPublicaciones.Add(publicacion);
        }
    

        //[JsonInclude]
        //public IList<Publicacion> Steps { get; private set; } = new List<Publicacion>();

        /// <summary>
        /// RemovePublicacion es un metodo que se encarga de eliminar publicaciones de la lista.
        /// </summary>
        /// <param name="publicacion"></param>
        public void RemovePublicacion(Publicacion publicacion)
        {
            ListaPublicaciones.Remove(publicacion);
        }
        /// <summary>
        /// Sirve para aplicar el singleton, verifica si ListaEntregadas es nula y si no es nula te 
        /// devuelve el valor de la property.
        /// </summary>
        public static ListaEntregadas GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ListaEntregadas();
            }
            return _instance;
        }
      
        /// <summary>
        /// Constructor vacio para agregarle instancias a ListaPublicaciones.
        /// </summary>
        private ListaEntregadas()
        {
            this.ListaPublicaciones = new List<Publicacion>();
        }
    }
}