﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rat_race
{
    internal static class RNG
    {
        private static Random _rng = new Random();

        public static int Range(int lower, int upper)
        {
            int random = _rng.Next(lower, upper);
            return random;

        }
    }
}
