using System;
using System.Windows;
using System.Windows.Controls;

namespace RatRaceWPF
{
    public partial class MakeBetMenu : Window
    {
        private MainWindow mainWindow;

        public MakeBetMenu(MainWindow window)
        {
            mainWindow = window ?? throw new ArgumentNullException(nameof(window));
            InitializeComponent();  // Add this line to initialize the XAML elements
        }

        private void PlaceBet_Click(object sender, RoutedEventArgs e)
        {
            // Get the bet amount from the TextBox
            if (int.TryParse(txtBetAmount.Text, out int betAmount))
            {
                // Perform actions with the bet amount
                MessageBox.Show($"You placed a bet of {betAmount}!");
            }
            else
            {
                MessageBox.Show("Invalid bet amount. Please enter a valid number.");
            }
        }

        private void BackToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            mainWindow.Show();
            Close();
        }
    }
}
