using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    class PublicarHandler : AbstractHandlerRespuestas 
    {
        public override object Handle(Empresario empresario, string message)
        {
            
            if(UsuarioConversacion.usuarioConversacion[empresario].conversacion[-1] == "/publicar")
            {
                Publicacion publicacion = new Publicacion(empresario.empresa.residuos[Convert.ToInt32(message) - 1], empresario.empresa.ubicacion, DateTime.Now, empresario.empresa);
                empresario.empresa.publicaciones.AddPublicacion(publicacion);
            }
            else
            {
                return base.Handle(empresario, message);    
            }
            
        }

    }
}