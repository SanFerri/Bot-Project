using System;
using LocationApi;
using System.Collections.Generic;
namespace ClassLibrary
{
    public static class Buscador
    {
        private static LocationApiClient client = new LocationApiClient();
        public static List<Publicacion> Buscar(string tipo, Ubicacion ubicacion)
        {
            DistanciaUbicacion distanciaUbicacion = new DistanciaUbicacion(client);
            List<Publicacion> ofertas = new List<Publicacion>();
            foreach(Publicacion publicacion in Mercado.mercado)
            {
                if(publicacion.residuo.tipo == tipo)
                {
                    distanciaUbicacion.Distancia(publicacion.ubicacion, ubicacion);
                    if(distanciaUbicacion.LocationsDistance < 100)
                    {
                        ofertas.Add(publicacion);
                    }
                }
            }
            return ofertas;
        }

    }
}