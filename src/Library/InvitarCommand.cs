using System;

namespace ClassLibrary
{
    /// <summary>
    /// Clase InvitarCommand es una clase que implementa ICommand, esta se encarga de asociar a un usuario nuevo una
    /// invitacion, la responsabilidad de crear dicha invitacion es delegada a InvitationGenerator.
    /// </summary>
    public class InvitarCommand : ICommand
    {
        public static Administrador auxiliar;
        /// <summary>
        /// Proximo comando es para ver las ofertas
        /// </summary>
        public ICommand next{get;set;} = new OfertasCommand();

        /// <summary>
        /// Metodo Do que se encarga de crear un nuevo usuario y su ID
        /// </summary>
        /// <param name="administrador"></param>
        /// <param name="message"></param>
        public void Do(IUsuario administrador, string message)
        {
            if(message == "Invitar")
            {
                if(administrador.GetType() == auxiliar.GetType())
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
                            int eleccion2 = Convert.ToInt32(Console.ReadLine());
                            Empresa empresaElegida = ListaEmpresas.empresas[eleccion2];
                            Console.WriteLine("¿Cual es su nombre?");
                            string nombre = Console.ReadLine();
                            Empresario empresario = new Empresario(invitacion, nombre, empresaElegida);
                            elegido = true;
                        }

                        else if(eleccion == 2)
                        {
                            Console.WriteLine("¿Cual es su nombre?");
                            string nombre = Console.ReadLine();
                            Emprendedor emprendedor = new Emprendedor(invitacion, nombre);
                            elegido = true;
                        }

                        else
                        {
                            Console.WriteLine("No elegiste un numero entre 1 y 2");
                        }
                    }
                }
            }
            else
            {
                next.Do(administrador, message);
            }
        }
    }
}