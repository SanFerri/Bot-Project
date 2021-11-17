using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Lista publicaciones es un structurer de publicación que posee dos metodos AddPublicacion y removePublicacion
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
        private static List<Publicacion> listaPublicaciones { get; set; }
        /// <summary>
        /// AddPublicacion es un metodo que se encarga de agregar publicaciones a la lista
        /// </summary>
        /// <param name="publicacion"></param>
        public void AddPublicacion(Publicacion publicacion)
        {
            if(publicacion.entregado == true && listaPublicaciones != null)
            {
                listaPublicaciones.Add(publicacion);
            }
            else
            {
                this.GetInstance();
                listaPublicaciones.Add(publicacion);
            }
        
        }

        [JsonInclude]
        public IList<Publicacion> Steps { get; private set; } = new List<Publicacion>();

        /// <summary>
        /// RemovePublicacion es un metodo que se encarga de eliminar publicaciones de la lista.
        /// </summary>
        /// <param name="publicacion"></param>
        public void RemovePublicacion(Publicacion publicacion)
        {
            listaPublicaciones.Remove(publicacion);
        }
        /// <summary>
        /// Constructor vacio para agregarle instancias a la clase.
        /// </summary>
        public List<Publicacion> GetInstance()
        {
            if (listaPublicaciones == null)
            {
                listaPublicaciones = new List<Publicacion>();
            }
            return listaPublicaciones;
        }

        public ListaEntregadas()
        {
        }
    }
}