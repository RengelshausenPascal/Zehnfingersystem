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
        private LogIn user;

        public Window1()
        {

            InitializeComponent();

            user = new LogIn() { Username = user.Username, Email = user.Email,  Passwort = user.Passwort };
            lbl_username.Content = user.Username;

            //text_ausgeben txtAusgeben = new text_ausgeben();
            //txtAusgeben.auslesen();
            //txtBlock.Text = txtAusgeben.ausgabe;

            //string[] txtAusgabe =txtAusgeben.ausgabe.Split(' ') ;

            auslesen();
            einlesen();

            dp.Start(); //dispatcher Timer wird gestartet
            //dp2.Start();
            //dp2.Tick += Dp2_Tick;

            dp.Tick += Dp_Tick;

        }

        //Window1 w1 = new Window1();

        DispatcherTimer dp = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 5) };

        public string[] einlesen()
        {
            string[] txtEinlesen = txtBox.Text.Split(' ');

            return txtEinlesen;
        }


        public string[] ausgabe = new string[] { };
        int zeile = 0;

        public string auslesen()
        {
            using (StreamReader sr = new StreamReader(@"text_ausgabe.txt"))
            {
                string inhalt;
                if ((inhalt = sr.ReadLine()) != null)
                {
                    ausgabe = inhalt.Split(' ');
                    //ausgabe=zeile[0];

                    txtBlock.Text = ausgabe[zeile];
                }
            }

            return "";

        }


        private void Dp_Tick(object sender, EventArgs e)
        {         
            zeile++;
            //dp2.Stop();       
        }

        int i = 4;
        private void Dp2_Tick(object sender, EventArgs e)
        {  
            lblZeit.Content = Convert.ToString(i);
            i--;
        }

        int fehler = 0;
        int punkte = 0;
       
        /*
        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            for (int i = 0; i < einlesen().Length; i++)
            {
                //ausgabe[].IndexOf()
                if (einlesen()[i] ==(ausgabe[i]))
                {
                    punkte++;
                }

                else
                {
                    fehler++;
                }
            }

        }
        */
    }
}
