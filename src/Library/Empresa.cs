namespace ClassLibrary
{
    public class Empresa
    {
        public string nombre;
        public int ubicacion;
        public int contacto;
        public ListaResiduos residuos = new ListaResiduos();
        public ListaPublicaciones publicaciones = new ListaPublicaciones();
        public ListaEmpresarios empresarios = new ListaEmpresarios();
    }
}