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
            using (StreamWriter objWriter = new StreamWriter("test.txt", true))
            {
                objWriter.Write(name.Text,";");
                objWriter.Write(textBox_email.Text,";");
                objWriter.Write(pswdbox_passwort.Password,";");
                

                MessageBox.Show("Login Daten wurden gespeichert");

                
            }
            LogIn.Passwort = pswdbox_passwort.Password;
            LogIn.PasswordConditions();
            w1 = new Window1(name.Text);
            w1.Show();

            Close();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(textBox_passwort.Password);
        }
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {

            using (StreamReader objReader = new StreamReader("test.txt"))
            {

            }

            w1 = new Window1(name.Text);
            w1.Show();

            Close();
        }
    }
}