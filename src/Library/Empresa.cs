namespace ClassLibrary
{
    public class Empresa
    {
        public string nombre{get;set;}
        public Ubicacion ubicacion{get;set;}
        public int contacto{get;set;}
        public ListaResiduos residuos{get;set;} = new ListaResiduos();
        public ListaPublicaciones publicaciones{get;set;} = new ListaPublicaciones();

        public Empresario empresario{get;set;}

        public Empresa(string nombre, Ubicacion ubicacion, int contacto)
        {
            this.nombre = nombre;
            this.contacto = contacto;
            this.ubicacion = ubicacion;
        }

    }
}