using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public static class Registrado
    {
        public static bool VerifyUser(int id)
        {
            bool registrado = false;

            foreach(Empresario empresario in ListaEmpresarios.empresarios)
            {
                if(id == empresario.id)
                {
                    registrado = true;
                }
            }
            if(registrado == false)
            {
                foreach(IUsuario usuario1 in ListaUsuarios.usuarios)
                {
                    if(id == usuario1.id)
                    {
                        registrado = true;
                    }
                }
            }
            return registrado;
        }
        public static void VerifyConversation(IUsuario usuario, string message)
        {
            bool AConversacion = false;
            foreach(KeyValuePair<IUsuario,Conversacion> values in UsuarioConversacion.usuarioConversacion)
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
                conversacion.AddMessage(message);
                UsuarioConversacion.AddConversacionUsuario(usuario, conversacion);
            }
        }
    }
}
