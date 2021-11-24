using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// ListaPalabrasClave es una clase que contiene palabras clave que posee dos metodos AddPalabra y 
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
        public List<string> Palabras = new List<string>();

        private static ListaPalabrasClave _instance;

        /// <summary>
        /// AddPalabra es un metodo que se encarga de agregar palabras a la lista.
        /// </summary>
        /// <param name="palabra"></param>
        public void AddPalabra(string palabra)
        {
            this.Palabras.Add(palabra);
        }

        //[JsonInclude]
        //public IList<string> Steps { get; private set; } = new List<string>();

        /// <summary>
        /// RemovePalabra es un metodo que se encarga de eliminar palabras de la lista.
        /// </summary>
        /// <param name="palabra"></param>
        public void RemovePalabra(string palabra)
        {
            this.Palabras.Add(palabra);
        }

        /// <summary>
        /// ListaPalabrasClaves es una lista que se encarga de almacenar ciertas palabras para asi
        /// el empresario puede colocarlas en su publicación y el emprendedor de esta manera lograria
        /// una elección mas facil.
        /// </summary>

        public static ListaPalabrasClave GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ListaPalabrasClave();
            }
            return _instance;
        }

        [JsonConstructor]
        private ListaPalabrasClave()
        {
            if(this.Palabras.Contains("Barato"))
            { 
            }
            else
            {
                Palabras.Add("Barato");
            }
            if(this.Palabras.Contains("Envio Gratis"))
            { 
            }
            else
            {
                Palabras.Add("Envio Gratis");
            }
            if(this.Palabras.Contains("Usado"))
            { 
            }
            else
            {
                this.Palabras.Add("Usado");
            }
            if(this.Palabras.Contains("Nuevo"))
            { 
            }
            else
            {
                this.Palabras.Add("Nuevo");
            }
        }
    }
}