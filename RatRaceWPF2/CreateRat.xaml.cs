using Rat_race;
using RatRaceBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Interaction logic for CreateRat.xaml
    /// </summary>
    public partial class CreateRat : Window
    {

        public CreateRat()
        {
            InitializeComponent();
        }

        private void CreateRatButton(object sender, RoutedEventArgs e)
        {
            RatRaceBLL.RatRaceRepository repo = new RatRaceBLL.RatRaceRepository();
            Manager manager = new Manager();
            manager.RaceManager = repo.Load(manager.RaceManager);

            string RatNameInput = RatNameInputBox.Text;

            manager.RaceManager.CreateRat(RatNameInput);

        }
    }
}
