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
        /// La empresa del usuario.
        /// </summary>
        /// <value></value>
        public Empresa EmpresaUsuario { get; private set; }

        /// <summary>
        /// Elegido es el número de la publicación que se eligio como entregada.
        /// </summary>
        /// <value></value>

        public int Elegido {get; private set;} = -1;

        /// <summary>
        /// Lista de las publicaciones que hay.
        /// </summary>
        /// <value></value>
        public ListaPublicaciones PublicacionesUsuario { get; private set; }

        /// <summary>
        /// Lista de los empresarios que hay.
        /// </summary>
        /// <value></value>

        public ListaEmpresarios LosEmpresarios { get; private set; }

        /// <summary>
        /// Son los empresarios que estan usando los handlers.
        /// </summary>
        /// <value></value>

        public Empresario Empresario { get; private set; }

        /// <summary>
        /// Procesa el mensaje /verpublicaciones.
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
                if (Empresario.State == "VPH-CP")
                {
                    State = VerPublicacionesState.CambiarPrompt;
                }
                else if (Empresario.State == "VPH-EU")
                {
                    this.State = VerPublicacionesState.EntregadoUsuario;
                }
                else if (Empresario.State == "VPH-E")
                {
                    this.State = VerPublicacionesState.Eliminar;
                }
                else if (Empresario.State == "VPH-E2")
                {
                    this.State = VerPublicacionesState.Entregado;
                }
            }

            if (State == VerPublicacionesState.Start && message == "/verpublicaciones" && realEmpresario == true)
            {
                int contador = 0;
                string unfinishedResponse = "Estas son tus publicaciones:\n";
                this.PublicacionesUsuario = EmpresaUsuario.Publicaciones;
                foreach(Publicacion publicacion in PublicacionesUsuario.Publicaciones)
                {
                    if(publicacion.Entregado == false)
                    {
                        unfinishedResponse += $"{contador}. Ofrece: {publicacion.Residuo.Cantidad} kg de {publicacion.Residuo.Tipo} en {publicacion.Ubicacion.Direccion}. Ademas la habilitacion para conseguir estos residuos es: {publicacion.Habilitacion} Fecha: {publicacion.Fecha}\n";
                        contador += 1;
                    }
                }
                unfinishedResponse += "¿Quieres eliminar alguna publicacion? o indicar que esta entregada? Responda elIminar, entregado, o no";
                response = unfinishedResponse;
                this.Empresario.State = "VPH-CP";
                State = VerPublicacionesState.Start;

                return true;
            } 
            else if (State == VerPublicacionesState.CambiarPrompt)
            {
                if (message == "entregado")
                {
                    this.Empresario.State = "VPH-EU";
                    response = "Ingrese el numero de la publicacion que quiera indicar como entregada.";
                    State = VerPublicacionesState.Start;

                    return true;
                }
                else if (message == "eliminar")
                {
                    this.Empresario.State = "VPH-E";
                    response = "Ingrese el numero de la publicacion que quiera eliminar.";
                    State = VerPublicacionesState.Start;

                    return true;
                }
                else if (message == "no")
                {
                    response = string.Empty;
                    this.Empresario.State = "start";
                    State = VerPublicacionesState.Start;

                    return false;
                }
                else
                {
                    response = "No ingreso una respuesta valida";
                    this.Empresario.State = "start";
                    State = VerPublicacionesState.Start;

                    return false;
                }
            }
            else if (State == VerPublicacionesState.EntregadoUsuario)
            {
                if(Elegido == -1)
                {
                    Elegido = Convert.ToInt32(message);
                }
                this.Empresario.State = "VPH-E";
                State = VerPublicacionesState.Start;
                response = "¿Cual es el id del usuario al que le ha entregado esta publicacion?";

                return true;
            }
            else if (State == VerPublicacionesState.Entregado)
            {
                ListaUsuarios usuarios = ListaUsuarios.GetInstance();
                bool correcto = false;
                foreach(IUsuario usuario in usuarios.Usuarios)
                {
                    if(usuario.Id == id)
                    {
                        correcto = true;
                    }
                }
                if(correcto == true)
                {
                    Publicacion publicacionElegida = this.PublicacionesUsuario.Publicaciones[Elegido];
                    publicacionElegida.Entregado = true;
                    publicacionElegida.IdEntregado = id;
                    response = "Se ha puesto la publicacion como entregada";
                    this.Empresario.State = "start";
                    State = VerPublicacionesState.Start;

                    return true;
                }
                else
                {
                    response = "El id indicado no existe.";
                    this.Empresario.State = "VPH-EU";
                    State = VerPublicacionesState.Start;

                    return true;
                }
            }
            else if (State == VerPublicacionesState.Eliminar)
            {
                Mercado mercado = Mercado.GetInstance();
                Publicacion publicacionElegida = this.PublicacionesUsuario.Publicaciones[Convert.ToInt32(message)];
                mercado.RemoveMercado(publicacionElegida);
                EmpresaUsuario.Publicaciones.RemovePublicacion(publicacionElegida);
                response = "Se ha eliminado la publicacion";
                this.Empresario.State = "start";
                State = VerPublicacionesState.Start;

                return true;
            }
            
            else if (realEmpresario == false && message == this.Keywords[0])
            {
                response = "Usted no es un empresario, no puede hacer uso de este comando";
                State = VerPublicacionesState.Start;

                return true;
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
        /// Indica los diferentes estados que puede tener el comando VerPublicacionesState.
        /// </summary>
        public enum VerPublicacionesState
        {
            ///-Start: Es el comando inicial.
            Start,
            ///-CambiarPrompt: Es el estado en el que te pregunta si quieres o no cambiar o borrar una publicacion.
            CambiarPrompt,
            ///-Entregado: Es el estado en el que se indica a la publicacion como entregada.
            EntregadoUsuario,
            ///-Entregado: Es el ultimo state en el cual se cambia el estado de la publicación entregada y 
            ///se le asocia un usuario destinatario.
            Entregado,
            ///-Eliminar: Es el estado en el que se borra una publicacion.
            Eliminar
        }
    }
}