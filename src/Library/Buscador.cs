using System;
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
        /// <param name="tipo"></param>
        /// <param name="ubicacion"></param>
        /// <returns></returns>
        public static List<Publicacion> Buscar(string tipo, Ubicacion ubicacion)
        {
            List<Publicacion> ofertas = new List<Publicacion>();
            foreach(Publicacion publicacion in Mercado.mercado)
            {
                if(publicacion.residuo.tipo == tipo && ubicacion.Distancia(publicacion.ubicacion) < 100)
                {
                    ofertas.Add(publicacion);
                }
            }
            return ofertas;
        }

    }
}