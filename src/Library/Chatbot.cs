namespace ClassLibrary
{
    public class chatBot
    {
        public void MessageHandling(string message, int id)
        {
            bool registrado = false;

            foreach(IUsuario usuario in ListaUsuarios.usuarios)
            {
                if(usuario.id == id)
                {
                    registrado = true;
                    IUsuario usuario1 = usuario;
                }
                
            }
            if(registrado == false)
            {
                bool eleccion = false;
                while(eleccion = false)
                {
                    Console.WriteLine("No está registrado, ingrese una invitación válida");
                    int invitacion = Convert.ToInt32(Console.ReadLine());
                    foreach(IUsuario usuario in ListaUsuarios.usuarios)
                    {
                        if(usuario.invitacion == invitacion)
                        {
                            Console.WriteLine("Se te ha registrado con exito");
                            usuario.id = id;
                            eleccion = true;
                        }                                            
                    }

                } 
            }
            message.ToLower();
            char aux = message[0];
            if(aux == '/')
            {
                bool AConversacion = false;
                foreach(KeyValuePair<IUsuario,Conversacion> values in Conversacion.usuarioConversacion)
                {
                    if(values.Key == Usuario1)
                    {
                        values.Value.AddMessage(message);
                        AConversacion = true;
                    }
                }
                if(AConversacion == false)
                {
                    Conversacion conversacion = new Conversacion(message);
                    Conversacion.AddConversacionUsuario(usuario1, conversacion);
                    Conversacion.AddMessage(message);
                }
                PublicarCommand.Do(usuario1, message);
                if(usuarioConversación[usuario1][-1][0] == '/')
                {
                     
                }

            }
        }
    }
}
