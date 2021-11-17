using System;
using System.Collections.Generic;

namespace ClassLibrary
{

    /// <summary>
    /// Usamos la clase registrado estatica ya que no necesitamos crear instancias de este objeto para 
    /// usarla como una herramienta.
    /// </summary>
    public static class Registrado
    {
        /// <summary>
        /// Esta clase se encarga de identificar si el usuario esta registrado o no.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool VerifyUser(int id)
        {
            bool registrado = false;
            ListaEmpresarios empresarios = ListaEmpresarios.GetInstance();
            ListaUsuarios usuarios = ListaUsuarios.GetInstance();

            foreach(Empresario empresario in empresarios.Empresarios)
            {
                if(id == empresario.id)
                {
                    registrado = true;
                }
            }
            if(registrado == false)
            {
                foreach(IUsuario usuario1 in usuarios.Usuarios)
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
