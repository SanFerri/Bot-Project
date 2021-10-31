using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    class PublicarHandler : AbstractHandlerRespuestas
    {
        public override object Handle(object request)
        {
            //if (request.ToString() == "/ofertas")
            if(UsuarioConversacion.usuarioConversacion[usuario1].conversacion[-1] == "/publicar")
            {
                Publicacion publicacion = new Publicacion(usuario1.Empresa.residuos[Convert.ToInt32(message) - 1], empresario.Empresa.ubicacion, DateTime.Now, empresario.Empresa);
                empresario.Empresa.publicaciones.AddPublicacion(publicacion);
            }
            else
            {
                return base.Handle(request);    
            }
            
        }

    }
}