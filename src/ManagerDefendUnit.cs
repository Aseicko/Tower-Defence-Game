using System;
using System.Collections.Generic;

namespace Tower_Defence_Game.src
{
    internal interface IManagerDefendUnit
    {
        BaseDefendUnit ExecuteUnitSelection();

    }

    internal class ManagerDefendUnit : IManagerDefendUnit
    {
        private ConsoleKeyInfo inputDefendUnit;

        private Dictionary<char, Func<BaseDefendUnit>> AvailableDefendUnits = new Dictionary<char, Func<BaseDefendUnit>>
        {
            {'1', () => new AttackProjectileSingle() },
            {'2', () => new AttackHitscanSingle() }
        };

        public ManagerDefendUnit()
        {

        }

        public BaseDefendUnit ExecuteUnitSelection()
        {
            DisplayUnitSelection();
            return ProcessUnitSelection();

        }

        public void Place(WorldTile[,] world, int posHorizontal, int posVertical)
        {
            if (posHorizontal < 0 || posHorizontal >= world.GetLength(0) || posVertical < 0 || posVertical >= world.GetLength(1)) return;
            if (world[posHorizontal, posVertical].DefendUnit != null) return;

            BaseDefendUnit newUnit = ExecuteUnitSelection();

            if (newUnit == null) return;

            world[posHorizontal, posVertical].DefendUnit = newUnit;

        }

        public void Remove(WorldTile[,] world, int posHorizontal, int posVertical)
        {
            if (posHorizontal < 0 || posHorizontal >= world.GetLength(0) || posVertical < 0 || posVertical >= world.GetLength(1)) return;
            if (world[posHorizontal, posVertical].DefendUnit == null) return;

            world[posHorizontal, posVertical].DefendUnit = null;

        }

        public void DisplayUnitSelection()
        {
            Console.WriteLine("<Units>");
            foreach(var item in AvailableDefendUnits)
            {
                Console.WriteLine($"{item.Key}. {item.Value()}");
            }
            Console.WriteLine("</Units>");

        }

        public BaseDefendUnit ProcessUnitSelection()
        {
            inputDefendUnit = Console.ReadKey(intercept: true);

            if (AvailableDefendUnits.TryGetValue(inputDefendUnit.KeyChar, out var defendUnit))
            {
                return defendUnit();
            }
            else
            {
                return null;
            }

        }

    }

}
