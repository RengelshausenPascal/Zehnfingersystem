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
    class text_ausgeben:Window1
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




    /*
        DispatcherTimer dp = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 5) };

        public string[] ausgabe = new string[] { };
        //public string ausgabe;
        public string auslesen(int zahl)
         {
            
            using (StreamReader sr = new StreamReader(@"text_ausgabe.txt"))
             {
                 string inhalt;
                 if((inhalt = sr.ReadLine()) != null)
                 {
                    ausgabe = inhalt.Split(' ');
                     //ausgabe=zeile[0];
                     
                     txtBlock.Text=ausgabe[zahl];
                 }
                
             }

            return "";
       
         }
      */
       
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
