namespace ClassLibrary

{
    public class Residuo
    {
        public string tipo{get; set;}
        public int cantidad{get; set;}
        public Residuo(string tipo, int cantidad)
        {
            this.tipo = tipo;
            this.cantidad = cantidad;
        }
    }
}