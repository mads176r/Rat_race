using Rat_race.Repository;
using System.Diagnostics;

namespace Rat_race
{
    public class Race
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
            foreach (Rat rat in Rats)
            {
                rat.ResetRat();
            }

            while (Winner == null)
            {
                foreach (Rat rat in Rats)
                {
                    rat.MoveRat();

                    string infoToLog = rat.Name + " moved " + rat.Position + "\n";
                    logRace(infoToLog);

                    if (rat.Position >= RaceTrack.TrackLength)
                    {
                        _winner = rat;
                        string winnerToLog = "\n" + rat.Name + " Won the race";
                        logRace(winnerToLog);
                        break;
                    }
                }
                logRace("\n");
            }
        }

        public Rat GetWinner()
        {
            return _winner;
        }

        public string GetRaceReport()
        {
            return _log;
        }

        private void logRace(string infoToLog)
        {
            _log += infoToLog;
        }

    }

}
