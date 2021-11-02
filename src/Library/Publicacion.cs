namespace ClassLibrary
{
    /// <summary>
    /// Publicacion es una clase que conoce la informacion de empresa, residuo, la fecha
    /// y ubicacion de una publicacion hecha por una X empresa.
    /// </summary>
    public class Publicacion
    {
        /// <summary>
        /// Property empresa, es la empresa que crea la publicacion.
        /// </summary>
        /// <value></value>
        public Empresa empresa{get;set;}

        /// <summary>
        /// Property residuo, es el residuo que se esta ofertando en la publicacion.
        /// </summary>
        /// <value></value>
        public Residuo residuo{get; set;}

        /// <summary>
        /// Property ubicacion, es la ubicacion de donde se encuentran los residuos de la oferta.
        /// </summary>
        /// <value></value>
        public Ubicacion ubicacion{get; set;}

        /// <summary>
        /// Constructor de una instancia de Publicacion.
        /// </summary>
        public Publicacion(Residuo residuo, Ubicacion ubicacion, Empresa empresa)
        {
            this.residuo = residuo;
            this.ubicacion = ubicacion;
            this.empresa = empresa;
        }
    }
}