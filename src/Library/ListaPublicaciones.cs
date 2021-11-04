using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Lista publicaciones es un structurer de publicación que posee dos metodos AddPublicacione y removePublicaciones
    /// para añadir o remover elementos de una property de la clase llamada ListaPublicaciones, es el encargado
    /// de llevar a cabo dichas tareas porque es el experto en conocer los residuos.
    /// </summary>
    public class ListaPublicaciones
    {
        /// <summary>
        /// Property publicación, es una lista de instancias de Publicacion
        /// que lleva el registro de las publicaciones de una empresa.
        /// </summary>
        /// <returns></returns>
        public List<Publicacion> listaPublicaciones = new List<Publicacion>();

        /// <summary>
        /// AddPublicacion es un metodo que se encarga de agregar publicaciones a la lista.
        /// Aplicando Creator hemos decidido que la clase que contiene publicaciones deberia ser quien las cree
        /// no otra clase como program que no esta tan relacionada con ella.
        /// </summary>
        /// <param name="publicacion"></param>
        public Publicacion AddPublicacion(Residuo residuo, Ubicacion ubicacion, Empresa empresa, string habilitacion, bool constante)
        {
            Publicacion publicacion = new Publicacion(residuo, ubicacion, empresa, habilitacion, constante);
            listaPublicaciones.Add(publicacion);
            return publicacion;
        }

        /// <summary>
        /// RemovePublicacion es un metodo que se encarga de eliminar publicaciones de la lista.
        /// </summary>
        /// <param name="publicacion"></param>
        public void RemovePublicacion(Publicacion publicacion)
        {
            listaPublicaciones.Remove(publicacion);
        }
    }
}