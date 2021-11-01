using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    class UsuarioUbicacionHandler : AbstractHandler
    {
        public override object Handle(IUsuario usuario, string message)
        {   
            if(UsuarioConversacion.usuarioConversacion[usuario].conversacion[-1] == "/ofertas")
            {
                Console.WriteLine("¿Cual es el residuo que estas buscando?");
                Registrado.VerifyConversation(usuario, "usuario_ubicacion");
            }
            else
            {
                return base.Handle(usuario, message);    
            }
            
        }

    }
}