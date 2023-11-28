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
using RatRaceBLL;
namespace RatRaceWPF2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Manager manager = new Manager();
        public Manager Manager { get; set; } 
        public MainWindow()
        {
            InitializeComponent();
            // string RatNameInput = RatNameInputBox.Text;

            manager.RaceManager.CreateRat("Rotte1");
            manager.RaceManager.CreateTrack("Track", 50);
            manager.RaceManager.CreatePlayer("cobra", "cobra");
            
            manager.RaceManager.CreateRace(1, manager.RaceManager.Rats, manager.RaceManager.Tracks[0]);
        }


        private void GoToBetMaking(object sender, RoutedEventArgs e)
        {


            MakeBetWindow  Window = new MakeBetWindow();
            Window.Show();
            this.Hide();
        }

        private void GoToRaceStart(object sender, RoutedEventArgs e)
        {
            StartRace Window = new StartRace();
            Window.Show();
            this.Hide();
        }

        private void LogsView(object sender, RoutedEventArgs e)
        {
            ViewLogs Window = new ViewLogs();
            Window.Show();
            this.Hide();
        }

        private void ExitButtonClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void CreateThings(object sender, RoutedEventArgs e)
        {
            Create Window = new Create();
            Window.Show();
            this.Hide();
        }
    }
}
