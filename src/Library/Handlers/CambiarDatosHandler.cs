using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "distancia".
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
        public string nombreEmpresa { get; private set; }
        public Ubicacion UbicacionData { get; private set; }
        public int contacto { get; private set; }
        public CambiarDatosHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/cambiardatos" };
        }


        /// <summary>
        /// Procesa todos los mensajes y retorna true siempre.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado indicando que el mensaje no pudo se procesado.</param>
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
                this.empresaUsuario.contacto = Convert.ToInt32(message);
                this.empresaUsuario.nombre = this.nombreEmpresa;
                this.empresaUsuario.ubicacion = this.UbicacionData;

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
        /// Indica los diferentes estados que puede tener el comando DistanceHandler.
        /// - Start: El estado inicial del comando. En este estado el comando pide la dirección de origen y pasa al
        /// siguiente estado.
        /// - FromAddressPrompt: Luego de pedir la dirección de origen. En este estado el comando pide la dirección de
        /// destino y pasa al siguiente estado.
        /// - ToAddressPrompt: Luego de pedir la dirección de destino. En este estado el comando calcula la distancia
        /// y vuelve al estado Start.
        /// </summary>
        public enum CambiarDatosState
        {
            Start,
            NombrePrompt,
            UbicacionPrompt,
            ContactoPrompt
        }
    }
}