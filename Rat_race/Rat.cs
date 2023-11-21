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

            Position = 0;
        }

        public int MoveRat()
        {
            int upper = 10;
            int lower = 0;

            RNG randomMove = new RNG();
            int move = randomMove.Range(upper, lower);

            int newPosition = _position + move;

            return newPosition;
        }
    }

}