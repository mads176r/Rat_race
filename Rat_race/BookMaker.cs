using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rat_race
{
    public class BookMaker //Fejl i navnet på vejledningen
    {

        public List<Bet> Bets = new List<Bet>();


        public Bet? PlaceBet(Race race, Rat rat, Player player, int money)
        {
            Bet bet = new Bet();

            if (player.Money >= money)
            { 
                bet.Money = money;
                bet.Race = race;
                bet.Player = player;
                bet.Rat = rat;
                Bets.Add(bet);

                player.Money -= money;

                return bet;
            }
            else
            {
                Console.WriteLine("Insufficient funds. You have " + player.Money + " left");
                return null;
            }

        }

        public void PayOutWinnings(Bet bet) 
        {
            bet.PayWinnings();
        }
    }
}
