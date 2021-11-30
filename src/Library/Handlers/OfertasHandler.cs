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
        /// Es la ubicación donde se encuentra el producto.
        /// </summary>
        public Ubicacion UbicacionData { get; private set; }

        /// <summary>
        /// Los tipos de residuos.
        /// </summary>
        /// <value></value>
        public string ResiduoTipo { get; private set; }

        /// <summary>
        /// Es el usuario registrado de la empresa.
        /// </summary>
        /// <value></value>
        public Empresa EmpresaUsuario { get; private set; }

        /// <summary>
        /// La eleccion número de la oferta de la cual quiere obtener el usuario.
        /// </summary>
        /// <value></value>
        public int Eleccion { get; private set; }

        /// <summary>
        /// Es una lista que almacena las publicaciones que hay.
        /// </summary>
        /// <value></value>
        public List<Publicacion> OfertasData { get; private set; }


        /// <summary>
        /// La palabra clave la cual quiere el emprendedor.
        /// </summary>
        /// <value></value>
        public string PalabraClave { get; private set; }
        
        /// <summary>
        /// Es una lista que contiene las palabras claves que se pueden usar.
        /// </summary>
        /// <value></value>
        
        public ListaPalabrasClave LasClaves = ListaPalabrasClave.GetInstance();

        /// <summary>
        /// Property booleana que indica si se quiere o no realizar una busqueda con palabra clave.
        /// </summary>
        /// <value></value>
        public bool BuscarConPalabraClave { get; private set; }

        /// <summary>
        /// Los emprendedores que usan este handler.
        /// </summary>
        /// <value></value>

        public Emprendedor Emprendedor { get; private set; }

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
            bool realEmprendedor = false;
            foreach(Emprendedor emprendedor in ListaUsuarios.GetInstance().Usuarios)
            {
                if (emprendedor.Id == id)
                {
                    this.Emprendedor = emprendedor;
                    realEmprendedor = true;
                }
            }

            if (realEmprendedor == true)
            {
                if (Emprendedor.State == "OH-CP")
                {
                    State = OfertasState.ClavePrompt;
                }
                else if (Emprendedor.State == "OH-RCP")
                {
                    this.State = OfertasState.RespuestaClavePrompt;
                }
                else if (Emprendedor.State == "OH-UP")
                {
                    this.State = OfertasState.UbicacionPrompt;
                }
                else if (Emprendedor.State == "OH-RP")
                {
                    this.State = OfertasState.ResiduoPrompt;
                }
                else if (Emprendedor.State == "OH-NP")
                {
                    this.State = OfertasState.NumeroPrompt;
                }
            }

            if(State ==  OfertasState.Start && message == "/ofertas" && realEmprendedor == true)
            {
                // En el estado Start le pide la dirección de origen y pasa al estado ClavePrompt
                this.Emprendedor.State = "OH-CP";
                response = "¿Quieres realizar tu busqueda usando una palabra clave? Responda si o no";
                this.State = OfertasState.Start;
                return true;
            }
            else if (State == OfertasState.ClavePrompt)
            {
                if(message == "si")
                {
                    int contador = 0;
                    this.BuscarConPalabraClave = true;
                    string unfinishedResponse = "Ingrese el numero de la palabra clave que buscar:\n";
                    foreach(string palabra in this.LasClaves.Palabras)
                    {
                        unfinishedResponse += $"{contador}. {palabra}.\n";
                        contador += 1;
                    }
                    response = unfinishedResponse;
                    this.Emprendedor.State = "OH-RCP";
                    this.State = OfertasState.Start;
                    return true;
                }
                else
                {
                    this.BuscarConPalabraClave = false;
                    this.Emprendedor.State = "OH-UP";
                    this.State = OfertasState.Start;
                    response = "¿Cual es tu direccion? (Asi encontraremos publicaciones por proximidad)";

                    return true;
                }
            }
            else if (State == OfertasState.RespuestaClavePrompt)
            {
                this.Emprendedor.State = "OH-UP";
                this.State = OfertasState.Start;
                this.PalabraClave = this.LasClaves.Palabras[(Convert.ToInt32(message))];
                response = "¿Cual es tu direccion? (Asi encontraremos publicaciones por proximidad)";

                return true;
            }
            else if (State == OfertasState.UbicacionPrompt)
            {
                // En el estado OfertasState.ResiduoPrompt el mensaje recibido es el residuo que se esta buscando.
                this.UbicacionData = new Ubicacion(message);
                this.Emprendedor.State = "OH-RP";
                this.State = OfertasState.Start;
                int contador = 0;
                string unfinished = "Ingrese el tipo del residuo que quiere buscar:\n";
                foreach(string residuo in PosiblesResiduos.GetInstance().Residuos)
                {
                    unfinished += $"{contador}. {residuo}\n";
                    contador += 1;
                }
                response = unfinished;

                return true;
            }
            else if (State == OfertasState.ResiduoPrompt)
            {   
                response = "";
                /// <summary>

                /// Utilizamos este bloque de código para atrapar dos excepciones (System.FormatExcepetion) y (System.ArgumentOutOfRangeException)
                /// la cual la primera ocurre si el usuario ingresa una letra en vez de un número, y la segunda ocurre si el usuario ingresa un argumento 
                /// cuyo valor este fuera de el rango de valores definidos por el método invocado.
                /// Cualquiera de estas dos excepciones de no ser manejadas provocarían un error que terminaria con el funcionamiento del bot.
                /// </summary>
                /// <value></value>
                try
                {
                    this.ResiduoTipo = PosiblesResiduos.GetInstance().Residuos[Convert.ToInt32(message)];
                }
                catch (System.FormatException)
                {
                    response = "Usted no ha ingresado un número válido, porfavor intentelo nuevamente";
                    this.State = OfertasState.Start;
                    this.Emprendedor.State = "OH-RP";
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    response = "Usted no ha ingresado un número válido, porfavor intentelo nuevamente";
                    this.State = OfertasState.Start;
                    this.Emprendedor.State = "OH-RP";
                }
                /*
                finally
                {
                    this.State = OfertasState.Start;
                }
                */
                if(this.BuscarConPalabraClave == false && response != "Usted no ha ingresado un número válido, porfavor intentelo nuevamente")
                {
                    int contador = 0;
                    string builderResponse = "";
                    this.OfertasData = Buscador.Buscar(this.ResiduoTipo, this.UbicacionData);
                    builderResponse += "Ingrese el número de la publicación para ver más información de la misma:\n"; 
                    foreach(Publicacion publicacion in this.OfertasData)
                    {
                        builderResponse += ($"{contador}. {publicacion.Empresa.Nombre} ofrece: {publicacion.Residuo.Cantidad} kg de {publicacion.Residuo.Tipo} en {publicacion.Ubicacion.Direccion}. Ademas la habilitacion para conseguir estos residuos es: {publicacion.Habilitacion}\n");
                        contador += 1;
                    }   
                    if(this.OfertasData == new List<Publicacion>())
                    {
                        // Si no encuentra alguna publicacion se las pide de nuevo y vuelve al estado ResiduosPrompt.
                        // Una versión más sofisticada podría determinar cuál de las dos direcciones no existe y volver al
                        // estado en el que se pide la dirección que falta.
                        response = "No se ha podido encontrar una publicacion en esa categoría, vuelva a intentarlo en otro momento.";
                        this.Emprendedor.State = "start";
                        this.State = OfertasState.Start;

                        return false;
                    }
                    else
                    {
                        response = builderResponse;
                        this.Emprendedor.State = "OH-NP";
                        this.State = OfertasState.Start;

                        return false;
                    }
                }
                else if (response != "Usted no ha ingresado un número válido, porfavor intentelo nuevamente")
                {
                    this.OfertasData = Buscador.Buscar(PalabraClave);
                    int contador = 0;
                    string builderResponse = "";
                    bool existenPublicaciones = false;
                    builderResponse += "Ingrese el número de la publicación para ver más información de la misma:\n"; 
                    foreach(Publicacion publicacion in this.OfertasData)
                    {
                        builderResponse += ($"{contador}. {publicacion.Empresa.Nombre} ofrece: {publicacion.Residuo.Cantidad} kg de {publicacion.Residuo.Tipo} en {publicacion.Ubicacion.Direccion}. Ademas la habilitacion para conseguir estos residuos es: {publicacion.Habilitacion}\n");
                        contador += 1;
                        existenPublicaciones = true;
                    }   
                    if(existenPublicaciones == false)
                    {
                        // Si no encuentra alguna publicacion se las pide de nuevo y vuelve al estado ResiduosPrompt.
                        // Una versión más sofisticada podría determinar cuál de las dos direcciones no existe y volver al
                        // estado en el que se pide la dirección que falta.
                        response = "No se ha podido encontrar una publicacion en esa categoría, vuelva a intentarlo en otro momento.";
                        this.Emprendedor.State = "start";
                        this.State = OfertasState.Start;

                        return false;
                    }
                    else
                    {
                        response = builderResponse;
                        this.Emprendedor.State = "OH-NP";
                        this.State = OfertasState.Start;

                        return true;
                    }

                }
                else
                {
                    return true;
                }
                
            }
            else if (State == OfertasState.NumeroPrompt)
            {
                response = "";
                /// <summary>
                /// Utilizamos este bloque de código para atrapar dos excepciones (System.FormatExcepetion) y (System.ArgumentOutOfRangeException)
                /// la cual la primera ocurre si el usuario ingresa una letra en vez de un número, y la segunda ocurre si el usuario ingresa un argumento 
                /// cuyo valor este fuera de el rango de valores definidos por el método invocado.
                /// Cualquiera de estas dos excepciones de no ser manejadas provocarían un error que terminaria con el funcionamiento del bot.
                /// </summary>
                /// <value></value>
                try
                {
                    this.Eleccion = Convert.ToInt32(message);
                    Publicacion publicacion = this.OfertasData[this.Eleccion];
                }
                catch (System.FormatException)
                {
                    response = "Usted no ha ingresado un número válido, porfavor intentelo nuevamente";
                    this.State = OfertasState.Start;
                    this.Emprendedor.State = "OH-NP";
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    response = "Usted no ha ingresado un número válido, porfavor intentelo nuevamente";
                    this.State = OfertasState.Start;
                    this.Emprendedor.State = "OH-NP";
                }
    
                if (response != "Usted no ha ingresado un número válido, porfavor intentelo nuevamente")
                {    
                    Publicacion publicacion = this.OfertasData[this.Eleccion];
                    response = $"El número de contacto de esta publicación es {publicacion.Empresa.Contacto}";
                    this.Emprendedor.State = "start";
                    this.State = OfertasState.Start;

                    return false;
                }
                else
                {
                    return false;
                }
            }            
            else
            {
                Console.WriteLine("Entro a Ofertas handler :(");
                response = string.Empty;
                this.State = OfertasState.Start;

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
            this.ResiduoTipo = null;
            this.EmpresaUsuario = null;
            this.OfertasData = null;
            this.LasClaves = null;
        }

        /// <summary>
        /// Indica los diferentes estados que puede tener el comando OfertasState.
        /// </summary>
        public enum OfertasState
        {

            ///-Start: El estado inicial del comando. En este estado el comando pide la dirección de origen 
            ///y pasa al siguiente estado.
            Start,
            
            ///-ClavePrompt: En este estado el comando pregunta si el usuario quiere utilizar una palabra clave, mostrandole las 
            ///palabras clave disponibles y pasa al siguiente estado.
            ClavePrompt,

            ///-RespuestaClavePrompt: En este estado el comando le pide al usuario el número de la palabra clave 
            /// que desea utilizar y pasa al siguiente estado.
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