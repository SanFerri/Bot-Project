using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// UsuarioConversacion es el experto en conocer a las Conversaciones junto a su respectivo usuario, 
    /// por ello es que se implementa con una property Dictionary, por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar y/o remover pares key(IUsuario) y value(Conversacion).
    /// </summary>
    public static  class UsuarioConversacion
    {
        /// <summary>
        /// UsuarioConversacion es una property Dictionary que recibe como parametros una key que es
        /// IUsuario, IUsuario es una interfaz aqui aplicamos la convencion de inversion de
        /// dependencia.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<IUsuario, Conversacion> usuarioConversacion{get;set;} = new Dictionary<IUsuario, Conversacion>();

        /// <summary>
        /// AddConversacionUsuario es un metodo que se encarga de agregar al diccionario
        /// usuarioConversacion una key usuario y su value conversacion, metodo designado por Expert.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="conversacion"></param>
        public static void AddConversacionUsuario(IUsuario usuario, Conversacion conversacion)
        {
            usuarioConversacion.Add(usuario, conversacion);
        }

        /// <summary>
        /// RemoveConversacionUsuario es un metodo que se encarga de remover del diccionario
        /// usuarioConversacion una key usuario y su value conversacion, metodo designado por Expert.
        /// </summary>
        public static void RemoveConversacionUsuario(IUsuario usuario)
        {
            usuarioConversacion.Remove(usuario);
        } 
    }
}
