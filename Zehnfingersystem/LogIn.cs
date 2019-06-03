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

        private string passwort;
        public string Passwort
        {
            get { return passwort; }
            set { passwort = value; }
        }
        public object Tag { get; set; }

        public bool PasswordConditions()
        {
            
            Regex pswdregex = new Regex(@"^.*(?=.{4,10})(?=.*\d)(?=.*[a-zA-Z]).*$");
            if (pswdregex.Match(Passwort).Success)

            {
                //System.Diagnostics.Debug.WriteLine("passt");
                return true;
                
            }
            else
                //System.Diagnostics.Debug.WriteLine("passt nicht");
                return false;
        }

        public bool LogInConditions()
        {
            if (Email.Contains("@") == true || Email.Length != 0 || Username.Length != 0)
            {
                return true;
            }
            else
                return false;
            
        }

     




    }
}
