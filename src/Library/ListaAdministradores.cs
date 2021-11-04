using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// ListaEmpresarios es el experto en conocer a los empresarios, y 
    /// por el patron Expert este tambien es quien
    /// posee la responsabilidad de agregar Empresarios y/o remover Empresarios.
    /// </summary>
    public static class ListaAdministradores
    {
        /// <summary>
        /// Variable estatica empresarios, porque es una lista de instancias de Empresario
        /// que lleva un registro de todos los empresarios que hay.
        /// </summary>
        /// <returns></returns>
        public static List<Administrador> administradores{get; set;} = new List<Administrador>();

        /// <summary>
        /// Metodo que agrega un empresario a la lista de empresarios, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="administrador"></param>
        public static Administrador AddAdministrador(int invitacion, int id)
        {
            Administrador administrador = new Administrador(invitacion, id);
            administradores.Add(administrador);
            return administrador;
        }

        /// <summary>
        /// Metodo que remove un empresario a la lista de empresarios, desginado a esta clase por Expert.
        /// </summary>
        /// <param name="administrador"></param>
        public static void RemoveAdministrador(Administrador administrador)
        {
            administradores.Remove(administrador);
        }
    }
}
