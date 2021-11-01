// Interfaz comando
namespace ClassLibrary
{
    /// <summary>
    /// Es una interfaz llamada ICommand con 1 metodo y una property.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Metodo que evalua si el mensaje enviado era dirigido a una respuesta de este comando o no.
        /// En caso de que no sea el mensaje indicado para este comando se vera y ejecutara el Do del proximo comando.
        /// </summary>
        void Do(IUsuario usuario, string message);

        /// <summary>
        /// Obtiene o estable Property que indica cual es el proximo comando a ejecutarse.
        /// </summary>
        /// <value></value>
        ICommand next {get; set;}
    }
}
