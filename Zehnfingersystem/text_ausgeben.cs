using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Zehnfingersystem
{
    class text_ausgeben
    {

        public string ausgabe;
        public void auslesen()
        {
            using (StreamReader reader = new StreamReader(@"text_ausgabe.txt"))

                ausgabe = reader.ReadLine();
        }
        
        
        /*
        public string ausgabe;

        public string auslesen()
        {
            using (StreamReader sr = new StreamReader(@"text_ausgabe.txt"))
            {
                string inhalt;
                while ((inhalt = sr.ReadToEnd()) != null)
                {
                    string[] zeile = inhalt.Split('%');
                    ausgabe=inhalt;
                }
            }
            return ausgabe;
        }
        */
    }
}
