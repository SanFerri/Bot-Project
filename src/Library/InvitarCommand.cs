using System;

namespace ClassLibrary
{
    /// <summary>
    /// Clase InvitarCommand es una clase que implementa ICommand, esta se encarga de asociar a un usuario nuevo una
    /// invitacion, la responsabilidad de crear dicha invitacion es delegada a InvitationGenerator.
    /// </summary>
    public class InvitarCommand : ICommand
    {
        /// <summary>
        /// Proximo comando es para ver las ofertas
        /// </summary>
        public OfertasCommand Next = new OfertasCommand();

        /// <summary>
        /// Metodo Do que se encarga de crear un nuevo usuario y su ID
        /// </summary>
        /// <param name="administrador"></param>
        /// <param name="message"></param>
        public void Do(Usuario administrador, string message)
        {
            if(message == "Invitar")
            {
                if(administrador.type(Administrador))
                {
                    bool elegido = false;
                    int invitacion = InvitationGenerator.Generate();

                    while(elegido == false)
                    {
                        Console.WriteLine("Elige que tipo de usuario vas a invitar: \n 1. Empresario \n 2. Emprendedor \n 3. Administrador");
                        int eleccion = Convert.ToInt32(Console.ReadLine());

                        if(eleccion == 1)
                        {
                            int contador = 0;
                            Console.WriteLine("¿A cual empresa pertenece?");
                            foreach(Empresa empresa in ListaEmpresas.empresas)
                            {
                                Console.WriteLine("{contador}. {empresa.nombre}");
                                contador += 1;
                            }
                            Empresa empresaElegida = ListaEmpresas.empresas[contador - 1];
                            Empresario empresario = new Empresario(invitacion, empresaElegida);
                            elegido = true;
                        }

                        else if(eleccion == 2)
                        {
                            Emprendedor emprendedor = new Emprendedor(invitacion);
                            elegido = true;
                        }

                        else if(eleccion == 3)
                        {
                            Administrador administrador1 = new Administrador(invitacion);
                            elegido = true;
                        }

                        else
                        {
                            Console.WriteLine("No elegiste un numero entre 1-3");
                        }
                    }
                }
            }
            else
            {
                Next.Do(administrador, message);
            }
        }
    }
}