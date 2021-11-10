using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "ResiduosPuntuales".
    /// </summary>
    public class VerPublicacionesHandler : BaseHandler
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

        public VerPublicacionesHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/verpublicaciones" };
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
            foreach(Empresario empresario in ListaEmpresarios.empresarios)
            {
                if(empresario.id == id)
                {
                    this.empresaUsuario = empresario.empresa;
                    realEmpresario = true;
                }
            }

            if (State == VerPublicacionesState.Start && message == "/verpublicaciones" && realEmpresario == true)
            {
                int contador = 0;
                string unfinishedResponse = "Estas son tus publicaciones:\n";
                this.publicacionesUsuario = empresaUsuario.publicaciones;
                foreach(Publicacion publicacion in publicacionesUsuario.listaPublicaciones)
                {
                    if(publicacion.entregado == false)
                    {
                        unfinishedResponse += $"{contador}. Ofrece: {publicacion.residuo.cantidad} kg de {publicacion.residuo.tipo} en {publicacion.ubicacion.direccion}. Ademas la habilitacion para conseguir estos residuos es: {publicacion.habilitacion} Fecha: {publicacion.fecha}\n";
                        contador += 1;
                    }
                }
                unfinishedResponse += "¿Quieres eliminar alguna publicacion? o indicar que esta entregada? Responda elIminar, entregado, o no";
                response = unfinishedResponse;
                this.State = VerPublicacionesState.CambiarPrompt;
                return true;
            } 
            else if (State == VerPublicacionesState.CambiarPrompt)
            {
                if (message == "entregado")
                {
                    this.State = VerPublicacionesState.Entregado;
                    response = "Ingrese el numero de la publicacion que quiera indicar como entregada.";
                    return true;
                }
                else if (message == "eliminar")
                {
                    this.State = VerPublicacionesState.Eliminar;
                    response = "Ingrese el numero de la publicacion que quiera eliminar.";
                    return true;
                }
                else if (message == "no")
                {
                    response = string.Empty;
                    return false;
                }
                else
                {
                    response = "No ingreso una respuesta valida";
                    return false;
                }
            }
            else if (State == VerPublicacionesState.Entregado)
            {
                Publicacion publicacionElegida = this.publicacionesUsuario.listaPublicaciones[Convert.ToInt32(message)];
                publicacionElegida.entregado = true;
                response = "Se ha puesto la publicacion como entregada";
        
                return true;
            }
            else if (State == VerPublicacionesState.Eliminar)
            {
                Publicacion publicacionElegida = this.publicacionesUsuario.listaPublicaciones[Convert.ToInt32(message)];
                Mercado.RemoveMercado(publicacionElegida);
                empresaUsuario.publicaciones.RemovePublicacion(publicacionElegida);
                response = "Se ha eliminado a publicacion";

                return true;
            }
            
            else if (realEmpresario == false)
            {
                response = "Usted no es un empresario, no puede hacer uso de este comando";
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
            CambiarPrompt,
            ///-Entregado: Es el estado en el que se indica a la publicacion como entregada.
            Entregado,
            ///-Eliminar: Es el estado en el que se borra una publicacion.
            Eliminar
        }
    }
}