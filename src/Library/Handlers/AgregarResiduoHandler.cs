using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "AgregarResiduo".
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
        public Empresa EmpresaUsuario { get; private set; }

        /// <summary>
        /// Es el nombre del residuo publicado.
        /// </summary>
        /// <value></value>
        public string NombreResiduo { get; private set; }

        /// <summary>
        /// La cantidad del residuo que hay.
        /// </summary>
        /// <value></value>
        public int VolumenResiduo { get; private set; }

        /// <summary>
        /// Es la unidad con la cual se mide el residuo, por ejemplo (kg, toneladas, etc.)
        /// </summary>
        /// <value></value>
        public string UnidadResiduo { get; private set; }

        /// <summary>
        /// Es el costo monetario del residuo.
        /// </summary>
        /// <value></value>
        public int CostoResiduo { get; private set; }

        /// <summary>
        /// Lista de todos los empresarios que hay.
        /// </summary>
        /// <returns></returns>

        public ListaEmpresarios LosEmpresarios = ListaEmpresarios.GetInstance();

        /// <summary>
        /// Es la moneda con la cual se va a cobrar el residuo, por ejemplo (pesos uruguayos, dolares, etc.)
        /// </summary>
        /// <value></value>
        public string MonedaResiduo { get; private set; }

        /// <summary>
        /// Esta clase procesa el mensaje /agregarresiduo. 
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public AgregarResiduoHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/agregarresiduo" };
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
            foreach(Empresario empresario in this.LosEmpresarios.Empresarios)
            {
                if(empresario.Id == id)
                {
                    this.EmpresaUsuario = empresario.Empresa;
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
                this.NombreResiduo = message;
                this.State = AgregarResiduoState.CantidadPrompt;
                response = "Ahora ingrese la cantidad que posees de dicho residuo";
                return true;
            }
            else if (State == AgregarResiduoState.CantidadPrompt)
            {
                this.VolumenResiduo = Convert.ToInt32(message);;
                this.State = AgregarResiduoState.UnidadPrompt;
                response = "Ingrese la unidad del volumen dado previamente";

                return true;
            }
            else if (State == AgregarResiduoState.UnidadPrompt && (message == "kg" || message == "g" || message == "l"))
            {
                this.UnidadResiduo = message;
                this.State = AgregarResiduoState.CostoPrompt;
                response = "Ingrese el costo y/o valor del residuo";

                return true;
            }
            else if (State == AgregarResiduoState.CostoPrompt)
            {
                this.CostoResiduo = Convert.ToInt32(message);
                this.State = AgregarResiduoState.MonedaPrompt;
                response = "Ingrese la moneda $ o U$S";

                return true;
            }
            else if (State == AgregarResiduoState.MonedaPrompt)
            {
                this.MonedaResiduo = message;
                Residuo residuo = new Residuo(this.NombreResiduo, this.VolumenResiduo, this.UnidadResiduo, this.CostoResiduo, this.MonedaResiduo);
                this.EmpresaUsuario.Residuos.AddResiduo(residuo);
                this.State = AgregarResiduoState.Start;
                response = $"Se ha agregado el residuo {this.NombreResiduo}";

                return true;
            }
            else if (realEmpresario == false && message == "/agregarresiduo")
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
            this.MonedaResiduo = null;
            this.NombreResiduo = null;
            this.UnidadResiduo = null;
            this.VolumenResiduo = 0;
            this.CostoResiduo = 0;
            this.EmpresaUsuario = null;
        }
        
        /// <summary>
        ///  Indica los diferentes estados que puede tener el comando AgregarResiduoState.
        /// </summary>
        public enum AgregarResiduoState
        {
            ///-Start: Es el estado inicial del comando.
            Start,

            ///-NombrePrompt: Es el estado donde se pide el nombre del tipo de residuo. 
            NombrePrompt,

            ///-CantidadPrompt: Es el estado donde se pide la cantidad del tipo de residuo.
            CantidadPrompt,

            ///-UnidadPrompt: Es el estado donde se pide la unidad la cual es medido el residuo, por 
            ///ejemplo: kg, toneladas, etc.
            UnidadPrompt,

            ///-CostoPrompt: Es el estado en donde se pide el costo del residuo.
            CostoPrompt,

            ///-MonedaPrompt: Es el estado en donde se pide con que moneda se va a cobrar el residuo.
            MonedaPrompt
        }
    }
}