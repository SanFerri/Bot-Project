using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    class OfertasHandler : AbstractHandlerRespuestas
    {
        public override object Handle(IUsuario usuario, string message)
        {   
            if(UsuarioConversacion.usuarioConversacion[usuario].conversacion[-1] == "usuario_ubicacion")
            {
                Ubicacion ubicacion = new Ubicacion(UsuarioConversacion.usuarioConversacion[usuario].conversacion[-2]);
                List<Publicacion> ofertas = Buscador.Buscar(message);
                Registrado.VerifyConversation(usuario, message);
                Registrado.VerifyConversation(usuario, "resputaofertas");
                int contador = 0;
                foreach(Publicacion publicacion1 in ofertas)
                {
                    Console.WriteLine($"{contador}. {publicacion1.residuo.cantidad} Kg de {publicacion1.residuo.tipo} en {publicacion1.ubicacion}");
                    contador += 1;
                }
            
                Console.WriteLine("\n Ingrese el numero de la publicacion que quiere ver.");
            } 
            else
            {
                return base.Handle(usuario, message);    
            }
            
        }

    }
}