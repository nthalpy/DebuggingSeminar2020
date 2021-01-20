namespace Example6
{
    internal struct Square : IShape
    {
        public int Width;
        public int Height;
        
        public Square(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Expand(int delta)
        {
            Width += delta;
            Height += delta;
        }
    }
}
