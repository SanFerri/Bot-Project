using System.Collections.Generic;
namespace ClassLibrary
{
    public static class ListaUsuarios
    {
        public static List<IUsuario> usuarios{get;set;} = new List<IUsuario>();
        public static void AddUsuario(IUsuario usuario)
        {
            usuarios.Add(usuario);
        }

        public static void RemoveUsuario(IUsuario usuario)
        {
            usuarios.Remove(usuario);
        }
    }
}