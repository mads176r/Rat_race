using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Rat_race;
using Rat_race.Repository;
namespace RatRaceConsole1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RaceManager manager = new RaceManager();
            BookMaker bookMaker = new BookMaker();
            RatRaceRepository ratRaceRepository = new RatRaceRepository();
            Player player = new Player();
            //manager = ratRaceRepository.Load();


            //foreach (var item in manager.Tracks)
            //{
            //    Console.WriteLine(item.Name);
            //}


            RaceManager racemanager = new RaceManager();
            
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

                    player = racemanager.CreatePlayer(newUserName, newPassword);

                   

                    break;
                }
                else
                {
                    Console.WriteLine("Please enter Y(yes) or N(no)");
                }
            }

            
            // bruger indtaster login

            Console.WriteLine("Insert username");

            string username = Console.ReadLine();

            Console.WriteLine("Insert password");

            string password = Console.ReadLine();

            while (racemanager.LoginToPlayer(username, password) == null)
            {
                Console.WriteLine("Try again");
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
                player = racemanager.LoginToPlayer(username, password);
            }

            //Velkommen hvad du gerne lave hva?

            Console.WriteLine("Welcome choose an option and press enter afterwards");
            Console.WriteLine("1: Place Bet"); 
            Console.WriteLine("2: Create");  
            Console.WriteLine("3: Start Game");
            Console.WriteLine("4: End Game");


            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    for (int raceIndex = 0; raceIndex < racemanager.Races.Count; raceIndex++)
                    {
                        Race race = racemanager.Races[raceIndex];
                        string raceInfo = string.Format("{0}. Track name: {1}. Number of rats: {2}", (raceIndex + 1), race.RaceTrack, race.Rats.Count);
                        Console.WriteLine(raceInfo);
                    }
                    Console.Write("Choose a race to bet on: ");
                    int chosenRaceIndex = int.Parse(Console.ReadLine()) - 1;
                    Race chosenRace = racemanager.Races[chosenRaceIndex];

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

                    bookMaker.PlaceBet(chosenRace, chosenRat, player, moneyToBet);

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

                                track = racemanager.CreateTrack(trackName, trackLength);
                                break;

                            case 2:
                                Rat rat = new Rat();
                                Console.Write("Give the rat a name: ");
                                string ratName = Console.ReadLine();
                                rat = racemanager.CreateRat(ratName);

                                break;

                            case 3:
                                Console.WriteLine("Choose your rats:");
                                for (int i = 0; i < racemanager.Rats.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} {racemanager.Rats[i]}");
                                }

                                Console.WriteLine("Enter the numbers of the rats you want to choose (comma-separated):");
                                string input = Console.ReadLine();

                                string[] choices = input.Split(',');

                                List<int> selectedRats = new List<int>();

                                foreach (string i in choices)
                                {
                                    if (int.TryParse(i, out int ratChoice) && ratChoice >= 1 && ratChoice <= racemanager.Rats.Count)
                                    {
                                        selectedRats.Add(ratChoice);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid choice: {i}");
                                    }
                                }

                                Console.WriteLine("You have chosen the following rats:");
                                foreach (int ratChoice in selectedRats)
                                {
                                    Console.WriteLine($"{ratChoice} {racemanager.Rats[ratChoice - 1]}");
                                }

                                Console.WriteLine("Choose your track");
                                for (int i = 0; i < racemanager.Tracks.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} {racemanager.Rats[i]}");
                                }
                                string selectedTrack = Console.ReadLine();


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