using LocationApi;
using System;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DistanciaUbicacion
    {
        private LocationApiClient client;
        public double LocationsDistance { get; private set; }

        public DistanciaUbicacion(LocationApiClient client)
        {
            this.client = client;
        }
        
        public async void Distancia(Ubicacion ubicacion1, Ubicacion ubicacion2)
        {
            Distance distance = await client.GetDistance(ubicacion1.location, ubicacion2.location);

            double result = distance.TravelDistance;

            this.LocationsDistance = result;
        }
    }
}