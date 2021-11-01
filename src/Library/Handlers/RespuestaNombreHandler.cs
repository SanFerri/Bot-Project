using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    class RespuestaNombreHandler : AbstractHandler
    {
        public override object Handle(IUsuario usuario, string message)
        {   
            if(UsuarioConversacion.usuarioConversacion[usuario].conversacion[-1] == "Respuesta_nombre")
            {
                Registrado.VerifyConversation(usuario, message);
                Registrado.VerifyConversation(usuario, "Repuesta_ubicacion");
                Console.WriteLine("Ingrese el contacto");
            }
            else
            {
                return base.Handle(usuario, message);    
            }
            
        }

    }
}