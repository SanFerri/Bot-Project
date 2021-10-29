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
                    Console.WriteLine("No está registrado, ingrese una invitación si es parte de una empresa, en caso de no serlo responda con un 0");

                    if()
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
                Registrado.VerifyConversation(usuario1, message);
                PublicarCommand command = new PublicarCommand();
                PublicarCommand.Do(usuario1, message);
                if(usuarioConversación[usuario1][-1][0] == '/')
                {
                     
                }

            }
        }
    }
}
