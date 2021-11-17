/*
using System.Collections.Generic;
namespace ClassLibrary
{
    class Listas
    {
        private static string instance;
        private Listas()
        {

        }
        public static void getInstance()
        {
            if (Listas.instance == null)
            {
                //acquireThreadLock()
                if (Listas.instance == null)
                {
                    Listas.instance = new Listas()
                }
            }
            //return Listas.instance;
        }
    }
}
*/
using System;

namespace Library
{
    /// <summary>
    /// Constructor de Listas
    /// </summary>
    public class Listas
    {
        private Listas()
        {
            // Intencionalmente dejado en blanco.
        }

        private static Listas instance;

        /// <summary>
        /// Sirve para aplicar el singleton, verifica si instance es nula y si no es nula te 
        /// devuelve el valor de la property.
        /// </summary>
        /// <value></value>
        public static Listas Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Listas();
                }

                return instance;
            }
        }
    }
}