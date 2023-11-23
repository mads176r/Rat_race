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
            //manager = ratRaceRepository.Load();


            



            //foreach (var item in manager.PlayerList)
            //{
            //    Console.WriteLine(item.UserName);
            //}


            //Console.WriteLine(manager.Tracks);

                    Console.WriteLine("choose your rat");
                    Console.WriteLine("1 " + racemanager.Rats[0]);
                    Console.WriteLine("2 " + racemanager.Rats[1]);
                    Console.WriteLine("3 " + racemanager.Rats[2]);
                    Console.WriteLine("4" + racemanager.Rats[3]);
                    Console.WriteLine("5" + racemanager.Rats[4]);
                    Console.WriteLine("6 " + racemanager.Rats[5]);

                    


                
            
        }

    }

}