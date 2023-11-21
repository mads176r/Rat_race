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
            ratRaceRepository.Load();


        }


    }
}