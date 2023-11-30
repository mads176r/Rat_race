using System;
using System.Collections.Generic;
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
            // Initialize necessary objects
            BookMaker bookMaker = new BookMaker();
            RatRaceRepository ratRaceRepository = new RatRaceRepository();
            RaceManager manager = ratRaceRepository.Load();
            Player player = new Player();
            //manager = ratRaceRepository.Load();

            // Check if the user has an account
            Console.Write("Do you have an account (Y:N)");
            string hasUser = Console.ReadLine();

            bool Accounthandling = true;

            // User account handling loop
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

                    // Create player and save to repository
                    player = manager.CreatePlayer(newUserName, newPassword);
                    ratRaceRepository.Save(manager.PlayerList);

                    break;
                }
                else
                {
                    Console.WriteLine("try again");
                    Console.Write("Answer with (Y:N)");
                    hasUser = Console.ReadLine();
                }
            }

            // User login
            Console.WriteLine("Insert username");
            string username = Console.ReadLine();
            Console.WriteLine("Insert password");
            string password = Console.ReadLine();
            player = manager.LoginToPlayer(username, password);

            // Validate login credentials
            while (player == null)
            {
                Console.WriteLine("Try again");
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
                player = manager.LoginToPlayer(username, password);
            }


            while (true)
            {
                Console.Clear();

                // Display options to the user
                Console.WriteLine("Welcome choose an option and press enter afterwards");
                Console.WriteLine("1: Place Bet");
                Console.WriteLine("2: Create");
                Console.WriteLine("3: start Game");
                Console.WriteLine("4: End Game");

                // User choice handling
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.Clear();

                        //trin 1
                        for (int raceIndex = 0; raceIndex < manager.Races.Count; raceIndex++)
                        {
                            Race race = manager.Races[raceIndex];
                            string raceInfo = string.Format("{0}. Race id: {1}. Track name: {2}. Number of rats: {3}", (raceIndex + 1), race.RaceID, race.RaceTrack.Name, race.Rats.Count);
                            Console.WriteLine(raceInfo);
                        }
                        Console.Write("Choose a race to bet on: ");
                        int chosenRaceIndex = int.Parse(Console.ReadLine()) - 1;
                        Race chosenRace = manager.Races[chosenRaceIndex];

                        //trin 2
                        for (int ratIndex = 0; ratIndex < chosenRace.Rats.Count; ratIndex++)
                        {
                            Rat rat = chosenRace.Rats[ratIndex];
                            string ratInfo = string.Format("{0}. Rat name: {1}", (ratIndex + 1), rat.Name);
                            Console.WriteLine(ratInfo);
                        }
                        Console.Write("Choose a rat to bet on: ");
                        int chosenRatIndex = int.Parse(Console.ReadLine()) - 1;
                        Rat chosenRat = chosenRace.Rats[chosenRatIndex];

                        //trin 3
                        Console.Write("How much money do you wanna bet: ");
                        int moneyToBet = int.Parse(Console.ReadLine());

                        Bet bet = bookMaker.PlaceBet(chosenRace, chosenRat, player, moneyToBet);
                        bookMaker.Bets.Add(bet);

                        ratRaceRepository.Save(manager.PlayerList);

                        ratRaceRepository.Save(bookMaker.Bets);

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

                            // Handling user creation choice
                            switch (createChoice)
                            {
                                case 1:
                                    // Create and save track
                                    Track track = new Track();
                                    Console.Write("Give the track a name: ");
                                    string trackName = Console.ReadLine();
                                    Console.Write("Choose a length: ");
                                    int trackLength = int.Parse(Console.ReadLine());
                                    track = manager.CreateTrack(trackName, trackLength);
                                    ratRaceRepository.Save(manager.Tracks);
                                    break;

                                case 2:
                                    // Create and save rat
                                    Rat rat = new Rat();
                                    Console.Write("Give the rat a name: ");
                                    string ratName = Console.ReadLine();
                                    rat = manager.CreateRat(ratName);
                                    manager.Rats.Add(rat);
                                    ratRaceRepository.Save(manager.Rats);
                                    break;

                                case 3:
                                    // Create race
                                    List<Rat> rats = new List<Rat>();
                                    List<Track> tracks = new List<Track>();
                                    Track raceTrack = new Track();

                                    // Choose rats for the race
                                    Console.WriteLine("Choose your rats:");
                                    for (int i = 0; i < manager.Rats.Count; i++)
                                    {
                                        Rat ratForRace = manager.Rats[i];
                                        Console.WriteLine($"{i + 1} {ratForRace.Name}");
                                    }
                                    Console.WriteLine("Enter the numbers of the rats you want to choose (comma-separated):");
                                    string input = Console.ReadLine();
                                    string[] ratChoices = input.Split(',');
                                    List<int> selectedRats = new List<int>();
                                    foreach (string i in ratChoices)
                                    {
                                        if (int.TryParse(i, out int ratChoice) && ratChoice >= 1 && ratChoice <= manager.Rats.Count)
                                        {
                                            rats.Add(manager.Rats[int.Parse(i) - 1]);
                                            selectedRats.Add(ratChoice);
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Invalid choice: {i}");
                                        }
                                    }

                                    // Display chosen rats
                                    Console.WriteLine("You have chosen the following rats:");
                                    foreach (int ratChoice in selectedRats)
                                    {
                                        Rat ratForRace = manager.Rats[ratChoice - 1];
                                        Console.WriteLine($"{ratChoice} {ratForRace.Name}");
                                    }


                                    // Choose track for the race
                                    Console.WriteLine("Choose your track");
                                    for (int i = 0; i < manager.Tracks.Count; i++)
                                    {
                                        Track trackForRace = manager.Tracks[i];
                                        Console.WriteLine($"{i + 1} {trackForRace.Name}");
                                    }
                                    Console.WriteLine("Enter the number of the track you want to choose:");
                                    int trackIndex = int.Parse(Console.ReadLine()) - 1;
                                    Track selectedTrack = manager.Tracks[trackIndex];

                                    // Display chosen tracks
                                    Console.WriteLine("Trackname: " + selectedTrack.Name + " | Lenght: " + selectedTrack.TrackLength);

                                    // new RaceID
                                    int raceIdCount;

                                    if (manager.Races == null)
                                    {
                                        raceIdCount = 0;
                                    }
                                    else
                                    {
                                        raceIdCount = manager.Races.Count;
                                    }

                                    int newRaceId = raceIdCount++;

                                    // Create race
                                    manager.CreateRace(newRaceId, rats, selectedTrack);
                                    break;

                                case 4:
                                    // Exit create loop
                                    createSwitch = false;
                                    break;
                            }
                        }
                        break;

                    case 3:
                        // start the game
                        Console.Clear();

                        if (manager.Races.Count > 0)
                        {
                            int i = 1;
                            Console.WriteLine("Choose race:");


                            foreach (Race race in manager.Races)
                            {
                                Console.WriteLine(i++ + ": " + "RaceID: " + race.RaceID + "\n Rats:");

                                foreach (Rat rat in race.Rats)
                                {
                                    Console.WriteLine(rat.Name);
                                }

                                Console.WriteLine("Track name: " + race.RaceTrack.Name);
                            }

                            int raceIndex = int.Parse(Console.ReadLine()) - 1;

                            Race selectedRace = manager.Races[raceIndex];

                            Console.WriteLine("Game started!");

                            manager.ConductRace(selectedRace);

                            string raceLog = manager.ViewRaceLog(selectedRace);
                            Console.WriteLine(raceLog);

                            Console.WriteLine("Press any key to go to winnings");
                            Console.ReadKey();


                            Bet betForPayout = player.Bets.FirstOrDefault(u => u.Race == selectedRace);

                            bookMaker.PayOutWinnings(betForPayout);
                            ratRaceRepository.Save(manager.PlayerList);

                        }
                        else
                        {
                            Console.WriteLine("No available race to conduct");
                        }
                        break;


                    case 4:
                        // Exit the console application
                        Environment.Exit(0);
                        break;

                }
            }
        }
    }
}

