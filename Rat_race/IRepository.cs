using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rat_race
{
    public interface IRepository
    {
        public void Save<T>(List<T> save);

        public RaceManager Load(RaceManager race);
    }
}
