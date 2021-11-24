namespace ClassLibrary

{
    /// <summary>
    /// IUsuario es una interfaz, todos los usuarios (ya sean emprendedores, empresarios o administradores)
    /// implementan esta interfaz.
    /// </summary>
    public interface IUsuario
    {
        /// <summary>
        /// El unico valor que comparte todo usuario es un valor id que es un int.
        /// </summary>
        /// <value></value>
        int Id { get; set; }

        /// <summary>
        /// El estado del comando.
        /// </summary>
        /// <value></value>
        string State { get; set; }
    }
}