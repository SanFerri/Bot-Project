using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    class InvitarHandler : AbstractHandlerRespuestas
    {
        public override object Handle(IUsuario usuario, string message)
        {
            
            if(UsuarioConversacion.usuarioConversacion[usuario].conversacion[-1] == "/invitar")
            {
                Registrado.VerifyConversation(usuario, message);
                Registrado.VerifyConversation(usuario, "Respuesta_nombre");
                Console.WriteLine("Ingrese su ubicacion:");
            }
            else
            {
                return base.Handle(usuario, message);    
            }
            
        }

    }
}