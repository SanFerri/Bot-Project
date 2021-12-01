using System;
using Ucu.Poo.Locations.Client;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Buscador es el experto en conocer las busquedas.
    /// </summary>
    public static class Buscador
    {
        private static Mercado mercado = Mercado.GetInstance();
        
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
            //DistanciaUbicacion distanciaUbicacion = new DistanciaUbicacion();
            List<Publicacion> ofertas = new List<Publicacion>();
            foreach(Publicacion publicacion in mercado.Ofertas)
            {
                if(publicacion.Residuo.Tipo == tipo & publicacion.Entregado == false)
                {
                    //distanciaUbicacion.Distancia(publicacion.Ubicacion, ubicacion);
                    //if(distanciaUbicacion.LocationsDistance < 100)
                    if(0 < 100)
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
            foreach(Publicacion publicacion in mercado.Ofertas)
            {
                if(publicacion.Constante == true)
                {
                    residuosConstantes.Add(publicacion.Residuo.Tipo);
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
            foreach(Publicacion publicacion in mercado.Ofertas)
            {
                if(publicacion.Constante == false && publicacion.Entregado == false)
                {
                    residuosPuntuales.Add(publicacion.Residuo.Tipo);
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
        public static List<Publicacion> Buscar(string palabraclave)
        {
            List<Publicacion> ofertas = new List<Publicacion>();
            foreach(Publicacion publicacion in mercado.Ofertas)
            {
                if(publicacion.PalabraClave == palabraclave && publicacion.Entregado == false)
                {
                    ofertas.Add(publicacion);
                }
            }
            return ofertas;
        }
        /// <summary>
        /// Es un metodo que te devuelve la lista de elementos entregados. Cumple el Principio de Inversión de
        /// Dependencias(DIP), debído a que depende de una abstracción de empresario, en este caso una intrefaz
        /// "IEmpresarioPublicaciones" ya que solo necesita la property publicaciones.
        /// /// </summary>
        /// <param name="publicaciones"></param>
        /// <param name="tiempo"></param>
        /// <returns></returns>

        public static List<Publicacion> Buscar(IEmpresarioPublicaciones publicaciones, int tiempo)
        {
            List<Publicacion> entregadas = new List<Publicacion>();
            foreach(Publicacion publicacion in publicaciones.LasPublicaciones.Publicaciones)
            {
                if(publicacion.Entregado == true)
                {   
                    entregadas.Add(publicacion);
                }
            }

            return entregadas;  
        }

        /// <summary>
        /// Metodo que te devuelve una lista de los residuos consumidos.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tiempo"></param>
        /// <returns></returns>
        public static List<Residuo> Buscar(int id, int tiempo)
        {
            DateTime ahora = DateTime.Now;
            List<Residuo> consumidos = new List<Residuo>();
            foreach(Publicacion publicacion in ListaEntregadas.GetInstance().ListaPublicaciones)
            {
                DateTime a = publicacion.Fecha;

                if(ahora.Subtract(a).TotalDays <=  tiempo)
                {   
                    consumidos.Add(publicacion.Residuo);
                }
            }
            
            return consumidos;  
        }

    }
}