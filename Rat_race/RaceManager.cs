using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rat_race
{
    internal class RaceManager
    {
        public List<Track> Tracks; //Der skal ikke "s" på typen som der bliver vist i vejledningen 
        public List<Player> Player;
        public List<Race> Races;
        public List<Rat> Rats;


        public Race CreateRace(int raceID, List<Rat> rats, Track track)
        {
            
        }

        public Track CreateTrack(string name, int trackLength) //public Track skal være med stort "T", vejledningen siger lille
        {

        }

        public void ConductRace(Race race) 
        {
            
        }

        public string ViewRaceReport(Race race)
        {

        }

        public Rat CreateRat(string name)
        {

        }

        public Player CreatePlayer(string name, int money) 
        { 
            
        }
    }
}
