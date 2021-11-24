using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "CambiarDatos".
    /// </summary>
    public class CambiarDatosHandler : BaseHandler
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        public CambiarDatosState State { get; private set; }

        /// <summary>
        /// Es el usario de la empresa.
        /// </summary>
        public Empresa EmpresaUsuario { get; private set; }

        /// <summary>
        /// Es el nombre de la empresa.
        /// </summary>
        /// <value></value>
        public string NombreEmpresa { get; private set; }

        /// <summary>
        /// Es la ubicación de la empresa.
        /// </summary>
        /// <value></value>
        public Ubicacion UbicacionData { get; private set; }

        /// <summary>
        /// Es el contacto de la empresa.
        /// </summary>
        /// <value></value>
        public int Contacto { get; private set; }

        /// <summary>
        /// Son los empresarios que estan usando los handlers.
        /// </summary>
        /// <value></value>

        public Empresario Empresario { get; private set; }

        /// <summary>
        /// Lista de todos los empresarios que hay.
        /// </summary>
        /// <returns></returns>

        public ListaEmpresarios LosEmpresarios = ListaEmpresarios.GetInstance();

        /// <summary>
        /// Esta clase procesa el mensaje /cambiardatos.
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public CambiarDatosHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/cambiardatos" };
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
            foreach(Empresario empresario in LosEmpresarios.Empresarios)
            {
                if(empresario.Id == id)
                {
                    this.EmpresaUsuario = empresario.Empresa;
                    realEmpresario = true;
                    this.Empresario = empresario;
                }
            }
            if (realEmpresario == true)
            {
                if (Empresario.State == "CDH-NP")
                {
                    State = CambiarDatosState.NombrePrompt;
                }
                else if (Empresario.State == "CDH-UP")
                {
                    this.State = CambiarDatosState.UbicacionPrompt;
                }
                else if (Empresario.State == "CDH-CP")
                {
                    this.State = CambiarDatosState.ContactoPrompt;
                }
            }

            if (State == CambiarDatosState.Start && message == "/cambiardatos" && realEmpresario == true)
            {
                this.Empresario.State = "CDH-NP";
                response = "Ingrese el nombre de su empresa.";
                this.State = CambiarDatosState.Start;

                return true;
            }
            else if (State == CambiarDatosState.NombrePrompt)
            {
                // En el estado CambiarDatosState el mensaje recibido con la ubicación de la empresa.
                this.NombreEmpresa = message;
                this.Empresario.State = "CDH-UP";
                response = "Ahora dime la ubicacion de dicha empresa";
                this.State = CambiarDatosState.Start;

                return true;
            }
            else if (State == CambiarDatosState.UbicacionPrompt)
            {
                this.UbicacionData = new Ubicacion(message);
                this.Empresario.State = "CDH-CP";
                response = "Por ultimo dime el contacto de la empresa";
                this.State = CambiarDatosState.Start;

                return true;
            }
            else if (State == CambiarDatosState.ContactoPrompt)
            {
                this.EmpresaUsuario.Contacto = message;
                this.EmpresaUsuario.Nombre = this.NombreEmpresa;
                this.EmpresaUsuario.Ubicacion = this.UbicacionData;
                response = "Se han actualizado sus datos...";
                this.Empresario.State = "start";
                this.State = CambiarDatosState.Start;

                return true;
            }
            else if (realEmpresario == false)
            {
                // En caso de que realEmpresario sea False, el bot interpreta que el usario en cuestion no es un empresario
                //y por ende le responde que no puede utilizar los comandos de empresario.
                response = "Usted no es un empresario, no puede usar el codigo...";
                this.State = CambiarDatosState.Start;

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
            this.State = CambiarDatosState.Start;
            this.NombreEmpresa = null;
            this.UbicacionData = null;
            this.Contacto = 0;
            this.EmpresaUsuario = null;
        }

        /// <summary>
        /// Indica los diferentes estados que puede tener el comando CambiarDatosState.
        /// </summary>
        public enum CambiarDatosState
        {
            ///-Start: Es el estado inicial del comando. En este estado el comando pide /cambiardatos
            Start,

            ///-NombrePrompt: En este estado el comando pide que coloques el nombre de la empresa a la cual
            ///quieres cambiar.
            NombrePrompt,

            ///-UbicacionPrompt: En este estado el comando pide que coloques la ubicación por la cual quieres
            ///cambiar.
            UbicacionPrompt,

            ///-ContactoPrompt: En este estado el comando pide que coloques el contacto por el cual quieres
            ///cambiar.
            ContactoPrompt
        }
    }
}