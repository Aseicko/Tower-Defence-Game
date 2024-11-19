using System;
using System.Threading;

namespace Tower_Defence_Game.src
{
    public interface IWorld
    {
        void Execute();
    }

    internal class ManagerWorld : IWorld
    {
        const int millisecondsPerFrame = 20;

        protected WorldTile[,] worldTileData;

        protected (int, int) currentPlayerPosition = (0, 0);

        ConsoleKey inputWorld;

        protected IActions actions = new ManagerAction();

        internal ManagerWorld(uint sizeHorizontal, uint sizeVertical)
        {
            worldTileData = new WorldTile[sizeHorizontal, sizeVertical];

            this.Inicialize();
        }

        void IWorld.Execute()
        {
            Console.Clear();

            //temp field size data
            ManagerWorld world = new ManagerWorld(10,10);
            bool isGameRun = true;

            Thread threadDisplayWorld = new Thread(() =>
            {
                while (isGameRun)
                {
                    lock (world)
                    {
                        world.Update();
                        world.Display();
                        Thread.Sleep(millisecondsPerFrame);

                    }

                }
            });

            threadDisplayWorld.Start();
            Thread.Sleep(millisecondsPerFrame);

            while (isGameRun)
            {
                lock (world)
                {
                    world.Process(ref isGameRun);

                }

            }

            threadDisplayWorld.Join();

            Console.Clear();
        }

        void Update()
        {
            for (int i = 0; i < worldTileData.GetLength(0); i++)
            {
                for(int j = 0; j < worldTileData.GetLength(1); j++)
                {
                    if (currentPlayerPosition == (i, j))
                    {
                        Console.SetCursorPosition(0, 12);
                        Console.Write($"Data of {i} {j} is {worldTileData[i,j]}");
                    }

                }

            }

        }

        private void Inicialize()
        {
            for (int i = 0; i < worldTileData.GetLength(0); i++)
            {
                for (int j = 0; j < worldTileData.GetLength(1); j++)
                {
                    worldTileData[i, j] = new WorldTile();
                }
            }

        }

        private void Display()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("<World>");

            for (int i = 0; i < worldTileData.GetLength(0); i++)
            {
                for (int j = 0; j < worldTileData.GetLength(1); j++)
                {
                    if (currentPlayerPosition == (i, j))
                    {
                        Console.Write('|' + worldTileData[i, j].ToString() + "|");
                    }
                    else { Console.Write(' ' + worldTileData[i, j].ToString() + ' '); }
                }
                Console.WriteLine();
            }

            Console.WriteLine("</World>");

        }

        private void Process(ref bool continueGame)
        {
            inputWorld = Console.ReadKey(intercept: true).Key;

            switch (inputWorld)
            {
                default:
                    break;

                case ConsoleKey.W:
                    currentPlayerPosition.Item1 = Math.Max(0, currentPlayerPosition.Item1 - 1);
                    break;

                case ConsoleKey.S:
                    currentPlayerPosition.Item1 = Math.Min(worldTileData.GetLength(0) - 1, currentPlayerPosition.Item1 + 1);
                    break;

                case ConsoleKey.A:
                    currentPlayerPosition.Item2 = Math.Max(0, currentPlayerPosition.Item2 - 1);
                    break;

                case ConsoleKey.D:
                    currentPlayerPosition.Item2 = Math.Min(worldTileData.GetLength(1) - 1, currentPlayerPosition.Item2 + 1);
                    break;

                case ConsoleKey.Spacebar:
                    actions.Execute();
                    break;

                case ConsoleKey.Escape:
                    continueGame = false;
                    break;
            }

        }

    }

}
