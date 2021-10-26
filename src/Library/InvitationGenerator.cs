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
        private static List<int> invitaciones{get;set;} = new List<int>();
        /// <summary>
        /// Generamos un randomizer
        /// </summary>
        /// <returns></returns>
        public static Random random = new Random();

        /// <summary>
        /// Este es un metodo que genera una contraseña que se usa como codigo de invitacion, esta posee menos de
        /// 7 digitos.
        /// </summary>
        /// <returns></returns>
        public static int Generate()
        {
            int invitation = random.Next(1000000);
            return invitation;
        }
    }
}