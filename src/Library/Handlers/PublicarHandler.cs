using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    class PublicarHandler : AbstractHandlerRespuestas
    {
        public override object Handle(IUsuario usuario, string message)
        {
            
            if(UsuarioConversacion.usuarioConversacion[usuario].conversacion[-1] == "/publicar")
            {
                Publicacion publicacion = new Publicacion(usuario.Empresa.residuos[Convert.ToInt32(message) - 1], empresario.Empresa.ubicacion, DateTime.Now, empresario.Empresa);
                empresario.Empresa.publicaciones.AddPublicacion(publicacion);
            }
            else
            {
                return base.Handle(usuario, message);    
            }
            
        }

    }
}