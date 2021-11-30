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
        /// Es el usuario de la empresa.
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
        /// Lista que tiene las posibles unidades.
        /// </summary>
        /// <value></value>

        public List<string> LasUnidades = new List<string>{"g", "kg", "t", "l"};

        /// <summary>
        /// Son los empresarios que estan usando los handlers.
        /// </summary>
        /// <value></value>

        public Empresario Empresario { get; private set; }

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
            this.State = AgregarResiduoState.Start;
            bool realEmpresario = false;
            foreach(Empresario empresario in this.LosEmpresarios.Empresarios)
            {
                if(empresario.Id == id)
                {
                    this.EmpresaUsuario = empresario.Empresa;
                    realEmpresario = true;
                    Console.WriteLine("Es un empresario");
                    this.Empresario = empresario;
                }
            }

            if(realEmpresario == true)
            {
                if (Empresario.State == "ARH-NP")
                {
                    State = AgregarResiduoState.NombrePrompt;
                }
                else if (Empresario.State == "ARH-CP")
                {
                    this.State = AgregarResiduoState.CantidadPrompt;
                }
                else if (Empresario.State == "ARH-UP")
                {
                    this.State = AgregarResiduoState.UnidadPrompt;
                }
                else if (Empresario.State == "ARH-CP2")
                {
                    this.State = AgregarResiduoState.CostoPrompt;
                }
                else if (Empresario.State == "ARH-MP")
                {
                    this.State = AgregarResiduoState.MonedaPrompt;
                }
            }

            if (State == AgregarResiduoState.Start && message == "/agregarresiduo" && realEmpresario == true)
            {
                int contador = 0;
                Empresario.State = "ARH-NP";
                string unfinished = "Ingrese el tipo del residuo que quiere agregar:\n";
                foreach(string residuo in PosiblesResiduos.GetInstance().Residuos)
                {
                    unfinished += $"{contador}. {residuo}\n";
                    contador += 1;
                }
                this.State = AgregarResiduoState.Start;
                response = unfinished;

                return true;
            }
            else if (State == AgregarResiduoState.NombrePrompt)
            {
                // En el estado AgregarResiduosState el mensaje recibido es la respuesta con la cantidad que posee del residuo en cuestion.
                this.NombreResiduo = PosiblesResiduos.GetInstance().Residuos[Convert.ToInt32(message)];
                Empresario.State = "ARH-CP";
                response = "Ahora ingrese la cantidad que posees de dicho residuo (Sin la unidad)";
                this.State = AgregarResiduoState.Start;

                return true;
            }
            else if (State == AgregarResiduoState.CantidadPrompt)
            {
                int contador = 0;
                this.VolumenResiduo = Convert.ToInt32(message);;
                Empresario.State = "ARH-UP";
                string unfinishedResponse = "Ingrese el numero de la unidad:\n";
                foreach(string palabra in this.LasUnidades)
                {
                    unfinishedResponse += $"{contador}. {palabra}.\n";
                    contador += 1;
                }
                response = unfinishedResponse;

                this.State = AgregarResiduoState.Start;

                return true;
            }
            else if (State == AgregarResiduoState.UnidadPrompt)
            {
                this.UnidadResiduo = this.LasUnidades[Convert.ToInt32(message)];
                Empresario.State = "ARH-CP2";
                response = "Ingrese el costo y/o valor del residuo";
                this.State = AgregarResiduoState.Start;

                return true;
            }
            else if (State == AgregarResiduoState.CostoPrompt)
            {
                this.CostoResiduo = Convert.ToInt32(message);
                Empresario.State = "ARH-MP";
                response = "Ingrese la moneda $ o U$S";
                this.State = AgregarResiduoState.Start;

                return true;
            }
            else if (State == AgregarResiduoState.MonedaPrompt)
            {
                if(message == "$" || message == "U$S")
                {
                    this.MonedaResiduo = message;
                    Residuo residuo = new Residuo(this.NombreResiduo, this.VolumenResiduo, this.UnidadResiduo, this.CostoResiduo, this.MonedaResiduo);
                    this.EmpresaUsuario.Residuos.AddResiduo(residuo);
                    Empresario.State = "start";
                    response = $"Se ha agregado el residuo {this.NombreResiduo}";
                    this.State = AgregarResiduoState.Start;

                    return true;
                }
                else
                {
                    response = "No has ingresado una moneda valida, vuelve a intentarlo.";
                    this.State = AgregarResiduoState.Start;

                    return true;
                }
            }
            else if (realEmpresario == false && message == "/agregarresiduo")
            {
                response = "Usted no es un empresario, no puede acceder a este comando";
                this.State = AgregarResiduoState.Start;

                return false;
            }
            else
            {
                response = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Resetea el estado del handler.
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