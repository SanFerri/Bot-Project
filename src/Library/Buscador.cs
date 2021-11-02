using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    public static class Buscador
    {
        public static List<Publicacion> Buscar(string tipo, Ubicacion ubicacion)
        {
            List<Publicacion> ofertas = new List<Publicacion>();
            foreach(Publicacion publicacion in Mercado.mercado)
            {
                if(publicacion.residuo.tipo == tipo && DistanciaUbicacion.Distancia(publicacion.ubicacion, ubicacion) < 100)
                {
                    ofertas.Add(publicacion);
                }
            }
            return ofertas;
        }

    }
}