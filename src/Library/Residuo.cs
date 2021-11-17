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

        [JsonConstructor]
        public Residuo()
        {
            // Intencionalmente en blanco
        }

        /// <summary>
        /// Es el encargado de conocer el tipo de material que se esta ofreciendo.
        /// </summary>
        /// <value></value>
        public string tipo{get; set;}
        /// <summary>
        /// Es el encargado de conocer la cantidad que hay de cada material.
        /// </summary>
        /// <value></value>
        public int cantidad{get; set;}

        /// <summary>
        /// Es el encargado de conocer la unidad de la cual se esta haciendo referencia, por ejemplo 
        /// (kg, toneladas, etc).
        /// </summary>
        /// <value></value>
        public string unidad { get; set; }

        /// <summary>
        /// Es el encargado de conocer el costo del residuo.
        /// </summary>
        /// <value></value>

        public int cost { get; set; }

        /// <summary>
        /// Es el encargado de conocer la moneda con la cual se va a hacer el medio de pago, por ejemplo
        /// (pesos uruguayos, dolares, euros, etc.)
        /// </summary>
        /// <value></value>
        public string moneda { get; set; }
    
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
            this.tipo = tipo;
            this.cantidad = cantidad;
            this.unidad = unidad;
            this.cost = cost;
            this.moneda = moneda;
        }

        public string ConvertToJson()
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = MyReferenceHandler.Instance,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(this, options);
        }
        
    }
}