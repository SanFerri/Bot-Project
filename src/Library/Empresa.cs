using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Empresa es una clase que conoce la información de las empresas, el nombre, la ubicación, el
    /// contacto, los residuos, sus publicaciones y a el empresario.
    /// </summary>
    public class Empresa : IJsonConvertible
    {
        /// <summary>
        /// Constructor de Empresa.
        /// </summary>

        [JsonConstructor]
        public Empresa()
        {
            // Intencionalmente en blanco
        }
        /// <summary>
        /// Property nombre, es el nombre que tiene la empresa.
        /// </summary>
        /// <value></value>
        public string Nombre{ get;set; }
        
        /// <summary>
        /// Property ubicacion, es la ubicación donde se encuentra la empresa. 
        /// </summary>
        /// <value></value>
        public Ubicacion Ubicacion{get;set;}
        
        /// <summary>
        /// Property contacto, es el contacto de la empresa.
        /// </summary>
        /// <value></value>
        public string Contacto{get;set;}
        
        /// <summary>
        /// Es la lista de residuos que lleva el registro de todos los residuos que tiene la empresa 
        /// publicados.
        /// </summary>
        /// <returns></returns>
        public ListaResiduos Residuos{get;set;} = new ListaResiduos();
        
        /// <summary>
        /// Es la lista que lleva el registro de todas las publicaciones que tiene la empresa
        /// realizadas. 
        /// </summary>
        /// <returns></returns>
        public ListaPublicaciones Publicaciones{get;set;} = new ListaPublicaciones();
        
        /// <summary>
        /// Property empresario, es el encargado de la empresa. 
        /// </summary>
        /// <value></value>
        public Empresario Empresario{get;set;}
        /// <summary>
        /// Constructor de una instancia de Empresa.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="ubicacion"></param>
        /// <param name="contacto"></param>
        public Empresa(string nombre, Ubicacion ubicacion, string contacto)
        {
            this.Nombre = nombre;
            this.Contacto = contacto;
            this.Ubicacion = ubicacion;
            ListaEmpresas LasEmpresas = ListaEmpresas.GetInstance();
            LasEmpresas.AddEmpresa(this);
        }

        /// <summary>
        /// Metodo que convierte una clase en string Json (serializa).
        /// </summary>
        /// <returns></returns>
        public string ConvertToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}