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

      
        public Window1(string namee,BitmapImage bitmap)
        {

            InitializeComponent();
            lbl_username.Content = namee;

            img_photo2.Source = bitmap;


            //text_ausgeben txtAusgeben = new text_ausgeben();
            //txtAusgeben.auslesen();
            //txtBlock.Text = txtAusgeben.ausgabe;

            //string[] txtAusgabe =txtAusgeben.ausgabe.Split(' ') ;



            //auslesen();
            ausgabe();
            einlesen();
            

            dp2.Start();
            dp.Start(); //dispatcher Timer wird gestartet
            

            dp.Tick += Dp_Tick;
            dp2.Tick += Dp2_Tick;


            //Vergleichen();
            DiffersAtIndex(ausgabe(),einlesen());

        }

        DispatcherTimer dp = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
        DispatcherTimer dp2 = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 5) };


     
        int i = 10;
        private void Dp_Tick(object sender, EventArgs e)
        {
            lblZeit.Content = Convert.ToString(i);
            i--;

            if (i == 0)
            {
                i = 10;

            }

        }


        public string einlesen()
        {
            string txtEinlesen = txtBox.Text;

            return txtEinlesen;
        }


        string line = "";
        string[] line_;
        int counter = 0;

        public string ausgabe()
        {
            
            StreamReader datei = new StreamReader(@"..\..\text_ausgabe.txt", Encoding.Default);// Umlaute richtig anzeigen 

            while (datei.Peek() != -1) //Solange bis Dateiende erreicht
            {
                line = datei.ReadToEnd(); 
                line_ = line.Split(new char[] { '%' });
                txtBlock.Text = line_[counter];

            }
            
            return "";

        }

       


        int punkte = 0;
        int fehler = 0;

        int DiffersAtIndex(string ausgabe, string einlesen)
        {
            int index = 0;
            int min = Math.Min(ausgabe.Length, einlesen.Length);
            while (index < min && ausgabe[index] == einlesen[index])
            {                
                punkte++;
                index++;
            }

            return (index == min && ausgabe.Length == einlesen.Length) ? -1 : index;
        }


        public void ausgeben()
        {
            counter++;
            txtBlock.Text = line_[counter];

            if (txtBlock.Text == line_[4])
            {
                dp.Stop();
                lblZeit.Content = "Zeit vorbei";

                lbl_fehler.Content = Convert.ToString(fehler);
                lbl_punkte.Content = Convert.ToString(punkte);

            }
        }

        private void Dp2_Tick(object sender, EventArgs e)
        {
            ausgeben();
        }


        /*
        public string[] einlesen()
        {
            string[] txtEinlesen = txtBox.Text.Split(' ');

            return txtEinlesen;
        }
        */

        /*
        public string[] ausgabe = new string[] { };
        int zeile = 0;
        */

        /*
        public string auslesen()
        {
            string[] text_auslesen = File.ReadAllLines(@"..\..\text_ausgabe.txt");

            foreach (var item in text_auslesen)
            {
                txtBlock.Text = item;
            }

            return "";
        }
        */

        /*
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
        */


        /*
        string line;

        System.IO.StreamReader file = new System.IO.StreamReader(@"..\..\text_ausgabe.txt");
        while ((line = file.ReadLine()) != null)
        {
            txtBlock.Text = line;
            //counter++;
        }

        //dp.Stop();
        //lblZeit.Content = "Zeit vorbei";
        */
        /*
        string[] text_auslesen = File.ReadAllLines(@"..\..\text_ausgabe.txt");

        foreach (var item in text_auslesen)
        {
            txtBlock.Text = item;   
        }


        if (txtBlock.Text.Length==text_auslesen.Length)
        {
            dp.Stop();
            lblZeit.Content = "Zeit vorbei";

            //lbl_punkte.Content = Convert.ToString(punkte);
            //lbl_punkte.Content = Convert.ToString(fehler);

        }



        */


        /*
        private void Vergleichen()
        {
            MessageBox.Show("Test:" + ausgabe.Length);
            string[] woerter2 = einlesen();
            for (int i = 0; i < woerter2.Length; i++)
            {
                string wort1 = ausgabe[i];
                string wort2 = woerter2[i];

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
        */

    }
}
