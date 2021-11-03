using System;
using System.Text;
using System.Collections.Generic;

namespace ClassLibrary
{
    /// <summary>
    /// Un "handler" del patrón Chain of Responsibility que implementa el comando "Ofertas".
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

        /// <summary>
        /// Los tipos de residuos.
        /// </summary>
        /// <value></value>
        public string residuoTipo { get; private set; }

        /// <summary>
        /// Es el resultado de la busqueda del emprendedor.
        /// </summary>
        /// <value></value>

        public Publicacion result { get; private set; }

        /// <summary>
        /// Es el usuario registrado de la empresa.
        /// </summary>
        /// <value></value>
        public Empresa empresaUsuario { get; private set; }

        /// <summary>
        /// La eleccion número de la oferta de la cual quiere obtener el usuario.
        /// </summary>
        /// <value></value>
        public int Eleccion { get; private set; }

        /// <summary>
        /// Es una lista que almacena las publicaciones que hay.
        /// </summary>
        /// <value></value>
        public List<Publicacion> ofertasData { get; private set; }

        /// <summary>
        /// La palabra clave la cual quiere el emprendedor.
        /// </summary>
        /// <value></value>
        public string PalabraClave { get; private set; }

        /// <summary>
        /// Esta clase procesa el mensaje /ofertas.
        /// </summary>
        /// <param name="next"></param>
        /// <returns></returns>
        public OfertasHandler(BaseHandler next) : base(next)
        {
            this.Keywords = new string[] { "/ofertas" };
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
            if(State ==  OfertasState.Start && message == "/ofertas")
            {
                // En el estado Start le pide la dirección de origen y pasa al estado FromAddressPrompt
                this.State = OfertasState.ClavePrompt;
                response = "¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no";
                return true;
            }
            else if (State == OfertasState.ClavePrompt)
            {
                if(message == "si")
                {
                    ListaPalabrasClave claves = new ListaPalabrasClave();
                    int contador = 0;
                    string unfinishedResponse = "Ingrese el numero de la palabra clave que buscar:\n";
                    foreach(string palabra in ListaPalabrasClave.palabras)
                    {
                        unfinishedResponse += $"{contador}. {palabra}.\n";
                        contador += 1;
                    }
                    response = unfinishedResponse;
                    this.State = OfertasState.RespuestaClavePrompt;
                    return true;
                }
                else
                {
                    this.State = OfertasState.UbicacionPrompt;
                    response = "¿Cual es tu direccion? (Asi encontraremos publicaciones por proximidad)";
                    return true;
                }
            }
            else if (State == OfertasState.RespuestaClavePrompt)
            {
                this.State = OfertasState.UbicacionPrompt;
                this.PalabraClave = ListaPalabrasClave.palabras[(Convert.ToInt32(message))];
                response = "¿Cual es tu direccion? (Asi encontraremos publicaciones por proximidad)";
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
                string builderResponse = "";
                this.residuoTipo = message;
                this.ofertasData = Buscador.Buscar(this.residuoTipo, this.UbicacionData);
                builderResponse += "Ingrese el número de la publicación para ver más información de la misma:\n"; 
                foreach(Publicacion publicacion in this.ofertasData)
                {
                    builderResponse += ($"{contador}. {publicacion.empresa.nombre} ofrece: {publicacion.residuo.cantidad} kg de {publicacion.residuo.tipo} en {publicacion.ubicacion.direccion}. Ademas la habilitacion para conseguir estos residuos es: {publicacion.habilitacion}\n");
                    contador += 1;
                }   
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
                    response = builderResponse;
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
            this.empresaUsuario = null;
            this.result = null;
            this.ofertasData = null;
        }

        /// <summary>
        /// Indica los diferentes estados que puede tener el comando OfertasState.
        /// </summary>
        public enum OfertasState
        {

            ///-Start: El estado inicial del comando. En este estado el comando pide la dirección de origen 
            ///y pasa al siguiente estado.
            Start,

            ///-ClavePrompt: En este estado va a mostrarle al usuario las palabras claves que hay.
            ClavePrompt,

            ///-RespuetasClavePrompt: En este estado tiene que elegir la palabra clave.
            RespuestaClavePrompt,

            ///-UbicacionPrompt: Luego de pedir la dirección de origen. En este estado el comando pide la dirección de 
            ///destino y pasa al siguiente estado.
            UbicacionPrompt,

            ///-ResiduoPrompt: Luego de pedir la dirección de destino. En este estado el comando calcula la distancia
            ///y vuelve al estado Start.
            ResiduoPrompt,

            ///-NumeroPrompt: En este estado el comando envia el numero de ese tipo de ofertas que hay.
            NumeroPrompt
        }
    }
}