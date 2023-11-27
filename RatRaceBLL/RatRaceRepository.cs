using System.Text.Json;
using Newtonsoft.Json;

using Rat_race;
namespace RatRaceBLL
{
    public class RatRaceRepository : IRepository
    {
        public RatRaceRepository()
        {

        }

        private readonly JsonSerializerOptions _options = new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
        };

        public void Save<T>(List<T> save)
        {
            string type = typeof(T).Name;
            string json = JsonConvert.SerializeObject(save);

            File.WriteAllText(String.Format(@"C:\Users\HFGF\source\repos\Rat_race\Rat_race\Repository\Data\{0}.json", type), json);

        }

        public RaceManager Load(RaceManager race)
        {

            RaceManager raceManager = race;
            string trackFile = (@"C:\Users\HFGF\source\repos\Rat_race\Rat_race\Repository\Data\Track.json");
            string jsonStringTrack = File.ReadAllText(trackFile);
            List<Track> tracks = JsonConvert.DeserializeObject<List<Track>>(jsonStringTrack);


            string PlayerListFile = (@"C:\Users\HFGF\source\repos\Rat_race\Rat_race\Repository\Data\Player.json");
            string jsonStringPlayerList = File.ReadAllText(PlayerListFile);
            List<Player> playerList = JsonConvert.DeserializeObject<List<Player>>(jsonStringPlayerList);


            string raceFile = (@"C:\Users\HFGF\source\repos\Rat_race\Rat_race\Repository\Data\Race.json");
            string jsonStringRace = File.ReadAllText(raceFile);
            List<Race> races = JsonConvert.DeserializeObject<List<Race>>(jsonStringRace);


            string ratFile = (@"C:\Users\HFGF\source\repos\Rat_race\Rat_race\Repository\Data\Rat.json");
            string jsonStringrat = File.ReadAllText(ratFile);
            List<Rat> rats = JsonConvert.DeserializeObject<List<Rat>>(jsonStringrat);


            raceManager.Tracks = tracks;
            raceManager.PlayerList = playerList;
            raceManager.Races = races;
            raceManager.Rats = rats;


            return raceManager;
        }
    }
}