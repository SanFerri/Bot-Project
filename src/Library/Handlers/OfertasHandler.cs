using System;
using System.Text;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "ofertas".
    /// </summary>
    
    public class OfertasHandler : BaseHandler
    {
        /// <summary>
        /// El estado del comando.
        /// </summary>
        public OfertasState State { get; private set; }

        /// <summary>
        /// Los datos que va obteniendo el comando en los diferentes estados.
        /// </summary>
        public Ubicacion UbicacionData { get; private set; }

        public string residuoTipo { get; private set; }
        public Residuo ResiduoElegido { get; private set; }
        public Publicacion result { get; private set; }
        public Empresa empresaUsuario { get; private set; }
        public int Eleccion { get; private set; }
        public List<Publicacion> ofertasData { get; private set; }

        public OfertasHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/ofertas" };
        }


        /// <summary>
        /// Procesa todos los mensajes y retorna true siempre.
        /// </summary>
        /// <param name="message">El mensaje a procesar.</param>
        /// <param name="response">La respuesta al mensaje procesado indicando que el mensaje no pudo se procesado.</param>
        /// <returns>true si el mensaje fue procesado; false en caso contrario.</returns>
        protected override bool InternalHandle(string message, int id, out string response)
        {
            if(State ==  OfertasState.Start && message == "/ofertas")
            {
                // En el estado Start le pide la dirección de origen y pasa al estado FromAddressPrompt
                this.State = OfertasState.UbicacionPrompt;
                response = "¿Cual es tu ubicación?";
                return true;
            }
            else if (State == OfertasState.UbicacionPrompt)
            {
                // En el estado FromAddressPrompt el mensaje recibido es la respuesta con la dirección de origen
                this.UbicacionData = new Ubicacion(message);
                this.State = OfertasState.ResiduoPrompt;
                response = "Ahora dime que tipo de residuos estas buscando?";
                return true;
            }
            else if (State == OfertasState.ResiduoPrompt)
            {
                int contador = 0;
                StringBuilder builderResponse = new StringBuilder("");
                this.residuoTipo = message;
                this.ofertasData = Buscador.Buscar(this.residuoTipo, this.UbicacionData);
                foreach(Publicacion publicacion in this.ofertasData)
                {
                    builderResponse.Append($"{contador}. {publicacion.empresa.nombre} ofrece: {publicacion.residuo.cantidad} kg de {publicacion.residuo.tipo} en {publicacion.ubicacion}\n");
                }
                builderResponse.Append("Ingrese el número de la publicación para ver más información de la misma");    
                if(this.ofertasData == new List<Publicacion>())
                {
                    // Si no encuentra alguna publicacion se las pide de nuevo y vuelve al estado ResiduosPrompt.
                    // Una versión más sofisticada podría determinar cuál de las dos direcciones no existe y volver al
                    // estado en el que se pide la dirección que falta.
                    response = "No se ha podido encontrar una publicacion en esa categoría, vuelva a intentarlo en otro momento.";
                    this.State = OfertasState.Start;

                    return false;
                }
                else
                {
                    response = builderResponse.ToString();
                    this.State = OfertasState.NumeroPrompt;

                    return true;
                }

            }
            else if (State == OfertasState.NumeroPrompt)
            {
                this.Eleccion = Convert.ToInt32(message);
                Publicacion publicacion = this.ofertasData[this.Eleccion];
                response = $"El número de contacto de esta publicación es {publicacion.empresa.contacto}";

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
            this.State = OfertasState.Start;
            this.UbicacionData = null;
            this.residuoTipo = null;
            this.ResiduoElegido = null;
            this.empresaUsuario = null;
        }
        /// <summary>
        /// Indica los diferentes estados que puede tener el comando OfertasHandler.
        /// - Start: El estado inicial del comando. En este estado el comando pide la dirección de origen y pasa al
        /// siguiente estado.
        /// - UbicacionPrompt: Luego de pedir la dirección de origen. En este estado el comando pide la dirección de
        /// destino y pasa al siguiente estado.
        /// - ResiduoPrompt: Luego de pedir la dirección de destino. En este estado el comando calcula la distancia
        /// y vuelve al estado Start.
        /// </summary>
        public enum OfertasState
        {
            Start,
            UbicacionPrompt,
            ResiduoPrompt,
            NumeroPrompt
        }
    }
}
