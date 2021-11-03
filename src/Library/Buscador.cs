using System;
using LocationApi;
using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Buscador es el experto en conocer las busquedas.
    /// </summary>
    public static class Buscador
    {

        /// <summary>
        /// Variable estatica Buscar porque es una lista de instancia de publicación que lleva 
        /// el registro de todas las busquedas que hay.
        /// </summary>
        /// <returns></returns>

        private static LocationApiClient client = new LocationApiClient();

        /// <summary>
        /// Property publicacion, es una lista de instancia publicación.
        /// Lleva el registro de las publicaciones.
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="ubicacion"></param>
        /// <returns></returns>

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

        /// <summary>
        /// Property string, es una lista de instancias de List
        /// que lleva el registro de los residuos de los residuos constantes.
        /// </summary>
        /// <returns></returns>

        public static List<string> ResiduosConstantes()
        {
            List<string> residuosConstantes = new List<string>();
            foreach(Publicacion publicacion in Mercado.mercado)
            {
                if(publicacion.constante == true)
                {
                    residuosConstantes.Add(publicacion.residuo.tipo);
                }
            }
            return residuosConstantes;
        }

        /// <summary>
        /// Property string, es una lista de instancias de List
        /// que lleva el registro de los residuos de los residuos puntuales.
        /// </summary>
        /// <returns></returns>
        public static List<string> ResiduosPuntuales()
        {
            List<string> residuosPuntuales = new List<string>();
            foreach(Publicacion publicacion in Mercado.mercado)
            {
                if(publicacion.constante == false)
                {
                    residuosPuntuales.Add(publicacion.residuo.tipo);
                }
            }
            return residuosPuntuales;
        }

    }
}