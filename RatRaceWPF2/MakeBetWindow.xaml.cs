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

namespace RatRaceWPF2
{
    /// <summary>
    /// Interaction logic for MakeBetWindow.xaml
    /// </summary>
    public partial class MakeBetWindow : Window
    {
        public MakeBetWindow()
        {
            InitializeComponent();
            
        }

        private void ConfirmBet(object sender, RoutedEventArgs e)
        {
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

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        //private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    
        //    if (sender is TextBox textBox)
        //    {
        //        // You can access the updated text using textBox.Text
        //        // Example: Update a label or perform validation based on the text
        //        UpdateStatusLabel(textBox.Text);
        //    }
        //}

        //private void UpdateStatusLabel(string text)
        //{
        //    statusLabel.Content = $"Current input: {text}";
        //}

        //private void statusLabel(string)
        //{
        //    return null;
        //}

    }
}
