using System.Collections.Generic;
namespace ClassLibrary
{
    public static class Mercado
    {
        public static List<Publicacion> mercado = new List<Publicacion>();
        public static void AddMercado(Publicacion publicacion)
        {
            mercado.Add(publicacion);
        }
        public static void RemoveMercado(Publicacion publicacion)
        {
            mercado.Remove(publicacion);
        }
    }
}