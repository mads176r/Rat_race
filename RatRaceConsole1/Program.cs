using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Rat_race;
using RatRaceBLL;
namespace RatRaceConsole1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Manager manager = new Manager();

            Player player = new Player();

            Console.Write("Do you have an account (Y:N)");
            string hasUser = Console.ReadLine();
            while (true) 
            {
                if (hasUser == "y" || hasUser == "Y") 
                {
                    break;
                }
                else if (hasUser == "n" || hasUser == "N") 
                {                    
                    Console.Write("Enter Username: ");
                    string newUserName = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string newPassword = Console.ReadLine();

                    player = manager.RaceManager.CreatePlayer(newUserName, newPassword);

                    break;
                }
                else
                {
                    Console.WriteLine("Please enter Y(yes) or N(no)");
                }
            }


            //bruger indtaster login

            Console.WriteLine("Insert username");

            string username = Console.ReadLine();

            Console.WriteLine("Insert password");

            string password = Console.ReadLine();

            while (manager.RaceManager.LoginToPlayer(username, password) == null)
            {
                Console.WriteLine("Try again");
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
                player = manager.RaceManager.LoginToPlayer(username, password);
            }

            Console.WriteLine("Welcome choose an option and press enter afterwards");
            Console.WriteLine("1: Place Bet"); 
            Console.WriteLine("2: Create");  
            Console.WriteLine("3: Start Game");
            Console.WriteLine("4: End Game");


            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    for (int raceIndex = 0; raceIndex < manager.RaceManager.Races.Count; raceIndex++)
                    {
                        Race race = manager.RaceManager.Races[raceIndex];
                        string raceInfo = string.Format("{0}. Track name: {1}. Number of rats: {2}", (raceIndex + 1), race.RaceTrack, race.Rats.Count);
                        Console.WriteLine(raceInfo);
                    }
                    Console.Write("Choose a race to bet on: ");
                    int chosenRaceIndex = int.Parse(Console.ReadLine()) - 1;
                    Race chosenRace = manager.RaceManager.Races[chosenRaceIndex];

                    for (int ratIndex = 0; ratIndex < chosenRace.Rats.Count; ratIndex++)
                    {
                        Rat rat = chosenRace.Rats[ratIndex];
                        string ratInfo = string.Format("{0}. Rat name: {1}", (ratIndex + 1), rat.Name);
                        Console.WriteLine(ratInfo);
                    }
                    Console.Write("Choose a rat to bet on: ");
                    int chosenRatIndex = int.Parse(Console.ReadLine()) - 1;
                    Rat chosenRat = chosenRace.Rats[chosenRatIndex];

                    Console.Write("How much money do you wanna bet: ");
                    int moneyToBet = int.Parse(Console.ReadLine());

                    manager.PlaceBet(chosenRace, chosenRat, player, moneyToBet);

                    break;


                case 2:
                    bool createSwitch = true;

                    while (createSwitch) 
                    {
                        Console.WriteLine("What do you want to create");
                        Console.WriteLine("1: Create track");
                        Console.WriteLine("2: Create rat");
                        Console.WriteLine("3: Create race");
                        Console.WriteLine("4: Go back");

                        int createChoice = int.Parse(Console.ReadLine());


                        switch (createChoice)
                        {
                            case 1:
                                Track track = new Track();

                                Console.Write("Give the track a name: ");
                                string trackName = Console.ReadLine();
                                Console.Write("Choose a length: ");
                                int trackLength = int.Parse(Console.ReadLine());

                                track = manager.RaceManager.CreateTrack(trackName, trackLength);
                                break;

                            case 2:
                                Rat rat = new Rat();
                                Console.Write("Give the rat a name: ");
                                string ratName = Console.ReadLine();
                                rat = manager.RaceManager.CreateRat(ratName);

                                break;

                            case 3:
                                int newRaceID = manager.RaceManager.Races.Count + 1;

                                Console.WriteLine("Choose your rats:");
                                for (int i = 0; i < manager.RaceManager.Rats.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} {manager.RaceManager.Rats[i]}");
                                }

                                Console.WriteLine("Enter the numbers of the rats you want to choose (comma-separated):");
                                string input = Console.ReadLine();

                                string[] choices = input.Split(',');

                                List<Rat> selectedRats = new List<Rat>();


                                foreach (string i in choices)
                                {
                                    if (int.TryParse(i, out int ratChoice) && ratChoice >= 1 && ratChoice <= manager.RaceManager.Rats.Count)
                                    {
                                        selectedRats.Add(manager.RaceManager.Rats[ratChoice]);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid choice: {i}");
                                    }
                                }

                                Console.WriteLine("You have chosen the following rats:");
                                for (int i = 0; i <= selectedRats.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} {manager.RaceManager.Rats[i]}");
                                }

                                Console.WriteLine("Choose your track");
                                for (int i = 0; i < manager.RaceManager.Tracks.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} {manager.RaceManager.Tracks[i]}");
                                }
                                int selectedTrackIndex = int.Parse(Console.ReadLine());
                                Track selectedTrack = manager.RaceManager.Tracks[selectedTrackIndex];


                                manager.RaceManager.CreateRace(newRaceID, selectedRats, selectedTrack);

                                break;

                            case 4:
                                createSwitch = false;
                                break;
                        }
                    
                    }
                    break;


                case 3:
                    Console.WriteLine("The game starts!");
                    break;

                case 4:
                    Environment.Exit(0); // Lukker console applikationen

                    break;

            }
        }

    }

}