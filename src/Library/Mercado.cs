using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace ClassLibrary
{
    /// <summary>
    /// La clase mercado es estatica porque el esta conoce todas las publicaciones
    /// existentes, independientemente de a que empresa pertenezcan. Como esta es
    /// la experta en la informacion de todas las publicaciones tambien es la
    /// encargada a través de sus 2 metodo Add y Remove Mercado de agregar o remover publicaciones.
    /// </summary>
    public class Mercado : IJsonConvertible
    {
        /// <summary>
        /// Property oferta, es una lista que contiene publicaciones.
        /// </summary>
        /// <value></value>
        public List<Publicacion> Ofertas {get; set;}

        private static Mercado _instance;
        /// <summary>
        /// AddMercado, metodo para agregar publicaciones al mercado, designado por Expert.
        /// </summary>
        /// <param name="publicacion"></param>
        public void AddMercado(Publicacion publicacion)
        {
            if(this.Ofertas.Contains(publicacion))
            {
            }
            else
            {
                this.Ofertas.Add(publicacion);
            }
        }

        //[JsonInclude]
        //public IList<Publicacion> Steps { get; private set; } = new List<Publicacion>();

        /// <summary>
        /// RemoveMercado, metodo para remover publicaciones al mercado, designado por Expert.
        /// </summary>
        /// <param name="publicacion"></param>
        public void RemoveMercado(Publicacion publicacion)
        {
            this.Ofertas.Remove(publicacion);
        }

        [JsonConstructor]
        /// <summary>
        /// Constructor vacio para agregarle instancias a la clase.
        /// </summary>
        private Mercado()
        {
            this.Ofertas = new List<Publicacion>();
        }

        /// <summary>
        /// Sirve para serializar la clase y todas sus property.
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }

        public void LoadFromJson(string json)
        {
            Mercado deserialized = JsonSerializer.Deserialize<Mercado>(json);
            this.Ofertas = deserialized.Ofertas;
        }

        /// <summary>
        /// Sirve para aplicar el singleton, verifica si mercado es nula y si no es nula te devuelve el 
        /// valor de la property.
        /// </summary>
        /// <returns></returns>
        public static Mercado GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Mercado();
            }
            return _instance;
        }
    }
}