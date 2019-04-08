using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zehnfingersystem
{
    class LogIn : MainWindow
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Passwort { get; set; }

        public void Daten()
        {
            Username = username.Text;
            Email = email.Text;
            Passwort = passwort.Text;
        }
    }
}
