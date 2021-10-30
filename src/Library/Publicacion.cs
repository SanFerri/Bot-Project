namespace ClassLibrary
{
    public class Publicacion
    {
        public Empresa empresa{get;set;}
        public Residuo residuo{get; set;}
        public string fecha{get; set;}
        public Ubicacion ubicacion{get; set;}
        public Publicacion(Residuo residuo, string fecha, Ubicacion ubicacion, Empresa empresa)
        {
            this.residuo = residuo;
            this.fecha = fecha;
            this.ubicacion = ubicacion;
        }
    }
}