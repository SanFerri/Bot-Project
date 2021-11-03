using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "distancia".
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
                bool confirmRegistrado = false;
                int invitacion = Convert.ToInt32(message);
                foreach(Empresario empresario in ListaEmpresarios.empresarios)
                {
                    if(empresario.invitacion == invitacion)
                    {
                        empresario.id = id;
                        
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
                    response = "Se te ha registrado correctamente";
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
        /// Indica los diferentes estados que puede tener el comando DistanceHandler.
        /// - Start: El estado inicial del comando. En este estado el comando pide la dirección de origen y pasa al
        /// siguiente estado.
        /// - FromAddressPrompt: Luego de pedir la dirección de origen. En este estado el comando pide la dirección de
        /// destino y pasa al siguiente estado.
        /// - ToAddressPrompt: Luego de pedir la dirección de destino. En este estado el comando calcula la distancia
        /// y vuelve al estado Start.
        /// </summary>
        public enum RegistrarseState
        {
            Start,
            InvitacionPrompt
        }
    }
}