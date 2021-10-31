using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    class OfertasHandler : AbstractHandlerRespuestas
    {
        public override object Handle(IUsuario usuario, string message)
        {   
            if(UsuarioConversacion.usuarioConversacion[usuario].conversacion[-1] == "/ofertas")
            {
                List<Publicacion> ofertas = Buscador.Buscar(message);
                Registrado.VerifyConversation(usuario, message);
                Registrado.VerifyConversation(usuario, "resputaofertas");
                int contador = 0;
                foreach(Publicacion publicacion1 in ofertas)
                {
                    Console.WriteLine($"{contador}. {publicacion1.residuo.cantidad} Kg de {publicacion1.residuo.tipo} en {publicacion1.ubicacion} \n Ingrese el numero de la publicacion que quiere ver.");
                    contador += 1;
                }
            }   
            else
            {
                return base.Handle(usuario, message);    
            }
            
        }

    }
}