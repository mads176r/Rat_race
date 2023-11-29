using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Rat_race
{
    public class Rat
    {
        public string Name;
        private int _position;
        public int Position
        {
            get
            {
                return _position;
            }
            set
            {
                if (_position != value)
                {
                    _position = value;
                }
            }
        }

        public void ResetRat()
        {
            _position = 0;
        }

        public int MoveRat()
        {
            int upper = 10;
            int lower = 0;

            int move = RNG.Range(lower, upper);

            int newPosition = _position + move;
            _position = newPosition;
            return move;
        }
    }
}
