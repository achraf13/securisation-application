using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace Inventway
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            int valeur = ConfigurationManager.AppSettings.ObtenirValeurEntiere("numberSerial");
            

            if (valeur ==0)
            {
                 Application.Run(new Authentification());
            }
            else if (valeur ==1)
            {
                Application.Run(new Menu());
            }
           
        }
    }
}