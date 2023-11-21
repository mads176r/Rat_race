﻿namespace Rat_race
{
    internal class Bet
    {
        private int _money;
        public int Money
        {
            get
            {
                return _money;
            }
            set
            {
                if (_money != value)
                {
                    _money = value;
                }
            }
        }

        private Player _player;
        public Player Player
        {
            get
            {
                return _player;
            }
            set
            {
                if (_player != value)
                {
                    _player = value;
                }
            }
        }

        private Race _race;
        public Race Race
        {
            get
            {
                return _race;
            }
            set
            {
                if (_race != value)
                {
                    _race = value;
                }
            }
        }

        private Rat _rat;
        public Rat Rat
        {
            get
            {
                return _rat;
            }
            set
            {
                if (_rat != value)
                {
                    _rat = value;
                }
            }
        }


        public void PayWinnings()
        {
            
        }
    }
}
