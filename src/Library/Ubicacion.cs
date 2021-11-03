using LocationApi;
using System;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// Clase Ubicacion, esta es experta en conocer la ubicacion.
    /// </summary>
    public class Ubicacion
    {
        /// <summary>
        /// Property location, es el locación donde se encuentra la empresa.
        /// </summary>
        /// <value></value>
        public Location location{ get; set; }

        /// <summary>
        /// Property dirección, es la diracción donde se encuentra la empresa.
        /// </summary>
        /// <value></value>
        public string direccion{get; set;}

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
            this.direccion = direccion;
            this.CalculateLocation();
        }

        /// <summary>
        /// Constructor de instancia CalculateLocation.
        /// </summary>
        /// <returns></returns>

        public async void CalculateLocation()
        {
            this.location = await client.GetLocation(this.direccion);
        }
    }
}