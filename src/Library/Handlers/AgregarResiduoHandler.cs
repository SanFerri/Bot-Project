using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "distancia".
    /// </summary>
    public class AgregarResiduoHandler : BaseHandler
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        public AgregarResiduoState State { get; private set; }

        /// <summary>
        /// Los datos que va obteniendo el comando en los diferentes estados.
        /// </summary>
        public Empresa empresaUsuario { get; private set; }
        public string nombreResiduo { get; private set; }
        public int volumenResiduo { get; private set; }
        public string unidadResiduo { get; private set; }
        public int costoResiduo { get; private set; }
        public string monedaResiduo { get; private set; }
        public AgregarResiduoHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/agregarresiduo" };
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
            if (State == AgregarResiduoState.Start && message == "/agregarresiduo" && realEmpresario == true)
            {
                this.State = AgregarResiduoState.NombrePrompt;
                response = "Ingrese el tipo del residuo que quiere agregar.";

                return true;
            }
            else if (State == AgregarResiduoState.NombrePrompt)
            {
                // En el estado FromAddressPrompt el mensaje recibido es la respuesta con la dirección de origen
                this.nombreResiduo = message;
                this.State = AgregarResiduoState.CantidadPrompt;
                response = "Ahora ingrese la cantidad que posees de dicho residuo";
                return true;
            }
            else if (State == AgregarResiduoState.CantidadPrompt)
            {
                this.volumenResiduo = Convert.ToInt32(message);;
                this.State = AgregarResiduoState.UnidadPrompt;
                response = "Ingrese la unidad del volumen dado previamente";

                return true;
            }
            else if (State == AgregarResiduoState.UnidadPrompt && (message == "kg" || message == "g" || message == "l"))
            {
                this.unidadResiduo = message;
                this.State = AgregarResiduoState.CostoPrompt;
                response = "Ingrese el costo y/o valor del residuo";

                return true;
            }
            else if (State == AgregarResiduoState.CostoPrompt)
            {
                this.costoResiduo = Convert.ToInt32(message);
                this.State = AgregarResiduoState.MonedaPrompt;
                response = "Ingrese la moneda $ o U$S";

                return true;
            }
            else if (State == AgregarResiduoState.MonedaPrompt)
            {
                this.monedaResiduo = message;
                Residuo residuo = new Residuo(this.nombreResiduo, this.volumenResiduo, this.unidadResiduo, this.costoResiduo, this.monedaResiduo);
                this.empresaUsuario.residuos.AddResiduo(residuo);
                this.State = AgregarResiduoState.Start;
                response = $"Se ha agregado el residuo {this.nombreResiduo}";

                return true;
            }
            else if (realEmpresario == false)
            {
                response = "Usted no es un empresario, no puede acceder a este comando";
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
            this.State = AgregarResiduoState.Start;
            this.monedaResiduo = null;
            this.nombreResiduo = null;
            this.unidadResiduo = null;
            this.volumenResiduo = 0;
            this.costoResiduo = 0;
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
        public enum AgregarResiduoState
        {
            Start,
            NombrePrompt,
            CantidadPrompt,
            UnidadPrompt,
            CostoPrompt,
            MonedaPrompt
        }
    }
}