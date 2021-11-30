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
        /// El usuario de la empresa.
        /// </summary>
        /// <value></value>
        public Empresa EmpresaUsuario { get; private set; }

        /// <summary>
        /// Los emprendedores que usan este handler.
        /// </summary>
        /// <value></value>

        public Emprendedor Emprendedor { get; private set; }

        /// <summary>
        /// Lista de publicaciones de la empresa
        /// </summary>
        /// <value></value>
        public ListaPublicaciones PublicacionesUsuario { get; private set; }

        /// <summary>
        /// Procesa el mensaje /verresiduosconsumidos.
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
            bool realEmprendedor = false;
            foreach(Emprendedor emprendedor in ListaUsuarios.GetInstance().Usuarios)
            {
                if (emprendedor.Id == id)
                {
                    this.Emprendedor = emprendedor;
                    realEmprendedor = true;
                }
            }
            if (realEmprendedor == true)
            {
                if (Emprendedor.State == "VRCH-C")
                {
                    State = VerResiduosConsumidosState.Consumidos;
                }
            }

            if (State == VerResiduosConsumidosState.Start && message == "/verresiduosconsumidos")
            {
                this.Emprendedor.State = "VRCH-C";
                response = "¿Residuos entregados desde hace cuantos dias quieres ver?";
                State = VerResiduosConsumidosState.Start;

                return true;
            }
            if (State == VerResiduosConsumidosState.Consumidos)
            {
                response = "";
                /// <summary>
                /// Utilizamos este bloque de código para atrapar la excepción (System.FormatExcepetion)
                /// la cual ocurre si el usuario ingresa como argumento una letra en vez de un número, 
                /// esta excepción de no ser manejada provocaría un error que terminaria con el funcionamiento del bot.
                /// </summary>
                /// <value></value>
                try
                {
                    Convert.ToInt32(message);
                }
                catch (System.FormatException)
                {
                    response = "Usted no ha ingresado un número válido, porfavor intentelo nuevamente";
                    this.State = VerResiduosConsumidosState.Start;
                    this.Emprendedor.State = "VRCH-C";
                }
                if(response != "Usted no ha ingresado un número válido, porfavor intentelo nuevamente")
                {
                    int contador = 0;
                    string unfinishedResponse = "Estas son tus residuos consumidos:\n";
                    List<Residuo> consumidos = Buscador.Buscar(id, Convert.ToInt32(message));
                    foreach(Residuo residuo in consumidos)
                    {
                        unfinishedResponse += $"Consumio: {residuo.Cantidad} de {residuo.Tipo}, el costo de este es {residuo.Cost}{residuo.Moneda}\n";
                        contador += 1;
                    }
                    response = unfinishedResponse;
                    State = VerResiduosConsumidosState.Start;
                    this.Emprendedor.State = "start";

                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                response = string.Empty;
                State = VerResiduosConsumidosState.Start;

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
        /// Indica los diferentes estados que puede tener el comando VerResiduosConsumidosState.
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