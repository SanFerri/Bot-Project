using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Lista residuos es un structurer de residuo que posee dos metodos AddResiudo y removeresiduo
    /// para añadir o remover elementos de una property de la clase llamada ListaResiudo, es el encargado
    /// de llevar a cabo dichas tareas porque es el experto en conocer los residuos.
    /// </summary>
    public class ListaPalabrasClave
    {
        /// <summary>
        /// Property int residuo, es una lista de instancias de Residuo
        /// que lleva el registro de los residuos de una empresa.
        /// </summary>
        /// <returns></returns>
        public static List<string> palabras = new List<string>();
        /// <summary>
        /// AddResiduo es un metodo que se encarga de agregar residuos a la lista.
        /// </summary>
        /// <param name="residuo"></param>
        public static void AddPalabra(string palabra)
        {
            palabras.Add(palabra);
        }

        /// <summary>
        /// RemoveResiduo es un metodo que se encarga de eliminar residuos de la lista.
        /// </summary>
        /// <param name="residuo"></param>
        public static void RemovePalabra(string palabra)
        {
            palabras.Add(palabra);
        }

        public ListaPalabrasClave()
        {
            palabras.Add("Barato");
            palabras.Add("Envio Gratis");
            palabras.Add("Usado");
            palabras.Add("Nuevo");
        }
    }
}