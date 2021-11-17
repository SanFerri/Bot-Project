using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Publicación es una clase que conoce la información de empresa, residuo, la fecha
    /// y ubicación de una publicación hecha por una X empresa.
    /// </summary>
    public class Publicacion : IJsonConvertible
    {
        /// <summary>
        /// Constructor de Publicacion.
        /// </summary>
    
        [JsonConstructor]
        public Publicacion()
        {
            // Intencionalmente en blanco
        }

        /// <summary>
        /// Property empresa, es la empresa que crea la publicación.
        /// </summary>
        /// <value></value>
        public Empresa empresa{ get; set; }

        /// <summary>
        /// Property habilitación, es la habilitación que se le pide a la empresa.
        /// </summary>
        /// <value></value>
        public string habilitacion { get; set; }

        /// <summary>
        /// Property residuo, es el residuo que se esta ofertando en la publicación.
        /// </summary>
        /// <value></value>
        public Residuo residuo{ get; set; }

        /// <summary>
        /// Property ubicación, es la ubicación de donde se encuentran los residuos de la oferta.
        /// </summary>
        /// <value></value>
        public Ubicacion ubicacion{ get; set; }

        /// <summary>
        /// Property constante, indica si un residuo es constante o no.
        /// </summary>
        /// <value></value>

        public bool constante { get; set; }

        /// <summary>
        /// Property usuarioEntregado, indicar a que usuario se le entrego.
        /// </summary>
        /// <value></value>

        public int usuarioEntregado { get; set; }

        /// <summary>
        /// Property palabraClave, es una palabra clave que pudo haber sido agregada por un empresario al crear la publicacion.
        /// </summary>
        /// <value></value>
        public string palabraClave { get; set; }

        /// <summary>
        /// Fecha en la que fue creada la publicacion.
        /// </summary>
        /// <value></value>
        public DateTime fecha { get; set; }

        /// <summary>
        /// Property que indica si los residuos de una publicacion ya fueron o no entregados.
        /// </summary>
        /// <value></value>
        public bool entregado { get; set; } = false;

        /// <summary>
        /// Property idEntregado es el id de la persona que se le entrego el residuo de una publicación.
        /// </summary>
        /// <value></value>

        public int idEntregado { get; set; }

        /// <summary>
        /// Constructor de una instancia de Publicacion.
        /// </summary>
        public Publicacion(Residuo residuo, Ubicacion ubicacion, Empresa empresa, string habilitacion, bool constante)
        {
            this.constante = constante;
            this.residuo = residuo;
            this.ubicacion = ubicacion;
            this.empresa = empresa;
            this.fecha = DateTime.Now;
        }

        /// <summary>
        /// Método que se encarga de agregar palabras clave a la publicación
        /// </summary>
        /// <param name="PalabraClave"></param>
        public void AgregarPalabraClave(string PalabraClave)
        {
            this.palabraClave = PalabraClave;
        }

        /// <summary>
        /// Metodo para agregar el id del usuario al que se le entrego el residuo.
        /// </summary>
        /// <param name="id"></param>
        public void AgregarUsuarioEntregado(int id)
        {
            this.idEntregado = id;
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