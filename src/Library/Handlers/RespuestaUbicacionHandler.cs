using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    class RespuestaUbicacionHandler : AbstractHandler
    {
        public override object Handle(IUsuario usuario, string message)
        {   
            if(UsuarioConversacion.usuarioConversacion[usuario].conversacion[-1] == "Respuesta_ubicacion")
            {
                int contacto = Convert.ToInt32(message);
                string nombre = UsuarioConversacion.usuarioConversacion[usuario].conversacion[-4];
                Ubicacion ubicacion = new Ubicacion(Convert.ToInt32(UsuarioConversacion.usuarioConversacion[usuario].conversacion[-2]));
                Empresa empresa = new Empresa(nombre, contacto, ubicacion);
            }
            else
            {
                return base.Handle(usuario, message);    
            }
        }

    }
}