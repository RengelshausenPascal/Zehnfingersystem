﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Zehnfingersystem
{
    class LogIn
    {
        private string  username;
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string passwort;
        public string Passwort
        {
            get { return passwort; }
            set { passwort = value; }
        }

        
        public void Daten()
        {
           



            
        }

        public static void PasswordConditions()
        {
            LogIn lg = new LogIn();
            Regex pswdregex = new Regex(@"^.*(?=.{4,10})(?=.*\d)(?=.*[a-zA-Z]).*$");
            if (pswdregex.Match(lg.Passwort).Success)

            {
                System.Diagnostics.Debug.WriteLine("passt");
                
            }
            else
                System.Diagnostics.Debug.WriteLine("passt nicht");
        }

     */




    }
}
