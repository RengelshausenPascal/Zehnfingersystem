using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zehnfingersystem
{
    public class LogIn: MainWindow
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Passwort { get; set; }

        public void Daten()
        {
            username.Text = Username;
            email.Text = Email;
            passwort.Text = Passwort;

        }



    }
}
