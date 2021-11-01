using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    class InvitarHandler : AbstractHandler
    {
        public override object Handle(string message, out string response, IUsuario usuario)
        {
            if(usuario != "administrador")
            {
                return "usted no tiene autorización para realizar este comando";
            }
            if(message == "/invitar")
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