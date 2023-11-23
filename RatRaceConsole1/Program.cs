﻿using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using Rat_race;
using Rat_race.Repository;
namespace RatRaceConsole1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RaceManager manager = new RaceManager();
            RatRaceRepository ratRaceRepository = new RatRaceRepository();
            ////manager = ratRaceRepository.Load();


            //foreach (var item in manager.Tracks)
            //{
            //    Console.WriteLine(item.Name);
            //}

            Rat rat_1 = manager.CreateRat("nummer_1");
            manager.CreateRat("nummer_2");
            manager.CreateRat("nummer_3");
            manager.CreateRat("nummer_4");

            //Console.WriteLine(manager.Tracks);

            Race race = manager.CreateRace(1, manager.Rats, track);

            Player player = manager.CreatePlayer("test", "test", 100);

            ////Vi arbejder herfra



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
                    Player player = new Player();
                    Console.Write("Enter Username: ");
                    string newUserName = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string newPassword = Console.ReadLine();

                    player = racemanager.CreatePlayer(newUserName, newPassword);
                    ratRaceRepository.Save(racemanager.PlayerList);

                   

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


            while (racemanager.LoginToPlayer(username, password) == null)
            {
                Console.WriteLine("Try again");
                Console.Write("Username: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
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


                    Console.WriteLine("choose your rat");
                    Console.WriteLine("1 " + racemanager.Rats[0]);
                    Console.WriteLine("2 " + racemanager.Rats[1]);
                    Console.WriteLine("3 " + racemanager.Rats[2]);
                    Console.WriteLine("4 "  + racemanager.Rats[3]);
                    Console.WriteLine("5 "  + racemanager.Rats[4]);
                    Console.WriteLine("6 " + racemanager.Rats[5]);

                    int betChoice = int.Parse(Console.ReadLine());
                    if (betChoice >= 1 && betChoice <= 6)
                    {
                        Rat selectedRat = racemanager.Rats[betChoice - 1];

                        Console.WriteLine("You chose " +selectedRat.Name + " as your rat.");

                        Console.Write("Enter the bet amount: ");
                        int betAmount = int.Parse(Console.ReadLine());
                        Console.WriteLine("You bet + " + betAmount + " on " + selectedRat.Name);
                    }
                    else
                    {
                        Console.WriteLine("Please choose a number between 1 and 6.");
                    } break;


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
                                ratRaceRepository.Save(racemanager.Tracks);
                                break;

                            case 2:
                                Rat rat = new Rat();
                                Console.Write("Give the rat a name: ");
                                string ratName = Console.ReadLine();
                                rat = racemanager.CreateRat(ratName);

                                ratRaceRepository.Save(racemanager.Rats);
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