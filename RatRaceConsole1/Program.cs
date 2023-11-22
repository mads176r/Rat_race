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




            foreach (var item in manager.PlayerList)
            {
                Console.WriteLine(item.UserName);
            }


            Console.WriteLine(manager.Tracks);


            //foreach (var item in manager.Tracks)
            //{
            //    Console.WriteLine(item.Name);
            //}


            Console.WriteLine(manager.Tracks);
                    


                
            
        }

    }

}