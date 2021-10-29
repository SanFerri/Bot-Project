using System;
namespace ClassLibrary
{
   public class OfertasCommand : ICommand
   {
        public ICommand next{get;set;} = new NullCommand();
        public void Do(IUsuario emprendedor, string message)
        {
            if(message == "Ofertas")
            {
               if(emprendedor.GetType() == typeof(Emprendedor))
               {
                  Console.WriteLine("¿Cual es el residuo que busca?");
                  int eleccion = Convert.ToInt32(Console.ReadLine());
                  Buscador.Buscar(ListaResiduos.listaResiduos[eleccion]);
               }
            }
        }
   } 
}