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
using static Zehnfingersystem.LogIn;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            w1 = new Window1(name.Text, textBox_email.Text, textBox_passwort.Password);
            w1.Show();
            //MessageBox.Show(textBox_email.Text,textBox_passwort.Password);
            Close();
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(textBox_passwort.Password);
        }
    }
}