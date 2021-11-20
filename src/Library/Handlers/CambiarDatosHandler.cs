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
        /// Los datos que va obteniendo el comando en los diferentes estados.
        /// </summary>
        public Empresa empresaUsuario { get; private set; }

        /// <summary>
        /// Es el nombre de la empresa.
        /// </summary>
        /// <value></value>
        public string nombreEmpresa { get; private set; }

        /// <summary>
        /// Es la ubicación de la empresa.
        /// </summary>
        /// <value></value>
        public Ubicacion UbicacionData { get; private set; }

        /// <summary>
        /// Es el contacto de la empresa.
        /// </summary>
        /// <value></value>
        public int contacto { get; private set; }

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
                    this.empresaUsuario = empresario.Empresa;
                    realEmpresario = true;
                }
            }
            if (State == CambiarDatosState.Start && message == "/cambiardatos" && realEmpresario == true)
            {
                this.State = CambiarDatosState.NombrePrompt;
                response = "Ingrese el nombre de su empresa.";

                return true;
            }
            else if (State == CambiarDatosState.NombrePrompt)
            {
                // En el estado FromAddressPrompt el mensaje recibido es la respuesta con la dirección de origen
                this.nombreEmpresa = message;
                this.State = CambiarDatosState.UbicacionPrompt;
                response = "Ahora dime la ubicacion de dicha empresa";
                return true;
            }
            else if (State == CambiarDatosState.UbicacionPrompt)
            {
                this.UbicacionData = new Ubicacion(message);
                this.State = CambiarDatosState.ContactoPrompt;
                response = "Por ultimo dime el contacto de la empresa";

                return true;
            }
            else if (State == CambiarDatosState.ContactoPrompt)
            {
                this.empresaUsuario.Contacto = message;
                this.empresaUsuario.Nombre = this.nombreEmpresa;
                this.empresaUsuario.Ubicacion = this.UbicacionData;

                response = "Se han actualizado sus datos...";

                this.State = CambiarDatosState.Start;
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
            this.State = CambiarDatosState.Start;
            this.nombreEmpresa = null;
            this.UbicacionData = null;
            this.contacto = 0;
            this.empresaUsuario = null;
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