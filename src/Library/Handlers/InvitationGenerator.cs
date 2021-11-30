using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    /// <summary>
    /// Clase que se encarga de generar invitaciones, si en algun momento debemos cambiar el modo de la invitacion
    /// entonces solo tendremos que cambiar esta clase y no todas las otras.
    /// </summary>
    public class InvitationGenerator
    {
        
        /// <summary>
        /// Generamos un randomizer
        /// </summary>
        /// <returns></returns>
        public static Random Random = new Random();

        /// <summary>
        /// Este es un metodo que genera una contraseña que se usa como codigo de invitacion, esta posee menos de
        /// 7 digitos.
        /// </summary>
        /// <returns></returns>
        public static string Generate()
        {
            string invitacion = "";
            int invitation;
            bool agregado = false;
            while (agregado == false)
            {
                invitation = Random.Next(1000000);
                invitacion = Convert.ToString(invitation); 
                if(ListaInvitaciones.GetInstance().Invitaciones.Contains(invitacion))
                {
                }
                else
                {
                    agregado = true;
                }
            }
            return invitacion;
        }
    }
}