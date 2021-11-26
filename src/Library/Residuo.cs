using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary

{
    /// <summary>
    /// Residuo es una clase que conoce la informacion de los residuos publicados, el tipo y la cantidad
    /// de una publicacion hecha por una X empresa.
    /// </summary>
    public class Residuo : IJsonConvertible
    {
        /// <summary>
        /// Constructor de Residuo.
        /// </summary>

        [JsonConstructor]
        public Residuo()
        {
            // Intencionalmente en blanco
        }

        /// <summary>
        /// Es el encargado de conocer el tipo de material que se esta ofreciendo.
        /// </summary>
        /// <value></value>
        public string Tipo{get; set;}
        /// <summary>
        /// Es el encargado de conocer la cantidad que hay de cada material.
        /// </summary>
        /// <value></value>
        public int Cantidad{get; set;}

        /// <summary>
        /// Es el encargado de conocer la unidad de la cual se esta haciendo referencia, por ejemplo 
        /// (kg, toneladas, etc).
        /// </summary>
        /// <value></value>
        public string Unidad { get; set; }

        /// <summary>
        /// Es el encargado de conocer el costo del residuo.
        /// </summary>
        /// <value></value>

        public int Cost { get; set; }

        /// <summary>
        /// Es el encargado de conocer la moneda con la cual se va a hacer el medio de pago, por ejemplo
        /// (pesos uruguayos, dolares, euros, etc.)
        /// </summary>
        /// <value></value>
        public string Moneda { get; set; }
    
        /// <summary>
        /// Constructor de una instancia de Residuo.
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="cantidad"></param>
        /// <param name="unidad"></param>
        /// <param name="cost"></param>
        /// <param name="moneda"></param>
        public Residuo(string tipo, int cantidad, string unidad, int cost, string moneda)
        {
            this.Tipo = tipo;
            this.Cantidad = cantidad;
            this.Unidad = unidad;
            this.Cost = cost;
            this.Moneda = moneda;
        }

        /// <summary>
        /// Sirve para serializar la clase y todas sus property.
        /// </summary>
        /// <returns></returns>

        /// <summary>
        /// Metodo que convierte una clase en string Json (serializa).
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
        
    }
}