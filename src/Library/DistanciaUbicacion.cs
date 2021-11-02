namespace ClassLibrary
{
    public static class DistanciaUbicacion
    {
        
        public static int Distancia(Ubicacion ubicacion1, Ubicacion ubicacion2)
        {
            Distance distance = AsyncContext. Run(() => client.GetDistanceAsync(fromLocation, toLocation));
            Distance distance = await client.GetDistance(ubicacion1.coordenadas, ubicacion2.coordenadas);

            return distance.TravelDistance;
        }
    }
}