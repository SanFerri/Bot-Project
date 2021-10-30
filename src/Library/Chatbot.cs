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
                    Registrado.VerifyConversation(usuario1, "previoInvitacion");
                    if(UsuarioConversacion.usuarioConversacion[usuario1][-1] == "previoInvitacion")
                    {
                        foreach(Empresario usuario in ListaEmpresarios.empresarios)
                        {
                            if(usuario.invitacion == invitacion)
                            {
                                ListaEmpresarios.AddUsuario(usuario);
                                usuario.id = id;
                                eleccion = true;
                                Console.WriteLine("Se te ha registrado con exito");
                            }                                            
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
                command.Do(usuario1, message);
                if(UsuarioConversacion.usuarioConversacion[usuario1].conversacion[-1][0] == '/')
                {
                     
                }
            }
            else
            {
                if(UsuarioConversacion.usuarioConversacion[usuario1].conversacion[-1] == "/ofertas")
                {
                    List<Publicacion> ofertas = Buscador.Buscar(message);
                    Registrado.VerifyConversation(usuario1, message);
                    Registrado.VerifyConversation(usuario1, "resputaofertas");
                    int contador = 0;
                    foreach(Publicacion publicacion1 in ofertas)
                    {
                        Console.WriteLine($"{contador}. {publicacion1.residuo.cantidad} Kg de {publicacion1.residuo.tipo} en {publicacion1.ubicacion} \n Ingrese el numero de la publicacion que quiere ver.");
                        contador += 1;
                    }
                }
                else if(UsuarioConversacion.usuarioConversacion[usuario1].conversacion[-1] == "respuestaofertas")
                {
                    string buscado = UsuarioConversacion.usuarioConversacion[usuario1].conversacion[-2];
                    List<Publicacion> ofertas = Buscador.Buscar(buscado);
                    Publicacion publicacion = ofertas[Convert.ToInt32(message)];
                    Console.WriteLine($"Dicha publicacion le pertenece a la empresa {publicacion.empresa.nombre}, este es el contacto: {publicacion.empresa.contacto}");
                }
            }
        }
    }
}