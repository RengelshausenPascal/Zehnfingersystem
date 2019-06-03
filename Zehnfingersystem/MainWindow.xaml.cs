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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace Zehnfingersystem
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        static public Window1 w1;


        //private void Button_Click(object sender, RoutedEventArgs e)
        //{

        //    w1 = new Window1(name.Text);
        //    w1.Show();

        //    Close();

        //}

        private void btn_Registrieren_Click(object sender, RoutedEventArgs e)
        {
            using (StreamWriter objWriter = new StreamWriter(@"..\..\test.txt", true))
            {
                objWriter.Write(name.Text + ";");
                objWriter.Write(textBox_email.Text + ";");
                objWriter.Write(textBox_passwort.Password);
                objWriter.WriteLine();




            }
            LogIn lg = new LogIn();
            lg.Passwort = textBox_passwort.Password;
            lg.Username = name.Text;
            lg.Email = textBox_email.Text;
            if (lg.PasswordConditions() == true && lg.LogInConditions() == true)
            {
                w1 = new Window1(name.Text);
                w1.Show();

                Close();
            }
            else if (lg.PasswordConditions() == false)
                MessageBox.Show("Das Passwort muss mindestens aus 4-10 Zeichen, einer Zahl und einem Groß- oder Kleinbuchstaben bestehen!");


            else if (lg.LogInConditions() == false)
            {
                MessageBox.Show("Die Felder müssen korrekt ausgefüllt werden!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(textBox_passwort.Password);
        }




        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {

            StreamReader objReader = new StreamReader(@"..\..\test.txt");


            string[] lines = File.ReadAllLines(@"..\..\test.txt");
            bool b_loggedin = false;

            while (objReader.EndOfStream == false)
            {

                string line = objReader.ReadLine();
                string[] LogInFelder = line.Split(';');



                if (name.Text == LogInFelder[0] && textBox_passwort.Password == LogInFelder[2])
                {
                    b_loggedin = true;
                    w1 = new Window1(name.Text);
                    w1.Show();

                    Close();
                    objReader.ReadToEnd();
                    break;
                }
            }
            if (b_loggedin == false)
            {
                foreach (var item in lines)
                {
                    string[] Felder = item.Split(';');
                    if (name.Text != Felder[0] || textBox_passwort.Password != Felder[2])
                    {
                        MessageBox.Show("Falsche Eingabe!");
                        break;
                    }
                }
            }           
        }

    }
}
