using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zehnfingersystem
{
    class LogIn : MainWindow
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
            Username = name.Text;
            Email = textBox_email.Text;
            Passwort = textBox_passwort.Text;
        }

     



    }
}
