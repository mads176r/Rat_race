﻿namespace Rat_race
{
    internal class Race
    {
        public int RaceID;

        //rat list

        public Track RaceTrack;
        private Rat _winner;
        private string _log;



        public void ConductRace()
        {

        }

        public Rat GetWinner()
        {
            return _winner;
        }

        public string GetRaceReport()
        {
            return _log;
        }

        private void logRace()
        {

        }

    }

}
