﻿using Newtonsoft.Json;
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
        public List<Player> PlayerList = new List<Player>();
        public List<Race> Races = new List<Race>();
        public List<Rat> Rats = new List<Rat>();

        public Race CreateRace(int raceID, List<Rat> rats, Track track)
        {
            Race race = new Race();
            RatRaceRepository ratRaceRepository = new RatRaceRepository();

            race.RaceID = raceID;
            race.Rats = rats;
            race.RaceTrack = track;

            Races.Add(race);

            ratRaceRepository.Save(Races);

            return race;
        }

        public Track CreateTrack(string name, int trackLength) //public track skal være med stort "t", vejledningen siger lille
        {
            Track track = new Track();
            RatRaceRepository ratRaceRepository = new RatRaceRepository();

            track.Name = name;
            track.TrackLength = trackLength;

            Console.WriteLine(track.Name + " " + track.TrackLength + " " + track);

            Tracks.Add(track);

            ratRaceRepository.Save(Tracks);

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
            RatRaceRepository ratRaceRepository = new RatRaceRepository();

            rat.Name = name;
            rat.Position = 0;

            Rats.Add(rat);

            ratRaceRepository.Save(Rats);

            return rat;
        }

        public Player CreatePlayer(string userName, string password) //username må ikke kunne gentages
        {
            Player player = new Player();
            RatRaceRepository ratRaceRepository = new RatRaceRepository();

            player.UserName = userName;
            player.Password = password;
            player.Money = 100; 

            PlayerList.Add(player);

            ratRaceRepository.Save(PlayerList);

            return player;
        }

        public Player LoginToPlayer(string userName, string password)
        {
            if (PlayerList.Count > 0)
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
