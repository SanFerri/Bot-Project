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
        private static LocationApiClient client = new LocationApiClient();
        
        /// <summary>
        /// Variable estatica Buscar porque es una lista de instancia de publicación que lleva 
        /// el registro de todas las busquedas que hay.
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
        /// Variable estatica ResiduosConstantes porque es una lista de instancia de string que lleva
        /// el registro de todos los residuos en publicacion cuya property constante devuelve true.
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
        /// Variable estatica ResiduosPuntuales porque es una lista de instancia de string que lleva
        /// el registro de todos los residuos en publicacion cuya property constante devuelve false.
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
        /// <summary>
        /// Variable estatica BuscarConPalabraClave porque es una lista de instancia de publicación que lleva 
        /// el registro de todas las busquedas que hay con la palabra clave otorgada como parametro.
        /// </summary>
        /// <param name="palabraclave"></param>
        /// <returns></returns>
        public static List<Publicacion> BuscarConPalabraClave(string palabraclave)
        {
            List<Publicacion> ofertas = new List<Publicacion>();
            foreach(Publicacion publicacion in Mercado.mercado)
            {
                if(publicacion.palabraClave == palabraclave)
                {
                    ofertas.Add(publicacion);
                }
            }
            return ofertas;
        }


    }
}