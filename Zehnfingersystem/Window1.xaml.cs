using System;
using System.Collections.Generic;
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



        }


        public Window1(string usn, string em, string pass)
        {

            InitializeComponent();
            user = new LogIn() { Username = usn, Email = em, Passwort = pass };
            lbl_username.Content = user.Username;

            text_ausgeben txtAusgeben = new text_ausgeben();
            txtAusgeben.auslesen();
            txtBlock.Text = txtAusgeben.ausgabe;

            //string[] txtEinlesen = txtBox.Text.Split(' ');
            //string[] txtAusgabe =txtAusgeben.ausgabe.Split(' ') ;

            dp.Start();
            dp2.Start();
            dp2.Tick += Dp2_Tick;
            dp.Tick += Dp_Tick;




        }

        DispatcherTimer dp = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 5) };
        DispatcherTimer dp2 = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) }; //Countdown

     
        private void Dp_Tick(object sender, EventArgs e)
        {
            dp2.Stop();
            
        }

        int i = 4;
        private void Dp2_Tick(object sender, EventArgs e)
        {
            lblZeit.Content = Convert.ToString(i);
            i--;
        }
    }
}
