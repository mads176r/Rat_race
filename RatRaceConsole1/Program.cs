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
            //manager = ratRaceRepository.Load();

            //PlaceBet

            Rat rat_1 = manager.CreateRat("nummer_1");
            manager.CreateRat("nummer_2");
            manager.CreateRat("nummer_3");
            manager.CreateRat("nummer_4");

            Track track = manager.CreateTrack("test", 50);

            Race race = manager.CreateRace(1, manager.Rats, track);

            Player player = manager.CreatePlayer("test", "test", 100);

            Bet bet = bookMaker.PlaceBet(race, rat_1, player, 50);



            //foreach (var item in manager.PlayerList)
            //{
            //    Console.WriteLine(item.UserName);
            //}


            //Console.WriteLine(manager.Tracks);


                    


                
            
        }

    }

}