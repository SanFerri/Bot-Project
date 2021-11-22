using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Publicar".
    /// </summary>
    public class PublicarHandler : BaseHandler
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        public PublicarState State { get; private set; }

        /// <summary>
        /// Es la ubicación.
        /// </summary>
        public Ubicacion UbicacionData { get; private set; }

        /// <summary>
        /// Es una lista que alamacena las palabras claves que hay.
        /// </summary>
        /// <value></value>

        public ListaPalabrasClave clave { get; private set; }

        /// <summary>
        /// Son el tipo de residuo publicado.
        /// </summary>
        /// <value></value>
        public string ResiduoTipo { get; private set; }

        /// <summary>
        /// Es el residuo elegido. 
        /// </summary>
        /// <value></value>
        public Residuo ResiduoElegido { get; private set; }

        /// <summary>
        /// Las palabras claves que hay.
        /// </summary>
        /// <value></value>
        public string PalabraClave { get; private set; }

        /// <summary>
        /// Es el resultado de la publicación.
        /// </summary>
        /// <value></value>
        public Publicacion Result { get; private set; }

        /// <summary>
        /// Es el usuario de la empresa.
        /// </summary>
        /// <value></value>
        public Empresa EmpresaUsuario { get; private set; }

        /// <summary>
        /// Son los datos de la habilitación.
        /// </summary>
        /// <value></value>
        public string HabilitacionData { get; private set; }

        /// <summary>
        /// Indica si un residuo es generado constantemente.
        /// </summary>
        /// <value></value>
        public bool Constante { get; private set; }
        public Empresario Empresario { get; private set; }
        public ListaEmpresarios LosEmpresarios { get; private set; }

        /// <summary>
        /// Es una lista de las palabras clave que se pueden añadir a una publicación.
        /// </summary>
        /// <returns></returns>

        public ListaPalabrasClave LasClaves= ListaPalabrasClave.GetInstance();

        /// <summary>
        /// Esta clase procesa el mensaje /publicar.
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public PublicarHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/publicar" };
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
                    this.Empresario = empresario;
                }
            }
            if(realEmpresario == true)
            {
                if (Empresario.State == "PH-PCP")
                {
                    State = PublicarState.PalabrasClavePrompt;
                }
                else if (Empresario.State == "PH-HP")
                {
                    this.State = PublicarState.HabilitacionPrompt;
                }
                else if (Empresario.State == "PH-CP")
                {
                    this.State = PublicarState.ConstantePrompt;
                }
                else if (Empresario.State == "PH-UP")
                {
                    this.State = PublicarState.UbicacionPrompt;
                }
                else if (Empresario.State == "PH-RP")
                {
                    this.State = PublicarState.ResiduoPrompt;
                }
            }

            if(realEmpresario == true && State ==  PublicarState.Start && message == "/publicar")
            {
                // El estado PublicarState.PalabrasClavePrompt espera que el usuario ingrese el número de la palabra clave que 
                //quiere utilizar
                int contador = 0;
                this.Empresario.State = "PH-PCP";
                string unfinishedResponse = "Ingrese el numero de la palabra clave que quiera agregar:\n";
                foreach(string palabra in LasClaves.Palabras)
                {
                    unfinishedResponse += $"{contador}. {palabra}.\n";
                    contador += 1;
                }
                response = unfinishedResponse;
                this.State = PublicarState.Start;

                return true;
            }
            else if (State == PublicarState.PalabrasClavePrompt)
            {
                this.PalabraClave = this.LasClaves.Palabras[(Convert.ToInt32(message))];
                this.Empresario.State = "PH-HP";
                response = "Porfavor ingrese la habilitacion para los residuos.";
                this.State = PublicarState.Start;

                return true;
            }
            else if (State == PublicarState.HabilitacionPrompt)
            {
                this.HabilitacionData = message;
                this.Empresario.State = "PH-UP";
                response = "Porfavor responda si o no, ¿Estos residuos que se generaron se generan de forma constante? Si fue puntual responda no.";
                this.State = PublicarState.Start;

                return true;
            }
            else if (State == PublicarState.UbicacionPrompt)
            {
                if(message == "si")
                {
                    this.Constante = true;
                }
                else if(message == "no")
                {
                    this.Constante = false;
                }
                this.Empresario.State = "PH-CP";
                response = "Porfavor ingrese la direccion de los residuos.";
                this.State = PublicarState.Start;

                return true;
            }
            else if (State == PublicarState.ConstantePrompt)
            {
                // El estado PublicarState.ResiduoPrompt espera que el usuario ingrese el residuo que quiere publicar.
                this.UbicacionData = new Ubicacion(message);
                this.Empresario.State = "PH-RP";
                response = "Ahora dime sobre cual de tus residuos quieres publicar";
                this.State = PublicarState.Start;

                return true;
            }
            else if (State == PublicarState.ResiduoPrompt)
            {
                this.ResiduoTipo = message;
                foreach(Residuo residuo in this.EmpresaUsuario.Residuos.Residuos)
                {
                    if(residuo.Tipo == ResiduoTipo)
                    {
                        this.ResiduoElegido = residuo;
                    }
                }
                this.Result = new Publicacion(this.ResiduoElegido, this.UbicacionData, this.EmpresaUsuario, this.HabilitacionData, this.Constante);
                this.Result.AgregarPalabraClave(this.PalabraClave);
                if(this.ResiduoElegido != null && this.Result != null)
                {
                    response = $"Se ha publicado la oferta de {this.Result.Residuo.Tipo} de la empresa {this.Result.Empresa.Nombre}. En la ubicacion {this.Result.Ubicacion.Direccion}";
                    this.Empresario.State = "start";
                    this.State = PublicarState.Start;

                    return true;
                }
                else
                {
                    // El estado PublicarState.Start responde cuando no se puede crear una publicación.
                    response = "No se ha podido hacer crear la publicacion, vuelva a intentarlo.";
                    this.Empresario.State = "start";
                    this.State = PublicarState.Start;

                    return false;
                }
            }
            else if (realEmpresario == false && message == this.Keywords[0])
            {
                // Responde cuando no es un empresario, de esa manera no puede utilizar el codigo.
                response = "Usted no es un empresario, no puede usar el codigo...";
                this.State = PublicarState.Start;

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
            this.State = PublicarState.Start;
            this.UbicacionData = null;
            this.ResiduoTipo = null;
            this.ResiduoElegido = null;
            this.EmpresaUsuario = null;
        }

        /// <summary>
        /// Indica los diferentes estados que puede tener el comando PublicarState.
        /// </summary>
        public enum PublicarState
        {
            ///-Start: El estado inicial del comando
            Start,

            ///-PalabrasClavePrompt:En este comando pide la palabra clave para pasar al siguiente estado.
            PalabrasClavePrompt,

            ///HabilitacionPrompt: En este comando pide la habilitación para pasar al siguiente estado.
            HabilitacionPrompt,

            ///ConstantePrompt: En este comando se pide si el residuo es constante o no.
            ConstantePrompt,

            ///UbicacionPrompt: En este comando se pide la ubicación donde esta el residuo.
            UbicacionPrompt,

            ///ResiduoPrompt: En este comando se pide que tipo de residuo es.
            ResiduoPrompt
        }
    }
}