using Rat_race;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RatRaceBLL
{
    public class Manager
    {

        public RaceManager RaceManager { get; set; }

        public Manager()
        {
            //Stage everything!!!!

            RatRaceRepository repo = new RatRaceRepository();
            RaceManager = new RaceManager(repo);



        }

        public void PlaceBet(Race race, Rat rat, Player player, int money)
        {
            RaceManager.BookMaker.PlaceBet(race, rat, player, money);
        }


    }
}