namespace ClassLibrary

{
    /// <summary>
    /// Residuo es una clase que conoce la informacion de los residuos publicados, el tipo y la cantidad
    /// de una publicacion hecha por una X empresa.
    /// </summary>
    public class Residuo
    {
        /// <summary>
        /// Es el encargado de conocer el tipo de material que se esta ofreciendo.
        /// </summary>
        /// <value></value>
        public string tipo{get; set;}
        /// <summary>
        /// Es el encargado de conocer la cantidad que hay de cada material.
        /// </summary>
        /// <value></value>
        public int cantidad{get; set;}
        /// <summary>
        /// Constructor de una instancia de Residuo.
        /// </summary>
        /// <param name="tipo"></param>
        /// <param name="cantidad"></param>
        public Residuo(string tipo, int cantidad)
        {
            this.tipo = tipo;
            this.cantidad = cantidad;
        }
    }
}