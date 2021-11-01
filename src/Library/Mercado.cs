using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// La clase mercado es estatica porque el esta conoce todas las publicaciones
    /// existentes, indepedientemente de a que empresa pertenezcan. Como esta es
    /// la experta en la informacion de todas las publicaciones tambien es la
    /// encargada atraves de sus 2 metodo Add y Remove Mercado de agregar o remover publicaciones.
    /// </summary>
    public static class Mercado
    {
        /// <summary>
        /// Property 
        /// </summary>
        /// <returns></returns>
        public static List<Publicacion> mercado = new List<Publicacion>();

        /// <summary>
        /// AddMercado, metodo para agregar publicaciones al mercado, designado por Expert.
        /// </summary>
        /// <param name="publicacion"></param>
        public static void AddMercado(Publicacion publicacion)
        {
            mercado.Add(publicacion);
        }

        /// <summary>
        /// RemoveMercado, metodo para remover publicaciones al mercado, designado por Expert.
        /// </summary>
        /// <param name="publicacion"></param>
        public static void RemoveMercado(Publicacion publicacion)
        {
            mercado.Remove(publicacion);
        }
    }
}