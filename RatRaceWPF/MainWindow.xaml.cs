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

namespace RatRaceWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Dette laver sådan at den åbner en ny side. hvor man kan bette. Men lige nu gør den det samme for dem alle. Det ændrer jeg senere
        {

            new MakeBetMenu(this).Show();
            this.Hide();
        }

        private void Window_DpiChanged(object sender, DpiChangedEventArgs e)
        {

        }
    }
}
