using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Lista palabras clave es una clase que contiene palabras clave que posee dos metodos AddPalabra y 
    /// RemovePalabra para añadir o remover elementos de una property de la clase llamada ListaPalabrasClave, es el encargado
    /// de llevar a cabo dichas tareas porque es el experto en conocer las palabras claves.
    /// </summary>
    public class ListaPalabrasClave
    {
        /// <summary>
        /// Property string palabras, es una lista de instancias de palabras clave
        /// que lleva el registro de las palabras clave.
        /// </summary>
        /// <returns></returns>
        public static List<string> palabras = new List<string>();
        /// <summary>
        /// AddPalabra es un metodo que se encarga de agregar palabras a la lista.
        /// </summary>
        /// <param name="palabra"></param>
        public static void AddPalabra(string palabra)
        {
            palabras.Add(palabra);
        }

        [JsonInclude]
        public IList<string> Steps { get; private set; } = new List<string>();

        /// <summary>
        /// RemovePalabra es un metodo que se encarga de eliminar palabras de la lista.
        /// </summary>
        /// <param name="palabra"></param>
        public static void RemovePalabra(string palabra)
        {
            palabras.Add(palabra);
        }

        /// <summary>
        /// ListaPalabrasClaves es una lista que se encarga de almacenar ciertas palabras para asi
        /// el empresario puede colocarlas en su publicación y el emprendedor de esta manera lograria
        /// una elección mas facil.
        /// </summary>

        public ListaPalabrasClave()
        {
            if(ListaPalabrasClave.palabras.Contains("Barato"))
            { 
            }
            else
            {
                palabras.Add("Barato");
            }
            if(ListaPalabrasClave.palabras.Contains("Envio Gratis"))
            { 
            }
            else
            {
                palabras.Add("Envio Gratis");
            }
            if(ListaPalabrasClave.palabras.Contains("Usado"))
            { 
            }
            else
            {
                palabras.Add("Usado");
            }
            if(ListaPalabrasClave.palabras.Contains("Nuevo"))
            { 
            }
            else
            {
                palabras.Add("Nuevo");
            }
        }
    }
}