using System.Collections.Generic;
namespace ClassLibrary
{
    public static  class UsuarioConversacion
    {
        public static Dictionary<IUsuario, Conversacion> usuarioConversacion{get;set;} = new Dictionary<IUsuario, Conversacion>();

        public static void AddConversacionUsuario(IUsuario usuario, Conversacion conversacion)
        {
            usuarioConversacion.Add(usuario, conversacion);
        }

        public static void RemoveConversacionUsuario(IUsuario usuario)
        {
            usuarioConversacion.Remove(usuario);
        } 
    }
}
