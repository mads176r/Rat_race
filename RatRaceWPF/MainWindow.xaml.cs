using System;
using System.Windows;
using System.Windows.Controls;

namespace RatRaceWPF
{
    public partial class MainWindow : Window
    {

        public MainWindow ()
        {
          //  mainWindow = window ?? throw new ArgumentNullException(nameof(window));
         //   InitializeComponent();  // Add this line to initialize the XAML elements
            //return null; // Make void if it doesnt return anything, change null if return isnt supposed to be null
        }

        private void PlaceBet_Click(object sender, RoutedEventArgs e)
        {
           
        }



        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            //mainWindow.Show();
            //Close();
        }
    }
}
