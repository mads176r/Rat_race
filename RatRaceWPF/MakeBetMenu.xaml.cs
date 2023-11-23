using System.Windows;

namespace RatRaceWPF
{
    /// <summary>
    /// Interaction logic for MakeBetMenu.xaml
    /// </summary>
    public partial class MakeBetMenu : Window
    {
        MainWindow MainWindow;

        public MakeBetMenu(MainWindow window)
        {
            MainWindow = window;

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.Show(); // dette gør at den næste side kommer frem når man kører den
            this.Close(); // den lukker den ned lige efter et klik på siden.
        }
    }
}
