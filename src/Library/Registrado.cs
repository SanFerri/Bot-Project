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
            ListaEmpresarios empresarios = new ListaEmpresarios();
            ListaUsuarios usuarios = new ListaUsuarios();

            foreach(Empresario empresario in empresarios.GetInstance())
            {
                if(id == empresario.id)
                {
                    registrado = true;
                }
            }
            if(registrado == false)
            {
                foreach(IUsuario usuario1 in usuarios.GetInstance())
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
