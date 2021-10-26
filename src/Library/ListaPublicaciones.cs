using System.Collections.Generic;
namespace ClassLibrary
{
    public class ListaPublicaciones
    {
        public List<Publicacion> publicaciones{get; set;} = new List<Publicacion>();
        public void AddPublicacion(Publicacion publicacion)
        {
            publicaciones.Add(publicacion);
        }
        public void RemovePublicacion(Publicacion publicacion)
        {
            publicaciones.Remove(publicacion);
        }
    }
}


