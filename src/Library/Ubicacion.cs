using Ucu.Poo.Locations.Client;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Clase Ubicacion, esta es experta en conocer la ubicacion.
    /// </summary>
    public class Ubicacion : IJsonConvertible
    {
        /// <summary>
        /// Constructor de Ubicacion.
        /// </summary>
        [JsonConstructor]
        public Ubicacion()
        {
        }
        /// <summary>
        /// Property location, es el locación donde se encuentra la empresa.
        /// </summary>
        /// <value></value>
        public Location Location{ get; set; }

        /// <summary>
        /// Property dirección, es la diracción donde se encuentra la empresa.
        /// </summary>
        /// <value></value>
        public string Direccion{get; set;}

        /// <summary>
        /// Property LocationApiClient, es la encargada de conocer la localizacion del cliente.
        /// </summary>
        /// <value></value>
        private LocationApiClient client { get; set; }

        /// <summary>
        /// Constructor de instancia ubicación. 
        /// </summary>
        /// <param name="direccion"></param>

        public Ubicacion(string direccion)
        {
            this.Direccion = direccion;
            this.CalculateLocation();
        }

        /// <summary>
        /// Constructor de instancia CalculateLocation.
        /// </summary>
        /// <returns></returns>

        public async void CalculateLocation()
        {
            //this.Location = await client.GetLocationAsync(this.Direccion);
        }

        /// <summary>
        /// Metodo que convierte una clase en string Json (serializa).
        /// </summary>
        /// <returns></returns>
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