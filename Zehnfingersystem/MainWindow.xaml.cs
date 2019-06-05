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
using Microsoft.Win32;


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
            lg.Tag = img_photo.Tag;
            if (lg.PasswordConditions() == true && lg.LogInConditions() == true)
            {
                w1 = new Window1(name.Text,img_photo.Tag as BitmapImage);
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
                    w1 = new Window1(name.Text,img_photo.Tag as BitmapImage);
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

        private void insert_img_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                img_photo.Source = new BitmapImage(new Uri(op.FileName));
                img_photo.Tag = new BitmapImage(new Uri(op.FileName));
            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] erklären = File.ReadAllLines(@"..\..\erklärung.txt", Encoding.Default);

            foreach (var item in erklären)         
            {
                MessageBox.Show(item);
            }
            
            
        }

        private void passwd_löschen_Click(object sender, RoutedEventArgs e)
        {
            textBox_passwort.Clear();
        }

     
    }
}

