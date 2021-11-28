using Ucu.Poo.Locations.Client;
using System;
using System.Threading.Tasks;

namespace ClassLibrary
{
    /// <summary>
    /// DistanciaUbicacion es una clase que conoce las distancias.
    /// </summary>
    public class DistanciaUbicacion
    {
        private LocationApiClient client = new LocationApiClient();

        /// <summary>
        /// Property LocationDistance, es la distancia que se ingresa.
        /// </summary>
        /// <value></value>
        public double LocationsDistance { get; private set; }

        /// <summary>
        /// Constructor de una instancia de DistanciaUbicacion.
        /// </summary>
        /// <param name="client"></param>

        public DistanciaUbicacion()
        {
        }
        /// <summary>
        /// Constructor de una instancia de distancia.
        /// </summary>
        /// <param name="ubicacion1"></param>
        /// <param name="ubicacion2"></param>
        /// <returns></returns>
        public async void Distancia(Ubicacion ubicacion1, Ubicacion ubicacion2)
        {
            Distance distance = await client.GetDistanceAsync(ubicacion1.Location, ubicacion2.Location);

            double result = distance.TravelDistance;

            this.LocationsDistance = result;
        }
    }
}