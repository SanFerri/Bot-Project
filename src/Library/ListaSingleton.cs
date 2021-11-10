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
    public class Listas
    {
        private Listas()
        {
            // Intencionalmente dejado en blanco.
        }

        private static Listas instance;

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