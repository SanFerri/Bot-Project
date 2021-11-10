using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Lista publicaciones es un structurer de publicación que posee dos metodos AddPublicacion y removePublicacion
    /// para añadir o remover elementos de una property de la clase llamada ListaPublicaciones, es el encargado
    /// de llevar a cabo dichas tareas porque es el experto en conocer los residuos.
    /// </summary>
    public static class ListaPublicacionesEntregados
    {
        /// <summary>
        /// Property publicación, es una lista de instancias de Publicacion
        /// que lleva el registro de las publicaciones de una empresa.
        /// </summary>
        /// <returns></returns>
        public static List<Publicacion> listaPublicaciones = new List<Publicacion>();

        /// <summary>
        /// AddPublicacion es un metodo que se encarga de agregar publicaciones a la lista
        /// </summary>
        /// <param name="publicacion"></param>
        public static void AddPublicacion(Publicacion publicacion)
        {
            listaPublicaciones.Add(publicacion);
        }

        /// <summary>
        /// RemovePublicacion es un metodo que se encarga de eliminar publicaciones de la lista.
        /// </summary>
        /// <param name="publicacion"></param>
        public static void RemovePublicacion(Publicacion publicacion)
        {
            listaPublicaciones.Remove(publicacion);
        }
    }
}