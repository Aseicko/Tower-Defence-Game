using System;
using System.Threading;

namespace Tower_Defence_Game.src
{
    public interface IActions
    {
        void Execute();

    }

    internal class ManagerAction : IActions
    {
        ConsoleKey inputAction;

        void IActions.Execute()
        {
            this.Display();
            this.Process();

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

        private void Process()
        {
            inputAction = Console.ReadKey(intercept: true).Key;

            switch (inputAction)
            {
                default:
                    break;

                case ConsoleKey.D1:

                    break;

                case ConsoleKey.D2:
                    
                    break;

            }

        }

    }

}
