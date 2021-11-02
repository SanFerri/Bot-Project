using LocationApi;
using Nito.AsyncEx;

namespace ClassLibrary
{
    public class Ubicacion
    {
        public Location coordenadas{get; set;}
        public string direccion{get; set;}

        public Ubicacion(string direccion)
        {
            
            LocationApiClient client = new LocationApiClient();

            Location ubicacion = await client.GetLocation(direccion);

            this.coordenadas = ubicacion;

            this.direccion = direccion;
        }
    }
}