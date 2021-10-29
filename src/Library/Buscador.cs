using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    public static class Buscador
    {
        public static List<Publicacion> Buscar(Residuo residuo)
        {
            List<Publicacion> ofertas = new List<Publicacion>();
            foreach(Publicacion publicacion in Mercado.mercado)
            {
                if(publicacion.residuo == residuo)
                {
                    ofertas.Add(publicacion);
                }
            }
            return ofertas;
        }
    }
}