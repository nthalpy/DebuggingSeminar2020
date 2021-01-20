namespace Example6
{
    internal struct Circle : IShape
    {
        public int Radius;

        public Circle(int radius)
        {
            Radius = radius;
        }

        public void Expand(int delta)
        {
            Radius += delta;
        }
    }
}
