using System;
using System.Collections.Generic;
using System.Diagnostics;
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
       
        public Window1(string namee, BitmapImage bitmap)
        {

            InitializeComponent();

            lbl_username.Content = namee;
            img_photo2.Source = bitmap;


            ausgabe();
            einlesen();


            dp2.Start();
            dp.Start(); //dispatcher Timer wird gestartet


            dp.Tick += Dp_Tick;
            dp2.Tick += Dp2_Tick;

            
        }

        DispatcherTimer dp = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };
        DispatcherTimer dp2 = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 10) };


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


      
        int counter = 0;
        string allText;


        public string ausgabe()
        {
            allText = File.ReadAllText(@"..\..\text_ausgabe.txt", Encoding.Default);//Text mit Umlaute auslesen 
            txtBlock.Text = allText.Split(';')[counter];
           
            return allText;

        }


        int punkte = 0;
        int fehler = 0;


        int DiffersAtIndex(string ausgabe, string einlesen)
        {
            int index = 0;
            int min = Math.Min(ausgabe.Length, einlesen.Length);

            for (int i = 0; i < ausgabe.Length; i++)
            {
                try
                {
                    if (einlesen[i] == ausgabe[i])
                        punkte++;
                    else
                        fehler++;
                }
                catch
                {
                    fehler++;
                    
                }
  
            }


            return (index == min && ausgabe.Length == einlesen.Length) ? -1 : index;
        }


        public void ausgeben()
        {
            counter++;
            txtBlock.Text = ausgabe().Split(';')[counter];
            
            if (txtBlock.Text == ausgabe().Split(';').Last()) //wenn es zu Ende gelesen wird 
            {
                dp.Stop();
                dp2.Stop();
       

                DiffersAtIndex(ausgabe(), einlesen());

                lbl_fehler.Content = Convert.ToString(fehler);
                lbl_punkte.Content = Convert.ToString(punkte);

                if (punkte< 59)
                {
                    lblZeit.Content = "Zeit vorbei. Du solltest mehr üben";

                }

                else
                {
                    lblZeit.Content = "Zeit vorbei. Du hast das super gemacht!";
                }
            }           
        }


        private void Dp2_Tick(object sender, EventArgs e)
        {
            ausgeben();
        }

      


    }
}
