using System;

namespace Example7
{
    public sealed class GameMessage
    {
        public readonly String Message;
        public readonly ConsoleColor Color;

        public GameMessage(String message, ConsoleColor color)
        {
            Message = message;
            Color = color;
        }
    }
}