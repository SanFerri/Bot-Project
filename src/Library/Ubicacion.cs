using PII_LocationApiClient;
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
        public int Distancia(Ubicacion ubicacion)
        {
            Distance distance = await client.GetDistance(this.coordenadas, ubicacion.coordenadas);

            return distance.TravelDistance;

        }
    }
}