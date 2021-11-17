using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// La clase mercado es estatica porque el esta conoce todas las publicaciones
    /// existentes, independientemente de a que empresa pertenezcan. Como esta es
    /// la experta en la informacion de todas las publicaciones tambien es la
    /// encargada a través de sus 2 metodo Add y Remove Mercado de agregar o remover publicaciones.
    /// </summary>
    public class Mercado
    {
        private static List<Publicacion> mercado {get; set;}
        /// <summary>
        /// AddMercado, metodo para agregar publicaciones al mercado, designado por Expert.
        /// </summary>
        /// <param name="publicacion"></param>
        public void AddMercado(Publicacion publicacion)
        {
            if (mercado != null)
            {
                mercado.Add(publicacion);
            }
            else
            {
                this.GetInstance();
                mercado.Add(publicacion);
            }
        }

        /// <summary>
        /// RemoveMercado, metodo para remover publicaciones al mercado, designado por Expert.
        /// </summary>
        /// <param name="publicacion"></param>
        public void RemoveMercado(Publicacion publicacion)
        {
            mercado.Remove(publicacion);
        }
        /// <summary>
        /// Constructor vacio para agregarle instancias a la clase.
        /// </summary>
        public Mercado()
        {
        }

        public List<Publicacion> GetInstance()
        {
            if (mercado == null)
            {
                mercado = new List<Publicacion>();
            }
            return mercado;
        }
    }
}