using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "ResiduosPuntuales".
    /// </summary>
    public class VerEntregadosHandler : BaseHandler
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        public VerPublicacionesState State { get; private set; }

        /// <summary>
        /// La empresa del usuario
        /// </summary>
        /// <value></value>
        public Empresa EmpresaUsuario { get; private set; }
        
        public ListaEmpresarios LosEmpresarios { get; private set; }
        public Empresario Empresario { get; private set; }

        /// <summary>
        /// Lista donde se almacenan las publicaciones.
        /// </summary>
        /// <value></value>
        public ListaPublicaciones PublicacionesUsuario { get; private set; }

        /// <summary>
        /// Procesa el mensaje /verentregados.
        /// </summary>

        public VerEntregadosHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/verentregados" };
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
            bool realEmpresario = false;
            LosEmpresarios = ListaEmpresarios.GetInstance();
            foreach(Empresario empresario in this.LosEmpresarios.Empresarios)
            {
                if(empresario.Id == id)
                {
                    this.EmpresaUsuario = empresario.Empresa;
                    realEmpresario = true;
                    this.Empresario = empresario;
                }
            }
            if(realEmpresario == true)
            {
                if (Empresario.State == "VEH-E")
                {
                    State = VerPublicacionesState.Entregados;
                }
            }

            if (State == VerPublicacionesState.Start && message == "/verentregados" && realEmpresario == true)
            {
                this.Empresario.State = "VEH-E";
                response = "¿Publicaciones entregadas desde hace cuantos dias quieres ver?";
                State = VerPublicacionesState.Start;

                return true;
            }
            if (State == VerPublicacionesState.Entregados)
            {
                int contador = 0;
                string unfinishedResponse = "Estas son tus publicaciones ya entregadas:\n";
                List<Publicacion> entregados = Buscador.Buscar(EmpresaUsuario.Empresario, Convert.ToInt32(message));
                foreach(Publicacion publicacion in entregados)
                {
                    unfinishedResponse += $"{contador}. Ofrece: {publicacion.Residuo.Cantidad} kg de {publicacion.Residuo.Tipo} en {publicacion.Ubicacion.Direccion}. Ademas la habilitacion para conseguir estos residuos es: {publicacion.Habilitacion} Fecha: {publicacion.Fecha}\n";
                    contador += 1;
                }
                response = unfinishedResponse;
                State = VerPublicacionesState.Start;
                this.Empresario.State = "start";

                return true;
            } 
            else if (realEmpresario == false && message == this.Keywords[0])
            {
                response = "Usted no es un empresario, no puede hacer uso de este comando";
                State = VerPublicacionesState.Start;

                return false;
            }
            else
            {
                response = string.Empty;
                State = VerPublicacionesState.Start;

                return false;
            }
        }

        /// <summary>
        /// Retorna este "handler" al estado inicial.
        /// </summary>
        protected override void InternalCancel()
        {
            this.State = VerPublicacionesState.Start;
        }

        /// <summary>
        /// Indica los diferentes estados de VerPublicacionesState.
        /// </summary>
        public enum VerPublicacionesState
        {
            ///-Start: Es el comando inicial.
            Start,
            ///-CambiarPrompt: Es el estado en el que te pregunta si quieres o no cambiar o borrar una publicacion.
            Entregados
        }
    }
}