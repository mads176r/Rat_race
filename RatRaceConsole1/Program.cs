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
            RatRaceRepository ratRaceRepository = new RatRaceRepository();
            manager = ratRaceRepository.Load();

            foreach (var item in manager.Tracks)
            {
                Console.WriteLine(item.Name);
            }


            Console.WriteLine(manager.Tracks);



            //Vi arbejder herfra


            //Stage 

            RaceManager racemanager = new RaceManager();
            //load jsonfiler med bruger info ind i appen


            // bruger indtaster login

            Console.WriteLine("Insert username");

            string username = Console.ReadLine();

            Console.WriteLine("Insert password");

            string password = Console.ReadLine();

            // Test om password eksisterer i JSON FILER
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
            Console.WriteLine("2: Create Track");
            Console.WriteLine("3: Create Rat");
            Console.WriteLine("4: Start Game");
            Console.WriteLine("5: End Game");


            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("choose your rat");
                    Console.WriteLine("1 ");
                    Console.WriteLine("2 ");
                    Console.WriteLine("3 ");
                    Console.WriteLine("4" );
                    Console.WriteLine("5" );
                    Console.WriteLine("6 ");

                    int betChoice = int.Parse(Console.ReadLine());

                    break;


                case 2:
                    Track track = new Track();

                    Console.Write("Give the track a name: ");
                    string trackName = Console.ReadLine();
                    Console.Write("Choose a length: ");
                    int trackLength = int.Parse(Console.ReadLine());

                    track = manager.CreateTrack(trackName, trackLength);
                    ratRaceRepository.Save(manager.Tracks);
                    break;

                case 3:
                    Rat rat = new Rat();
                    Console.Write("Give the rat a name: ");
                    string ratName = Console.ReadLine();
                    rat = manager.CreateRat(ratName);

                    ratRaceRepository.Save(manager.Rats);
                    break;

                case 4:
                    Console.WriteLine("The game starts!");
                    
                    break;


                case 5:
                    Environment.Exit(0); // Lukker console applikationen
                    break;



            }
        }

    }

}