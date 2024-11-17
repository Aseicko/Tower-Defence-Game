using System;

namespace Tower_Defence_Game.src
{
    public interface IMainMenu
    {
        void Execute();
    }

    internal class ManagerMainMenu : IMainMenu
    {
        ConsoleKeyInfo inputMainMenu;

        internal ManagerMainMenu()
        {
            Console.CursorVisible = false;

        }

        void IMainMenu.Execute()
        {
            this.Display();
            this.Process();
        }

        private void Display()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine
            (
                "<Main-Menu>\n" +
                "001. Start\n" +
                "002. Settings\n" +
                "Esc. Exit\n" +
                "</Main-Menu>"
            );

        }

        private void Process()
        {
            inputMainMenu = Console.ReadKey(intercept: true);

            switch (inputMainMenu.Key)
            {
                default:
                    break;

                case ConsoleKey.D1:
                    this.EventStartGame();
                    break;

                case ConsoleKey.D2:
                    this.EventOpenSettings();
                    break;

                case ConsoleKey.Escape:
                    this.EventEndGame();
                    break;
            }

        }

        private void EventStartGame()
        {
            IWorld world = new ManagerWorld(10, 10);
            world.Execute();
        }

        private void EventOpenSettings()
        {
            throw new NotImplementedException();
        }

        private void EventEndGame()
        {
            Console.Clear();
            Console.WriteLine("Thanks for playing!");
            Environment.Exit(0);
        }

    }

}
