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
            RaceManager manager = new RaceManager();
            BookMaker bookMaker = new BookMaker();
            RatRaceRepository ratRaceRepository = new RatRaceRepository();
            Player player = new Player();
            //manager = ratRaceRepository.Load();

            // Check if the user has an account
            Console.Write("Do you have an account (Y:N)");
            string hasUser = Console.ReadLine();

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
                    Console.WriteLine("Please enter Y(yes) or N(no)");
                }
            }

            // User login
            Console.WriteLine("Insert username");
            string username = Console.ReadLine();
            Console.WriteLine("Insert password");
            string password = Console.ReadLine();

            // Validate login credentials
            while (manager.LoginToPlayer(username, password) == null)
            {
                Console.WriteLine("Try again");
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
                player = manager.LoginToPlayer(username, password);
            }

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
                    for (int raceIndex = 0; raceIndex < manager.Races.Count; raceIndex++)
                    {
                        Race race = manager.Races[raceIndex];
                        string raceInfo = string.Format("{0}. Track name: {1}. Number of rats: {2}", (raceIndex + 1), race.RaceTrack, race.Rats.Count);
                        Console.WriteLine(raceInfo);
                    }
                    Console.Write("Choose a race to bet on: ");
                    int chosenRaceIndex = int.Parse(Console.ReadLine()) - 1;
                    Race chosenRace = manager.Races[chosenRaceIndex];

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
                                    Console.WriteLine($"{i + 1} {manager.Rats[i]}");
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
                                    Console.WriteLine($"{ratChoice} {manager.Rats[ratChoice - 1]}");
                                }

                                // Choose track for the race
                                Console.WriteLine("Choose your track");
                                for (int i = 0; i < manager.Tracks.Count; i++)
                                {
                                    Console.WriteLine($"{i + 1} {manager.Rats[i]}");
                                }
                                string selectedTrack = Console.ReadLine();
                                Console.WriteLine("Enter the numbers of the tracks you want to choose (comma-separated):");
                                string trackInput = Console.ReadLine();
                                string[] trackChoices = input.Split(',');
                                List<int> selectedTracks = new List<int>();
                                foreach (string i in trackChoices)
                                {
                                    if (int.TryParse(i, out int trackChoice) && trackChoice >= 1 && trackChoice <= manager.Tracks.Count)
                                    {
                                        raceTrack = (manager.Tracks[int.Parse(i) - 1]);
                                        selectedTracks.Add(trackChoice);
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Invalid choice: {i}");
                                    }
                                }

                                // Display chosen tracks
                                Console.WriteLine("You have chosen the following Tracks:");
                                foreach (int trackChoice in selectedTracks)
                                {
                                    Console.WriteLine($"{trackChoice} {manager.Tracks[trackChoice - 1]}");
                                }

                                // Create race
                                int raceIdCount = 0;
                                int newRaceId = raceIdCount++;
                                manager.CreateRace(newRaceId, rats, raceTrack);
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
                    Console.WriteLine("game start");
                    break;

                case 4:
                    // Exit the console application
                    Environment.Exit(0);
                    break;

            }
        }
    }
}

