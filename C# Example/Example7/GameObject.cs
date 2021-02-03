using System;

namespace Example7
{
    public abstract class GameObject
    {
        public readonly Char Display;
        public readonly ConsoleColor Color;

        protected GameObject(Char display)
            : this(display, ConsoleColor.White)
        {
        }
        protected GameObject(Char display, ConsoleColor color)
        {
            Display = display;
            Color = color;
        }
    }
}