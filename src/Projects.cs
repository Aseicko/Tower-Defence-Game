using System;
using Tower_Defence_Game.src;

internal class Projects
{
    static void Main()
    {
        IMainMenu mainMenu = new ManagerMainMenu(); ;

        while (true)
        {
            mainMenu.Execute();

        }

    }

}
