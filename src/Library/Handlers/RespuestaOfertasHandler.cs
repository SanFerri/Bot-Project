using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    class RespuestaOfertasHandler : AbstractHandlerRespuestas
    {
        public override object Handle(IUsuario usuario, string message)
        {   
            if(UsuarioConversacion.usuarioConversacion[usuario1].conversacion[-1] == "respuestaofertas")
            {
                string buscado = UsuarioConversacion.usuarioConversacion[usuario].conversacion[-2];
                List<Publicacion> ofertas = Buscador.Buscar(buscado);
                Publicacion publicacion = ofertas[Convert.ToInt32(message)];
                Console.WriteLine($"Dicha publicacion le pertenece a la empresa {publicacion.empresa.nombre}, este es el contacto: {publicacion.empresa.contacto}");
            }
            else
            {
                return base.Handle(usuario, message);    
            }
            
        }

    }
}