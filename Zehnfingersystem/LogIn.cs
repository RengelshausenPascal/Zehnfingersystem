using System;
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

        private static string passwort;
        public static string Passwort
        {
            get { return passwort; }
            set { passwort = value; }
        }

        /*
        public void Daten()
        {
            
            Username = name.Text;
            Email = textBox_email.Text;
            Passwort = textBox_passwort.Password;



            
        }

        public static void PasswordConditions()
        {
            Regex pswdregex = new Regex(@"^.*(?=.{4,10})(?=.*\d)(?=.*[a-zA-Z]).*$");
            if (pswdregex.Match(Passwort).Success)

            {
                System.Diagnostics.Debug.WriteLine("passt");
                
            }
            else
                System.Diagnostics.Debug.WriteLine("passt nicht");
        }

     




    }
}
