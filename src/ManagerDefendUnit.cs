using System;

namespace Tower_Defence_Game.src
{
    internal class ManagerDefendUnit
    {
        public ManagerDefendUnit()
        {

        }

        public void Place(WorldTile[,] world, int posHorizontal, int posVertical)
        {
            if (posHorizontal < 0 || posHorizontal >= world.GetLength(0) || posVertical < 0 || posVertical >= world.GetLength(1)) return;
            if (world[posHorizontal, posVertical].DefendUnit != null) return;

            BaseDefendUnit newUnit = new BaseDefendUnit();

            if (newUnit == null) return;

            world[posHorizontal,posVertical].DefendUnit = newUnit;

        }

        public void Remove(WorldTile[,] world, int posHorizontal, int posVertical)
        {
            if (posHorizontal < 0 || posHorizontal >= world.GetLength(0) || posVertical < 0 || posVertical >= world.GetLength(1)) return;
            if (world[posHorizontal, posVertical].DefendUnit == null) return;

            world[posHorizontal, posVertical].DefendUnit = null;

        }

    }

}
