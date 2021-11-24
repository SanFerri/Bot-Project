using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Invitar".
    /// </summary>
    public class InvitarHandler : BaseHandler
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        public InvitarState State { get; private set; }

        /// <summary>
        /// Pide la ubicación.
        /// </summary>
        public Ubicacion UbicacionData { get; private set; }

        /// <summary>
        /// Pide la invitación.
        /// </summary>
        /// <value></value>

        public string Invitacion { get; private set; }

        /// <summary>
        /// Los datos de la empresa.
        /// </summary>
        /// <value></value>

        public Empresa EmpresaData { get; private set; }

        /// <summary>
        /// El nombre de la empresa.
        /// </summary>
        /// <value></value>

        public string NombreEmpresa { get; private set; }

        /// <summary>
        /// Es el contacto de la empresa.
        /// </summary>
        /// <value></value>
        public string ContactoData { get; private set; }

        /// <summary>
        /// Son los empresarios que estan usando los handlers.
        /// </summary>
        /// <value></value>

        public Administrador Administrador { get; private set; }

        /// <summary>
        /// Es el resultado de la publicación.
        /// </summary>
        /// <value></value>
        public Publicacion Result { get; private set; }

        /// <summary>
        /// Lista de todos los Administradores que hay.
        /// </summary>
        /// <returns></returns>

        public ListaAdministradores LosAdministradores = ListaAdministradores.GetInstance();
        
        /// <summary>
        /// Esta clase procesa el mensaje /invitar.
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>

        public InvitarHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/invitar" };
        }


        /// <summary>
        /// Procesa todos los mensajes y retorna true siempre.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado indicando que el mensaje no pudo se procesado.</param>
        /// <param name="id">Es el id de un usuario.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(string message, int id, out string response)
        {
            bool realAdministrador = false;
            foreach(Administrador administrador in this.LosAdministradores.Administradores)
            {
                if(administrador.Id == id)
                {
                    realAdministrador = true;
                    this.Administrador = administrador;
                }
            }
            if(realAdministrador == true)
            {
                if (Administrador.State == "IH-NP")
                {
                    State = InvitarState.NombrePrompt;
                }
                else if (Administrador.State == "IH-UP")
                {
                    this.State = InvitarState.UbicacionPrompt;
                }
                else if (Administrador.State == "IH-CP")
                {
                    this.State = InvitarState.ContactoPrompt;
                }
                else if (Administrador.State == "IH-AP")
                {
                    this.State = InvitarState.AdministradorPrompt;
                }
            }

            if(realAdministrador == true && State ==  InvitarState.Start && message == "/invitar")
            {

                // El estado InvitarState.NombrePrompt espera que se ingrese el nombre de la empresa la cual
                // se quiere invitar. 
                this.Administrador.State = "IH-NP";

                response = "¿Cual es el nombre de la empresa que quiere invitar?";
                this.State = InvitarState.Start;

                return true;
            }
            else if (State == InvitarState.NombrePrompt)
            {
                // En el estado InvitarState.UbicacionPrompt el mensaje recibido es la respuesta con la ubicacion de la empresa this.NombreEmpresa = message;
                this.NombreEmpresa = message;
                this.Administrador.State = "IH-UP";

                response = "Ahora dime la ubicacion de dicha empresa";
                this.State = InvitarState.Start;

                return true;
            }
            else if (State == InvitarState.UbicacionPrompt)
            {
                this.UbicacionData = new Ubicacion(message);
                this.Administrador.State = "IH-CP";
                response = "Por ultimo dime el contacto de la empresa";
                this.State = InvitarState.Start;

                return true;
            }
            else if (State == InvitarState.ContactoPrompt)
            {
                this.ContactoData = message;
                this.EmpresaData = new Empresa(this.NombreEmpresa, this.UbicacionData, this.ContactoData);
                if (this.EmpresaData != null)
                {
                    response = "Se ha creado la empresa ahora crearemos el usuario.";
                    this.Administrador.State = "IH-AP";
                    this.State = InvitarState.Start;

                    return true;
                }
                else
                {
                    response = "No se ha creado la empresa puede volver a intentar.";
                    this.Administrador.State = "start";
                    this.State = InvitarState.Start;

                    return false;
                }
            }
            else if (State == InvitarState.AdministradorPrompt)
            {
                this.Invitacion = InvitationGenerator.Generate();
                Empresario Empresario = new Empresario(Invitacion, this.EmpresaData);
                response = $"Se ha creado el empresario y esta es la invitacion que debe usar para acceder a su status: {this.Invitacion}";
                this.State = InvitarState.Start;

                return true;
            }
            else if (realAdministrador == false && message == this.Keywords[0])
            {
                // Responde cuando no es un empresario, de esa manera no puede utilizar el codigo.
                response = "Usted no es un administrador, no puede usar el codigo...";
                this.State = InvitarState.Start;

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
            this.State = InvitarState.Start;
            this.UbicacionData = null;
            this.ContactoData = null;
            this.EmpresaData = null;
            this.NombreEmpresa = null;
        }
        /// <summary>
        /// Indica los diferentes estados que puede tener el comando InvitarState.
        /// </summary>

        public enum InvitarState
        {
            ///-Start: Es el estado inicial del comando. 
            Start,
 
            ///-NombrePrompt: En este estado el comando pide el nombre de la empresa y pasa al siguiente 
            ///estado.
            NombrePrompt,

            ///-UbicacionPrompt: En este estado el comando pide la ubicación de la empresa y pasa al siguiente
            ///estado
            UbicacionPrompt,

            ///-ContactoPrompt: En este estado el comando pide el contacto de la empresa y pasa al siguiente
            ///estado 
            ContactoPrompt,

            ///AdministradorPrompt: En este estado el comando envia el contacto del Administrador para asi ponerse
            ///en contacto. 
            AdministradorPrompt
        }
    }
}