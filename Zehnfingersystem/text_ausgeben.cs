using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Zehnfingersystem
{
    class text_ausgeben
    {
        /*
        public string ausgabe;

        public void auslesen()
        {
            using (StreamReader reader = new StreamReader(@"text_ausgabe.txt"))

                //ausgabe = reader.ReadLine();       
        }
        */

        //public string[] readText = File.ReadAllLines(@"text_ausgabe.txt");

        
        
         public string ausgabe;

         public string auslesen()
         {
            
            using (StreamReader sr = new StreamReader(@"text_ausgabe.txt"))
             {
                 string inhalt;
                 while ((inhalt = sr.ReadToEnd()) != null)
                 {
                     string[] zeile = inhalt.Split('%');
                     ausgabe=zeile[0];
                     return ausgabe;
                 }
                
             }

            return "";
       
         }
      
       
        /*
        int punkte = 0;
        int fehler = 0;

        public void fehlerFinden()
        {

            for (int i = 0; i < txtEinlesen.Length; i++)
            {
                if (txtEinlesen[i] == txtAusgabe[i])
                {
                    punkte += 1;
                }

                else
                {
                    fehler += 1;
                }
            }

        }
        */





    }
}
