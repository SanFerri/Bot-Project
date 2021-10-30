using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    class InvitarHandler : AbstractHandlerRespuestas
    {
        public override object Handle(object request)
        {
            //if (request.ToString() == "/invitar")
            if(UsuarioConversacion.usuarioConversacion[usuario1].conversacion[-1] == "/invitar")
            {
                Registrado.VerifyConversation(usuario1, message);
                Registrado.VerifyConversation(usuario1, "Respuesta_nombre");
                Console.WriteLine("Ingrese su ubicacion:");
            }
            else
            {
                return base.Handle(request);    
            }
            
        }

    }
}