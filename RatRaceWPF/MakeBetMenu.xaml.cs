using System.Windows;

namespace RatRaceWPF
{
    /// <summary>
    /// Interaction logic for MakeBetMenu.xaml
    /// </summary>
    public partial class MainWindow2 : Window
    {
     //   MainWindow MainWindow;

        public MainWindow2(MainWindow window)
        {
         //   MainWindow = window;

         //   InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        //    MainWindow.Show(); // dette gør at den næste side kommer frem når man kører den
            this.Close(); // den lukker den ned lige efter et klik på siden.
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Get the bet amount from the TextBox
            //if (int.TryParse(txtBetAmount.Text, out int betAmount))
            //{
            //    // Perform actions with the bet amount
            //    MessageBox.Show($"You placed a bet of {betAmount}!");
            //}
            //else
            //{
            //    MessageBox.Show("Invalid bet amount. Please enter a valid number.");
            //}
        }
    }
}
