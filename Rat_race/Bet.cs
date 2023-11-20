using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rat_race
{
    internal class Bet
    {
        private int _money;
        private Player _player;
        private Race _race;
        private Rat _rat;
    
    
        public void PayWinnings()
        {
            _money = 0;
        }
    }
}
