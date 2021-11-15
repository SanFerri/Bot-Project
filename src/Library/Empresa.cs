namespace ClassLibrary
{
    /// <summary>
    /// Empresa es una clase que conoce la información de las empresas, el nombre, la ubicación, el
    /// contacto, los residuos, sus publicaciones y a el empresario.
    /// </summary>
    public class Empresa
    {
        /// <summary>
        /// Property nombre, es el nombre que tiene la empresa.
        /// </summary>
        /// <value></value>
        public string nombre{get;set;}
        
        /// <summary>
        /// Property ubicacion, es la ubicación donde se encuentra la empresa. 
        /// </summary>
        /// <value></value>
        public Ubicacion ubicacion{get;set;}
        
        /// <summary>
        /// Property contacto, es el contacto de la empresa.
        /// </summary>
        /// <value></value>
        public string contacto{get;set;}
        
        /// <summary>
        /// Es la lista de residuos que lleva el registro de todos los residuos que tiene la empresa 
        /// publicados.
        /// </summary>
        /// <returns></returns>
        public ListaResiduos residuos{get;set;} = new ListaResiduos();
        
        /// <summary>
        /// Es la lista que lleva el registro de todas las publicaciones que tiene la empresa
        /// realizadas. 
        /// </summary>
        /// <returns></returns>
        public ListaPublicaciones publicaciones{get;set;} = new ListaPublicaciones();
        
        /// <summary>
        /// Property empresario, es el encargado de la empresa. 
        /// </summary>
        /// <value></value>

        public Empresario empresario{get;set;}
        /// <summary>
        /// Constructor de una instancia de Empresa.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="ubicacion"></param>
        /// <param name="contacto"></param>
        public Empresa(string nombre, Ubicacion ubicacion, string contacto)
        {
            this.nombre = nombre;
            this.contacto = contacto;
            this.ubicacion = ubicacion;
        }
    }
}