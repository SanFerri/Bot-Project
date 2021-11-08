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
        public Empresa empresaUsuario { get; private set; }
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
                    unfinishedResponse += $"{contador}. Ofrece: {publicacion.residuo.cantidad} kg de {publicacion.residuo.tipo} en {publicacion.ubicacion.direccion}. Ademas la habilitacion para conseguir estos residuos es: {publicacion.habilitacion} Fecha: {publicacion.fecha}\n";
                    contador += 1;
                }
                unfinishedResponse += "¿Quieres cambiar o eliminar alguna publicacion? Responda si para ver mas cambios, no para finalizar la interaccion.";
                response = unfinishedResponse;
                this.State = VerPublicacionesState.CambiarPrompt;
                return true;
            } 
            else if (State == VerPublicacionesState.CambiarPrompt)
            {
                if (message == "si")
                {
                    response = "Ingrese el numero de la publicacion cuya habilitacion quiere cambiar.";
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
            else if (State == VerPublicacionesState.CambiarPrompt)
            {
                if(message == "si")
                {
                    response = "¿Que quieres hacer? \n 1. Cambiar habilitacion \n 2. Indicar como entregado \n 3. Cambiar la ubicacion \n 4. Cambiar costo";
                    this.State = VerPublicacionesState.EleccionCambio;
                    return true;
                }
                else if(message == "no")
                {
                    response = string.Empty;
                    return false;
                }
                else
                {
                    response = "No ingreso una respuesta correcta.";
                    this.State = VerPublicacionesState.Start;
                    return true;
                }
            }
            else if (State == VerPublicacionesState.EleccionCambio)
            {
                if (message == "1")
                {
                    response = "¿Cual es la nueva habilitacion?";
                    this.State = VerPublicacionesState.Habilitacion;
                    return true;
                }
                else if (message == "2")
                {
                    response = "Se ha marcado como entregado";
                    this.State = VerPublicacionesState.Entregado;
                    return false;
                }
                else if (message == "3")
                {
                    response = "¿Cual es la nueva direccion?";
                    this.State = VerPublicacionesState.Ubicacion;
                    return false;
                }
                else if (message == "4")
                {
                    response = "¿Cual es el nuevo costo?";
                    this.State = VerPublicacionesState.Costo;
                    return false;
                }
                else
                {
                    response = "No ha elegido un numero entre las opciones";
                    return false;
                }
            }
            else if (State == VerPublicacionesState.Habilitacion)
            {
                Publicacion publicacionElegida = this.publicacionesUsuario.listaPublicaciones[Convert.ToInt32(message)];
                publicacionElegida.habilitacion = message;
                this.
                response = "¿Cual es la nueva habilitacion?";
        
                return true;
            }

            else if (State == VerPublicacionesState.Entregado)
            {
                Publicacion publicacionElegida = this.publicacionesUsuario.listaPublicaciones[Convert.ToInt32(message)];
                publicacionElegida.entregado = true;
                response = "Se ha puesto la publicacion como entregada";
        
                return true;
            }

            else if (State == VerPublicacionesState.Ubicacion)
            {
                Publicacion publicacionElegida = this.publicacionesUsuario.listaPublicaciones[Convert.ToInt32(message)];
                publicacionElegida.habilitacion = message;
                response = "Se ha agregado la nueva ubicacion";
        
                return true;
            }

            else if (State == VerPublicacionesState.Costo)
            {
                Publicacion publicacionElegida = this.publicacionesUsuario.listaPublicaciones[Convert.ToInt32(message)];
                publicacionElegida.habilitacion = message;
                response = "Se ha agregado el nuevo costo";
        
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
            CambiarPrompt,
            EleccionCambio,
            Habilitacion,
            Ubicacion,
            Entregado,
            Costo
        }
    }
}