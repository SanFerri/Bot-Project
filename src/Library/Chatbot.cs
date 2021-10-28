using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    public class chatBot
    {
        IUsuario usuario1;
        public void MessageHandling(string message, int id)
        {
            bool registrado = false;

            foreach(IUsuario usuario in ListaUsuarios.usuarios)
            {
                if(usuario.id == id)
                {
                    registrado = true;
                    usuario1 = usuario;
                }
            }
            
            if(registrado == false)
            {
                bool eleccion = false;
                while(eleccion = false)
                {
                    Console.WriteLine("No está registrado, ingrese una invitación válida");
                    int invitacion = Convert.ToInt32(Console.ReadLine());
                    foreach(IUsuario usuario in ListaUsuarios.usuarios)
                    {
                        if(usuario.invitacion == invitacion)
                        {
                            ListaUsuarios.AddUsuario(usuario);
                            usuario.id = id;
                            eleccion = true;
                            Console.WriteLine("Se te ha registrado con exito");
                        }                                            
                    }

                } 
            }
            message.ToLower();
            char aux = message[0];
            if(aux == '/')
            {
                bool AConversacion = false;
                foreach(KeyValuePair<IUsuario,Conversacion> values in Conversacion.usuarioConversacion)
                {
                    if(values.Key == usuario1)
                    {
                        values.Value.AddMessage(message);
                        AConversacion = true;
                    }
                }
                if(AConversacion == false)
                {
                    Conversacion conversacion = new Conversacion(message);
                    conversacion.AddConversacionUsuario(usuario1, conversacion);
                    conversacion.AddMessage(message);
                }
                PublicarCommand command = new PublicarCommand();
                PublicarCommand.Do(usuario1, message);
                if(usuarioConversación[usuario1][-1][0] == '/')
                {
                     
                }

            }
        }
    }
}
