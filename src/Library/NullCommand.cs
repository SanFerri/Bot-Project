using System;
namespace ClassLibrary
{
   public class NullCommand : ICommand
   {
       public ICommand next{get;set;}
       public void Do(IUsuario usuario, string message)
       {
           Console.WriteLine("El comando ingresado no es valido o no existe.");
       }
   }
}