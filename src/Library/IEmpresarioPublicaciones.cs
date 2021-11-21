namespace ClassLibrary

{
    /// <summary>
    /// IEmpresarioPublicaciones es una interfaz para aplicar DIP, en buscador hay un metodo que precisa
    /// saber esta informacion, pero es mas correcto pasarle esta interfaz en vez de un Empresario ya que
    /// de esta forma no solo la clase Empresario esta mas encapsulada, sino que ademas podemos agregar
    /// nuevas responsabilidades a Empresario sin que deba cambiar el programa.
    /// </summary>
    public interface IEmpresarioPublicaciones
    {
        ListaPublicaciones LasPublicaciones{ get; set; }
    }
}