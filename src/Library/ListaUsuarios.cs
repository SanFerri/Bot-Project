using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// ListaUsuarios es el experto en conocer a todos los Usuario, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar y/o remover Usuario.
    /// A su vez depende de IUsuario para agregar cualquier tipo de usuario (emprendedor,
    /// administrador o Usuario).
    /// </summary>
    public class ListaUsuarios
    {
        /// <summary>
        /// Variable estatica Usuario, porque es una lista de instancias de Usuario
        /// que lleva un registro de todos las Usuario que hay.
        /// </summary>
        /// <returns></returns>
        public List<IUsuario> Usuarios {get; set;}
        private static ListaUsuarios _instance;

        /// <summary>
        /// AddUsuario es el encargado de agregar Usuario a la lista.
        /// </summary>
        /// <param name="usuario"></param>
        public void AddUsuario(IUsuario usuario)
        {
            Usuarios.Add(usuario);
        }

        [JsonInclude]
        public IList<IUsuario> Steps { get; private set; } = new List<IUsuario>();

        /// <summary>
        /// RemoveUsuario es el encargado de remover Usuario de la lista.
        /// </summary>
        /// <param name="usuario"></param>
        public void RemoveUsuario(IUsuario usuario)
        {
            Usuarios.Remove(usuario);
        }
        /// <summary>
        /// Constructor vacio para agregarle instancias a la clase.
        /// </summary>
        private ListaUsuarios()
        {
            this.Usuarios = new List<IUsuario>();
        }

        /// <summary>
        /// Sirve para aplicar el singleton, verifica si usuarios es nula y si no es nula te devuelve el 
        /// valor de la property.
        /// </summary>
        /// <returns></returns>
        public static ListaUsuarios GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ListaUsuarios();
            }
            return _instance;
        }
    }
}