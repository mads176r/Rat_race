namespace Rat_race
{
    internal class Race
    {
        public int RaceID;
        public List<Rat> Rats;
        public Track RaceTrack;

        private Rat _winner;
        public Rat Winner
        {
            get
            {
                return _winner;
            }
            set
            {
                if (_winner != value)
                {
                    _winner = value;
                }
            }
        }

        private string _log;
        public string Log
        {
            get
            {
                return _log;
            }
            set
            {
                if (_log != value)
                {
                    _log = value;
                }
            }
        }


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
