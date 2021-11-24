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
        public static bool VerifyEmpresario(int id)
        {
            bool registrado = false;
            ListaEmpresarios empresarios = ListaEmpresarios.GetInstance();

            foreach(Empresario empresario in empresarios.Empresarios)
            {
                if(id == empresario.Id)
                {
                    registrado = true;
                }
            }
            return registrado;
        }
        /// <summary>
        /// Verifica que el usuario este registrado.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool VerifyUser(int id)
        {
            bool registrado = false;
            ListaUsuarios usuarios = ListaUsuarios.GetInstance();

            foreach(IUsuario usuario1 in usuarios.Usuarios)
            {
                if(id == usuario1.Id)
                {
                    registrado = true;
                }
            }
            return registrado;
        }
    }
}

