using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    public static class Buscador
    {
        public static List<Publicacion> Buscar(string tipo)
        {
            List<Publicacion> ofertas = new List<Publicacion>();
            foreach(Publicacion publicacion in Mercado.mercado)
            {
                if(publicacion.residuo.tipo == tipo)
                {
                    ofertas.Add(publicacion);
                }
            }
            return ofertas;
        }
    }
}