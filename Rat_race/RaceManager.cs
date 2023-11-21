using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rat_race
{
    public class RaceManager
    {
        internal List<Track> Tracks; //Der skal ikke "s" på typen som der bliver vist i vejledningen 
        internal List<Player> PlayerList;
        internal List<Race> Races;
        internal List<Rat> Rats;


        //public Race CreateRace(int raceID, List<Rat> rats, Track track)
        //{
        //    Console.WriteLine("ikke færdig");

        //    return null;
        //}

        //public Track CreateTrack(string name, int trackLength) //public Track skal være med stort "T", vejledningen siger lille
        //{
        //    Console.WriteLine("ikke færdig");

        //    return null;
        //}

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
