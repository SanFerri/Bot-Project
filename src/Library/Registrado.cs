using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public static class Registrado
    {
        public static void VerifyUser(IUsuario usuario, string message)
        {
            bool registrado = false;

            foreach(Empresario usuario1 in ListaEmpresarios.empresarios)
            {
                if(usuario.id == usuario1.id)
                {
                    registrado = true;
                    usuario = usuario1;
                }
            }
            if(registrado == false)
            {
                foreach(IUsuario usuario1 in ListaUsuarios.usuarios)
                {
                    if(usuario.id == usuario1.id)
                    {
                        registrado = true;
                        usuario = usuario1;
                    }
                }
            }
            
            if(registrado == false)
            {
                bool eleccion = false;
                    Console.WriteLine("No está registrado, ingrese una invitación si es parte de una empresa, en caso de no serlo responda con un no");
                    Registrado.VerifyConversation(usuario, "previoInvitacion");
                    while(eleccion = false)
                    {
                        if(UsuarioConversacion.usuarioConversacion[usuario].conversacion[-1] == "previoInvitacion")
                        {
                            foreach(Empresario usuario1 in ListaEmpresarios.empresarios)
                            {
                                if(usuario1.invitacion == Convert.ToInt32(message))
                                {
                                    usuario1.id = usuario.id;
                                    eleccion = true;
                                    Console.WriteLine("Se te ha registrado con exito");
                                }                                            
                            }
                        }
                    } 
            }
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
