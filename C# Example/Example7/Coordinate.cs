namespace Example7
{
    // Coordinate on the screen. Left top is the origin.
    public sealed class Coordinate
    {
        public int X;
        public int Y;

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static bool operator ==(Coordinate lhs, Coordinate rhs)
        {
            return lhs.Equals(rhs);
        }
        public static bool operator !=(Coordinate lhs, Coordinate rhs)
        {
            return !lhs.Equals(rhs);
        }

        public override int GetHashCode()
        {
            // Simple pairing function.
            // (Almost) Uniquely encodes two integer to single integer

            unchecked
            {
                return (X + Y) * (X + Y + 1) / 2 + Y;
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Coordinate ch)
                return ch.X == this.X && ch.Y == this.Y;

            return false;
        }
    }
}
