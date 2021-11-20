using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Registrarse".
    /// </summary>
    public class RegistrarseHandler : BaseHandler
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        public RegistrarseState State { get; private set; }

        /// <summary>
        /// Los datos que va obteniendo el comando en los diferentes estados.
        /// </summary>

        public RegistrarseHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/registrarme" };
        }


        /// <summary>
        /// Procesa todos los mensajes y retorna true siempre.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado indicando que el mensaje no pudo se procesado.</param>
        /// <param name="id">Es el id del usuario.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(string message, int id, out string response)
        {
            bool registrado = Registrado.VerifyUser(id);

            if(registrado == false)
            {
                response = "No está registrado, ingrese una invitación si es parte de una empresa, en caso de no serlo responda con un no";
                this.State = RegistrarseState.InvitacionPrompt;
                return true;
            }
            else if(State == RegistrarseState.InvitacionPrompt)
            {
                ListaEmpresarios TodoEmpresario = ListaEmpresarios.GetInstance();
                bool confirmRegistrado = false;
                int invitacion = Convert.ToInt32(message);
                foreach(Empresario empresario in TodoEmpresario.Empresarios)
                {
                    if(empresario.Invitacion == invitacion)
                    {
                        empresario.Id = id;
                        
                        confirmRegistrado = true;
                        this.State = RegistrarseState.Start;
                    }
                }
                if(confirmRegistrado == false)
                {
                    response = "La invitacion no es la correcta, si cree haberla escrito mal vuelva a ingresar el comando.";
                }
                else
                {
                    response = "Se te ha registrado correctamente, en caso de querer cambiar los datos predeterminados de la empresa use el comando /cambiardatos";
                }
                return confirmRegistrado;
            } 
            else if (registrado == true)
            {
                // En los estados FromAddressPrompt o ToAddressPrompt si no hay un buscador de direcciones hay que
                // responder que hubo un error y volver al estado inicial.
                response = "Usted ya esta registrado como un empresario";

                return false;
            }
            else
            {
                response = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Retorna este "handler" al estado inicial.
        /// </summary>
        protected override void InternalCancel()
        {
            this.State = RegistrarseState.Start;
        }
        
        /// <summary>
        /// Estados por los que pasara el handler para asi saber que mensaje esperar y que respuesta dar.
        /// </summary>
        public enum RegistrarseState
        {

            ///-Start: Es el estadio inicial del comando. En este comando pide el mensaje de invitación para
            ///asi pasar al siguiente estado.
            Start,

            ///-InvitacionPrompt: Luego de pedir el mensaje de invitación, se hace la logica sobre la invitación
            ///y se vera si esta es correcta o no.
            InvitacionPrompt
        }
    }
}