using System;
using System.Collections.Generic;
using System.Linq;

namespace Example7
{
    internal static class Program
    {
        private const int ScreenWidth = 40;
        private const int ScreenHeight = 10;

        private const int MaxMessageCount = 8;

        // Since object is sparce enough, we want to manage this thru Dictionary`2.
        private static Dictionary<Coordinate, GameObject> objectInfo;

        private static Player player;
        private static Coordinate playerCoord;

        private static List<GameMessage> messageList;

        private static Random rd;

        private static void Main()
        {
            objectInfo = new Dictionary<Coordinate, GameObject>();
            messageList = new List<GameMessage>();
            rd = new Random();

            PrepareObject();

            // Main game loop.
            while (true)
            {
                RenderScreen();
                HandleInput();

                RandomWalkGoblin();
                RandomSpawnGoblin();

                TruncateMessage();
            }
        }

        // Handle player input.
        private static void HandleInput()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            int dx = 0;
            int dy = 0;
            switch (input.Key)
            {
                case ConsoleKey.LeftArrow:
                    dx = -1;
                    break;

                case ConsoleKey.RightArrow:
                    dx = 1;
                    break;

                case ConsoleKey.UpArrow:
                    dy = -1;
                    break;

                case ConsoleKey.DownArrow:
                    dy = 1;
                    break;
            }

            Coordinate newCoord = new Coordinate(playerCoord.X + dx, playerCoord.Y + dy);
            if (objectInfo.ContainsKey(newCoord))
            {
                switch (objectInfo[newCoord])
                {
                    case VerticalWall _:
                    case HorizontalWall _:
                    case CornerWall _:
                        messageList.Add(new GameMessage("You ran in to the wall.", ConsoleColor.Gray));
                        break;

                    case Goblin _:
                        messageList.Add(new GameMessage("You attack the goblin.", ConsoleColor.White));
                        messageList.Add(new GameMessage("You slayed the goblin.", ConsoleColor.White));

                        objectInfo.Remove(newCoord);
                        break;
                }
            }
            else
            {
                playerCoord.X += dx;
                playerCoord.Y += dy;
            }
        }

        private static void PrepareObject()
        {
            // Prepare wall
            objectInfo.Add(new Coordinate(0, 0), new CornerWall());
            objectInfo.Add(new Coordinate(ScreenWidth - 1, 0), new CornerWall());
            objectInfo.Add(new Coordinate(0, ScreenHeight - 1), new CornerWall());
            objectInfo.Add(new Coordinate(ScreenWidth - 1, ScreenHeight - 1), new CornerWall());

            for (int x = 1; x < ScreenWidth - 1; x++)
            {
                objectInfo.Add(new Coordinate(x, 0), new HorizontalWall());
                objectInfo.Add(new Coordinate(x, ScreenHeight - 1), new HorizontalWall());
            }
            for (int y = 1; y < ScreenHeight - 1; y++)
            {
                objectInfo.Add(new Coordinate(0, y), new VerticalWall());
                objectInfo.Add(new Coordinate(ScreenWidth - 1, y), new VerticalWall());
            }

            // Prepare character
            player = new Player();
            playerCoord = new Coordinate(1, 1);
            objectInfo.Add(playerCoord, player);
        }

        private static void RandomWalkGoblin()
        {
            // Goblins does random walk for test purpose.
            // If player is on the way, Goblin tries to attack player.
            foreach (KeyValuePair<Coordinate, GameObject> kvp in objectInfo.Where(kvp => kvp.Value is Goblin))
            {
                while (true)
                {
                    int move = rd.Next() % 9;
                    int dx = (move / 3) - 1;
                    int dy = (move % 3) - 1;

                    Coordinate newCoord = new Coordinate(kvp.Key.X + dx, kvp.Key.Y + dy);
                    if (objectInfo.ContainsKey(newCoord))
                    {
                        if (objectInfo[newCoord] is Player)
                        {
                            messageList.Add(new GameMessage("Goblin attacks you!", ConsoleColor.Red));
                            messageList.Add(new GameMessage("You barely evades attack.", ConsoleColor.Green));
                        }
                    }
                    else
                    {
                        kvp.Key.X += dx;
                        kvp.Key.Y += dy;
                        break;
                    }
                }
            }
        }

        private static void RandomSpawnGoblin()
        {
            // Spawn goblin for test purpose, at 10% chance per player turn.
            if (rd.Next() % 10 == 0)
            {
                while (true)
                {
                    int x = rd.Next() % ScreenWidth;
                    int y = rd.Next() % ScreenHeight;
                    Coordinate c = new Coordinate(x, y);

                    if (objectInfo.ContainsKey(c) == false)
                    {
                        objectInfo.Add(c, new Goblin());
                        messageList.Add(new GameMessage("Suddenly Goblin appeares from nowhere!", ConsoleColor.White));
                        break;
                    }
                }
            }
        }

        private static void TruncateMessage()
        {
            if (messageList.Count > MaxMessageCount)
                messageList.RemoveRange(0, messageList.Count - MaxMessageCount);
        }

        private static void RenderScreen()
        {
            Console.Clear();

            // Render objects
            foreach (KeyValuePair<Coordinate, GameObject> kvp in objectInfo)
            {
                Console.SetCursorPosition(kvp.Key.X, kvp.Key.Y);
                Console.ForegroundColor = kvp.Value.Color;
                Console.Write(kvp.Value.Display);
            }

            Console.SetCursorPosition(0, ScreenHeight + 1);

            // Render messages
            foreach (GameMessage message in messageList)
            {
                Console.ForegroundColor = message.Color;
                Console.WriteLine(message.Message);
            }
        }
    }
}
