using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "ResiduosPuntuales".
    /// </summary>
    public class VerResiduosConsumidosHandler : BaseHandler
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        public VerResiduosConsumidosState State { get; private set; }

        /// <summary>
        /// La empresa del usuario
        /// </summary>
        /// <value></value>
        public Empresa empresaUsuario { get; private set; }

        /// <summary>
        /// Las publicaciones de la empresa
        /// </summary>
        /// <value></value>
        public ListaPublicaciones publicacionesUsuario { get; private set; }

        /// <summary>
        /// Los datos que va obteniendo el comando en los diferentes estados.
        /// </summary>

        public VerResiduosConsumidosHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/verresiduosconsumidos" };
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
            if (State == VerResiduosConsumidosState.Start && message == "/verresiduosconsumidos")
            {
                this.State = VerResiduosConsumidosState.Consumidos;
                response = "¿Residuos entregados desde hace cuantos dias quieres ver?";
                return true;
            }
            if (State == VerResiduosConsumidosState.Consumidos)
            {
                int contador = 0;
                string unfinishedResponse = "Estas son tus residuos consumidos:\n";
                List<Residuo> consumidos = Buscador.BuscarResiduosConsumidos(id, Convert.ToInt32(message));
                foreach(Residuo residuo in consumidos)
                {
                    unfinishedResponse += $"Consumio: {residuo.cantidad} de {residuo.tipo}, el costo de este es {residuo.cost}{residuo.moneda}\n";
                    contador += 1;
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
            this.State = VerResiduosConsumidosState.Start;
        }

        /// <summary>
        /// Indica los diferentes estados que puede tener el comando ResiduosPuntualesState
        /// </summary>
        public enum VerResiduosConsumidosState
        {
            ///-Start: Es el comando inicial.
            Start,
            ///-CambiarPrompt: Es el estado en el que te pregunta si quieres o no cambiar o borrar una publicacion.
            Consumidos
        }
    }
}