using System;
using System.IO;

namespace ClassLibrary
{
    /// <summary>
    /// Comando que permite a los empresarios realizar publicaciones de sus residuos.
    /// </summary>
    public class PublicarCommand : ICommand
    {
        /// <summary>
        /// Proximo comando es Invitar
        /// </summary>
        public static InvitarCommand Next = new InvitarCommand();

        /// <summary>
        /// Metodo que evalua si el usuario completa los requerimientos (ser un empresario) y ve si el mensaje es
        /// el indicado para este comando.
        /// </summary>
        /// <param name="empresario"></param>
        /// <param name="message"></param>
        public void Do(Usuario empresario, string message)
        {
            // Verificamos que el mensaje sea el correcto
            if(message == "Publicar")
            {
                // Verificamos los requerimientos (ser un empresario)
                if(empresario.type(Empresario))
                {
                    Console.WriteLine("¿Una publicacion de cual de sus residuos quiere hacer?");

                    int contador = 0;
                    foreach(Residuo residuo in empresario.Empresa.residuos)
                    {
                        Console.WriteLine($"{contador}. {residuo.tipo} ");
                        contador += 1;
                    }
                    int eleccion = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Ingrese un numero de contacto");
                    int contacto = Convert.ToInt32(Console.ReadLine());
                    Publicacion publicacion = new Publicacion(empresario.Empresa.residuos[eleccion - 1], empresario.Empresa.ubicacion, contacto, DateTime.Now, empresario.Empresa);
                    empresario.Empresa.publicaciones.AddPublicacion(publicacion);
                }
            }

            else
            {
                Next.Do(empresario);
            }
        }
    }
}