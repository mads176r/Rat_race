using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

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

        public bool Save(RaceManager save)
        {
            List<Rat> Rats = save.Rats;
            string rats = JsonSerializer.Serialize(Rats, _options);

            List<Race> Races = save.Races;
            string races = JsonSerializer.Serialize(Races, _options);

            List<Player> PlayerList = save.PlayerList;
            string playerList = JsonSerializer.Serialize(PlayerList, _options);

            List<Track> Tracks = save.Tracks;
            string tracks = JsonSerializer.Serialize(Tracks, _options);


            File.WriteAllText(@"C:\Users\HFGF\source\repos\Rat_race\Rat_race\Repository\Data\rats.json", rats);
            File.WriteAllText(@"C:\Users\HFGF\source\repos\Rat_race\Rat_race\Repository\Data\races.json", races);
            File.WriteAllText(@"C:\Users\HFGF\source\repos\Rat_race\Rat_race\Repository\Data\playerList.json", playerList);
            File.WriteAllText(@"C:\Users\HFGF\source\repos\Rat_race\Rat_race\Repository\Data\tracks.json", tracks);

            return true;
        }

        public RaceManager Load()
        {
            RaceManager raceManager = new RaceManager();
            string trackFile = "\"C:\\Users\\HFGF\\source\\repos\\Rat_race\\Rat_race\\Repository\\Data\\tracks.json";
            string jsonString = File.ReadAllText(trackFile);
            Track deTracks = JsonSerializer.Deserialize<Track>(trackFile)!;

            return deTracks;
        }
    }    
}
