using System;
namespace ClassLibrary
{
   public class OfertasCommand : ICommand
   {
        public ICommand next{get;set;} = new NullCommand();
        public void Do(IUsuario emprendedor, string message)
        {
            message.ToLower();
            if(message == "/ofertas")
            {
               if(emprendedor.GetType() == typeof(Emprendedor))
               {
                  Console.WriteLine("¿Cual es tu ubicación?");
               }
            }
        }
   } 
}