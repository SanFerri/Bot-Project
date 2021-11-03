using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public static class Registrado
    {
        public static bool VerifyUser(int id)
        {
            bool registrado = false;

            foreach(Empresario empresario in ListaEmpresarios.empresarios)
            {
                if(id == empresario.id)
                {
                    registrado = true;
                }
            }
            if(registrado == false)
            {
                foreach(IUsuario usuario1 in ListaUsuarios.usuarios)
                {
                    if(id == usuario1.id)
                    {
                        registrado = true;
                    }
                }
            }
            return registrado;
        }
    }
}
