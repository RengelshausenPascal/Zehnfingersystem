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

            
            ausgabe();
            einlesen();
            

            dp2.Start();
            dp.Start(); //dispatcher Timer wird gestartet
            

            dp.Tick += Dp_Tick;
            dp2.Tick += Dp2_Tick;


            DiffersAtIndex(ausgabe(),einlesen());

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
            //string[] textEinlesen = txtEinlesen.Split('.');

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
                line_ = line.Split('%');
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
            while (index < min )
            {  
                if(ausgabe[index] == einlesen[index])
                {
                    punkte++;
                }
                
                else
                {
                    fehler++;
                }

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


    }
}
