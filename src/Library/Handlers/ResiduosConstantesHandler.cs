using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "distancia".
    /// </summary>
    public class ResiduosConstantesHandler : BaseHandler
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        public ResiduosConstantesState State { get; private set; }

        /// <summary>
        /// Los datos que va obteniendo el comando en los diferentes estados.
        /// </summary>

        public ResiduosConstantesHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/residuosconstantes" };
        }


        /// <summary>
        /// Procesa todos los mensajes y retorna true siempre.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="id">La id del usuario.</param>
        /// <param name="response">La respuesta al mensaje procesado indicando que el mensaje no pudo se procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(string message, int id, out string response)
        {
            if(State == ResiduosConstantesState.Start && message == "/residuosconstantes")
            {
                List<string> residuosConstantes = Buscador.ResiduosConstantes();
                string unfinishedResponse = "Estos son los residuos constantes:\n";
                foreach(string residuo in residuosConstantes)
                {
                    unfinishedResponse += $"{residuo}";
                }
                response = unfinishedResponse;

                return true;
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
            this.State = ResiduosConstantesState.Start;
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
        public enum ResiduosConstantesState
        {
            ///-Start: El estado inicial del comando.
            Start
        }
    }
}