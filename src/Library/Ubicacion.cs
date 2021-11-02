using LocationApi;
using System;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Ubicacion
    {
        public Location location{ get; set; }
        public string direccion{get; set;}
        private LocationApiClient client { get; set; }

        public Ubicacion(string direccion)
        {
            this.direccion = direccion;
            this.CalculateLocation();
        }

        public async void CalculateLocation()
        {
            this.location = await client.GetLocation(this.direccion);
        }
    }
}