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
        public Empresa empresaUsuario { get; private set; }

        /// <summary>
        /// Las publicaciones de la empresa
        /// </summary>
        /// <value></value>
        public ListaPublicaciones publicacionesUsuario { get; private set; }

        /// <summary>
        /// Los datos que va obteniendo el comando en los diferentes estados.
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
            ListaEmpresarios TodoEmpresario = ListaEmpresarios.GetInstance();
            foreach(Empresario empresario in TodoEmpresario.Empresarios)
            {
                if(empresario.id == id)
                {
                    this.empresaUsuario = empresario.empresa;
                    realEmpresario = true;
                }
            }
            if (State == VerPublicacionesState.Start && message == "/verentregados" && realEmpresario == true)
            {
                this.State = VerPublicacionesState.Entregados;
                response = "¿Publicaciones entregadas desde hace cuantos dias quieres ver?";
                return true;
            }
            if (State == VerPublicacionesState.Entregados)
            {
                int contador = 0;
                string unfinishedResponse = "Estas son tus publicaciones ya entregadas:\n";
                List<Publicacion> entregados = Buscador.BuscarEntregados(empresaUsuario.empresario, Convert.ToInt32(message));
                foreach(Publicacion publicacion in entregados)
                {
                    unfinishedResponse += $"{contador}. Ofrece: {publicacion.residuo.cantidad} kg de {publicacion.residuo.tipo} en {publicacion.ubicacion.direccion}. Ademas la habilitacion para conseguir estos residuos es: {publicacion.habilitacion} Fecha: {publicacion.fecha}\n";
                    contador += 1;
                }
                response = unfinishedResponse;
                return true;
            } 
            else if (realEmpresario == false)
            {
                response = "Usted no es un empresario, no puede hacer uso de este comando";
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
            this.State = VerPublicacionesState.Start;
        }

        /// <summary>
        /// Indica los diferentes estados que puede tener el comando ResiduosPuntualesState
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