namespace ClassLibrary
{
    /// <summary>
    /// Generator es una interfaz para poder aplicar OCP con las invitaciones.
    /// </summary>
    public interface IGenerator
    {   
        /// <summary>
        /// Es un metodo que devuelve un string que debe tenerlo todo generador de invitaciones.
        /// </summary>
        /// <returns></returns>
        string Generate();
    }
}