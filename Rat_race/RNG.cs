using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rat_race
{
    internal class RNG
    {
        private RNG _rng = new RNG();

        public int Range(int upper, int lower)
        {
            int random = _rng.Range(upper, lower);
            return random;

        }
    }
}
