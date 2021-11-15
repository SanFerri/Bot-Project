using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// ListaUsuario es el experto en conocer a todos los usuarios, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar y/o remover Usuarios.
    /// A su vez depende de IUsuario para agregar cualquier tipo de usuario (emprendedor,
    /// administrador o usuarios).
    /// </summary>
    public class ListaUsuarios
    {
        /// <summary>
        /// Variable estatica Usuarios, porque es una lista de instancias de Usuarios
        /// que lleva un registro de todos las usuarios que hay.
        /// </summary>
        /// <returns></returns>
        private static List<IUsuario> Usuarios
        {            
            get
            {
                if (Usuarios == null)
                {
                    Usuarios = new List<IUsuario>();
                }

                return Usuarios;
            }
            set
            {
                Usuarios = value;
            }
        }
        /// <summary>
        /// AddUsuarios es el encargado de agregar usuarios a la lista.
        /// </summary>
        /// <param name="usuario"></param>
        public static void AddUsuario(IUsuario usuario)
        {
            Usuarios.Add(usuario);
        }

        /// <summary>
        /// RemoveUsuario es el encargado de remover usuarios de la lista.
        /// </summary>
        /// <param name="usuario"></param>
        public static void RemoveUsuario(IUsuario usuario)
        {
            Usuarios.Remove(usuario);
        }
        /// <summary>
        /// Constructor vacio para agregarle instancias a la clase.
        /// </summary>
        public ListaUsuarios()
        {
        }
    }
}