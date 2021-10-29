namespace ClassLibrary
{
    public static class Buscador
    {
        public static void Buscar(Residuo residuo)
        {
            foreach(Publicacion publicacion in Mercado.mercado)
            {
                if(publicacion.residuo == residuo)
                {
                    
                }
            }
        }
    }
}