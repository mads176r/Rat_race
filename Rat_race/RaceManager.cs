using Newtonsoft.Json;
using Rat_race.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rat_race
{
    public class RaceManager
    {
        public List<Track> Tracks = new List<Track>(); //Der skal ikke "s" på typen som der bliver vist i vejledningen 
        internal List<Player> PlayerList = new List<Player>();
        internal List<Race> Races = new List<Race>();
        public List<Rat> Rats = new List<Rat>();


        public Race CreateRace(int raceID, List<Rat> rats, Track track)
        {
            Race race = new Race();
            race.RaceID = raceID;
            race.Rats = rats;
            race.RaceTrack = track;

            Races.Add(race);

            return race;
        }

        public Track CreateTrack(string name, int trackLength) //public track skal være med stort "t", vejledningen siger lille
        {
            Track track = new Track();

            track.Name = name;
            track.TrackLength = trackLength;

            Console.WriteLine(track.Name + " " + track.TrackLength + " " + track);

            Tracks.Add(track);

            return track;
        }

        //public void ConductRace(Race race)
        //{

        //}

        public string ViewRaceLog(Race race) //Der skal ikke stå RaceRepport, da det hedder log andre steder
        {
            Console.WriteLine("ikke færdig");

            return null;
        }

        public Rat CreateRat(string name)
        {
            Rat rat = new Rat();
            rat.Name = name;
            rat.Position = 0;

            Rats.Add(rat);

            return rat;
        }

        public Player CreatePlayer(string userName, string password, int money)
        {
            Player player = new Player();
            player.UserName = userName;
            player.Password = password;
            player.Money = money;

            PlayerList.Add(player);

            return player;
        }

        public Player LoginToPlayer(string userName, string password)
        {
            Player player = new Player();

            if (!PlayerList.Any())
            {
                Player user = PlayerList.FirstOrDefault(u => u.UserName == userName);
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        return user;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong password or username");
                }
            }
            else
            {
                Console.WriteLine("No player exist");
            }
            return null;
        }



    }
}
