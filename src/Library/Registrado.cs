using System.Collections.Generic;
namespace ClassLibrary
{
    public static class Registrado
    {
        public static void VerifyConversation(IUsuario usuario, string message)
        {
            bool AConversacion = false;
            foreach(KeyValuePair<IUsuario,Conversacion> values in Conversacion.usuarioConversacion)
            {
                if(values.Key == usuario)
                {
                    values.Value.AddMessage(message);
                    AConversacion = true;
                }
            }
            if(AConversacion == false)
            {
                Conversacion conversacion = new Conversacion(message);
                conversacion.AddConversacionUsuario(usuario, conversacion);
                conversacion.AddMessage(message);
            }
        }
    }
}