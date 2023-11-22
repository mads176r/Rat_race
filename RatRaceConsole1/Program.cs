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

            Console.WriteLine("Indtast Brugernanv");

            string username = Console.ReadLine();

            Console.WriteLine("Indtast password");

            string password = Console.ReadLine();

            // Test om password eksisterer i JSON FILER
            while (racemanager.LoginToPlayer(username, password) == null)
            {
                Console.WriteLine("Prøv igen");
                Console.Write("Brugernavn: ");
                username = Console.ReadLine();
                Console.Write("Password: ");
                password = Console.ReadLine();
            }

            //Velkommen hvad du gerne lave hva?

            Console.WriteLine("Velkommen vælg en mulighed her. Efterfulgt af Enter");
            Console.WriteLine("1: place bet");
            Console.WriteLine("2: Conduct Race");
            Console.WriteLine("3: Create Track");
            Console.WriteLine("4: Create Rat");
            Console.WriteLine("5: Start Game");
            Console.WriteLine("6: End Game");

            int choice = int.Parse(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Her placere du dit bet");
                    break;

                case 2:

                    break;

                case 3:
                    Track track = new Track();

                    Console.Write("Indsæt et navn: ");
                    string trackName = Console.ReadLine();
                    Console.Write("Angiv længde: ");
                    int trackLength = int.Parse(Console.ReadLine());

                    track = manager.CreateTrack(trackName, trackLength);
                    ratRaceRepository.Save(manager.Tracks);
                    break;

                case 4:
                    Rat rat = new Rat();
                    Console.Write("Giv rotten et navn: ");
                    string ratName = Console.ReadLine();
                    rat = manager.CreateRat(ratName);

                    ratRaceRepository.Save(manager.Rats);
                    break;


                
            }
        }

    }

}