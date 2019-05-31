using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Zehnfingersystem
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //private LogIn user;

      
        public Window1(string namee)
        {

            InitializeComponent();
            lbl_username.Content = namee;

            //text_ausgeben txtAusgeben = new text_ausgeben();
            //txtAusgeben.auslesen();
            //txtBlock.Text = txtAusgeben.ausgabe;

            //string[] txtAusgabe =txtAusgeben.ausgabe.Split(' ') ;

            

            auslesen();
            einlesen();

            dp2.Start();
            dp.Start(); //dispatcher Timer wird gestartet
            

            dp.Tick += Dp_Tick;
            dp2.Tick += Dp2_Tick;

            
            Vergleichen();
           

        }

        DispatcherTimer dp = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
        DispatcherTimer dp2 = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 10) };



        public string[] einlesen()
        {
            string[] txtEinlesen = txtBox.Text.Split(' ');

            return txtEinlesen;
        }


        
        public string[] ausgabe = new string[] { };
        int zeile = 0;

        public string auslesen()
        {
            using (StreamReader sr = new StreamReader(@"..\..\text_ausgabe.txt"))
            {
                string inhalt;
                if ((inhalt = sr.ReadToEnd()) != null)
                {
                    ausgabe = inhalt.Split( '%' );
                    txtBlock.Text = ausgabe[zeile];
                    
                }
            }

            return "";

        }

        private void Dp2_Tick(object sender, EventArgs e)
        {
            ausgeben();                 
        }


        int i = 10;
        private void Dp_Tick(object sender, EventArgs e)
        {  
            lblZeit.Content = Convert.ToString(i);
            i--;

            if (i== 0)
            {
                i =10;
                
            }

        }

        
        int punkte = 0;
        int fehler = 0;

        private void Vergleichen()
        {

            for (int i = 0; i < einlesen().Length; i++)
            {
                string wort1 = ausgabe[i];
                string wort2 = einlesen()[i];

                for (int i2 = 0; i2 < wort2.Length; i2++)
                {
                    if (wort1[i2] == wort2[i2])
                    {
                        punkte++;
                        
                    }

                    else
                    {
                        fehler++;
                    }
                }
            }

        }

       

        public void ausgeben()
        {

            zeile++;
            txtBlock.Text = ausgabe[zeile];

            if (txtBlock.Text == ausgabe[4])
            {
                dp.Stop();
                lblZeit.Content = "Zeit vorbei";

                lbl_punkte.Content = Convert.ToString(punkte);
                lbl_punkte.Content = Convert.ToString(fehler);


            }

        }

        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            /*
                 foreach( var i in einlesen())
                 {
                     if (Array.IndexOf(ausgabe, i) == Array.IndexOf(einlesen(), i))
                     {
                         punkte++;

                     }

                     else
                     {
                         fehler++;
                     }

                 }
                 */


            //andere Möglichkeit
            /*
            for (int i = 0; i < einlesen().Length; i++)
            {
                if (einlesen()[i] == ausgabe[i])
                {
                    punkte++;
                }

                else
                {
                    fehler++;
                }
            }

            */
        }
    }
}
