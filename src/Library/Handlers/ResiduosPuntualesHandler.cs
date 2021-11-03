using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "ResiduosPuntuales".
    /// </summary>
    public class ResiduosPuntualesHandler : BaseHandler
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        public ResiduosPuntualesState State { get; private set; }

        /// <summary>
        /// Los datos que va obteniendo el comando en los diferentes estados.
        /// </summary>

        public ResiduosPuntualesHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/residuospuntuales" };
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
            if(State == ResiduosPuntualesState.Start && message == "/residuospuntuales")
            {
                List<string> residuosPuntuales = Buscador.ResiduosPuntuales();
                string unfinishedResponse = "Estos son los residuos puntuales:\n";
                foreach(string residuo in residuosPuntuales)
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
            this.State = ResiduosPuntualesState.Start;
        }

        /// <summary>
        /// Indica los diferentes estados que puede tener el comando ResiduosPuntualesState
        /// </summary>
        public enum ResiduosPuntualesState
        {
            ///-Start: Es el comando inicial.
            Start
        }
    }
}