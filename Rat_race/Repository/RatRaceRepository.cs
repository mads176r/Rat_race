using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Rat_race.Repository
{
    public class RatRaceRepository
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

        public RaceManager Load()
        {
            RaceManager raceManager = new RaceManager();
            string trackFile = (@"C:\Users\HFGF\source\repos\Rat_race\Rat_race\Repository\Data\Track.json");
            string jsonString = File.ReadAllText(trackFile);
            List<Track> tracks = JsonConvert.DeserializeObject<List<Track>>(jsonString);
            raceManager.Tracks = tracks;
            return raceManager;
        }
    }
}
