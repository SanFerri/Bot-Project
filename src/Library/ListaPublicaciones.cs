using System.Collections.Generic;
namespace ClassLibrary
{
    public class ListaPublicaciones
    {
        public List<Publicacion> listaPublicaciones = new List<Publicacion>();

        /// <summary>
        /// AddPublicaciones es un metodo que se encarga de agregar publicaciones a la lista
        /// </summary>
        /// <param name="publicacion"></param>
        public void AddPublicacion(Publicacion publicacion)
        {
            listaPublicaciones.Add(publicacion);
        }

        /// <summary>
        /// RemovePublicaciones es un metodo que se encarga de eliminar publicaciones de la lista.
        /// </summary>
        /// <param name="publicacion"></param>
        public void RemovePublicacion(Publicacion publicacion)
        {
            listaPublicaciones.Remove(publicacion);
        }
    }
}