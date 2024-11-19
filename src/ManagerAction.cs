using System;

namespace Tower_Defence_Game.src
{
    internal interface IActions
    {
        void Execute(ref WorldTile[,] world, ref (int, int) playerPosition);

    }

    internal class ManagerAction : IActions
    {
        ConsoleKey inputAction;

        ManagerDefendUnit defendUnit = new ManagerDefendUnit();

        void IActions.Execute(ref WorldTile[,] world, ref (int,int) playerPosition)
        {
            this.Display();
            this.Process(ref world, ref playerPosition);

            Console.Clear();

        }

        private void Display()
        {
            Console.SetCursorPosition(0, 13);

            Console.WriteLine("<Actions>");
            Console.WriteLine("001. Place Defend Unit");
            Console.WriteLine("002. Remove Defend Unit");
            Console.WriteLine("</Actions>");

        }

        private void Process(ref WorldTile[,] world, ref (int, int) playerPosition)
        {
            inputAction = Console.ReadKey(intercept: true).Key;

            switch (inputAction)
            {
                default:
                    break;

                case ConsoleKey.D1:
                    defendUnit.Place(world, playerPosition.Item1, playerPosition.Item2);
                    break;

                case ConsoleKey.D2:
                    
                    break;

            }

        }

    }

}
