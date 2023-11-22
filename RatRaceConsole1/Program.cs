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
            Track track = new Track();


            //track = manager.CreateTrack("TestTrack",25);

            //manager.Tracks.Add(track);
            //ratRaceRepository.Save(manager.Tracks);

            manager = ratRaceRepository.Load();

            Console.WriteLine(manager.Tracks);

        }


    }
}