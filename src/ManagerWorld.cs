using System;

namespace Tower_Defence_Game.src
{
    internal class ManagerWorld
    {
        protected WorldTile[,] worldTileData;

        protected (int, int) currentPlayerPosition = (0, 0);

        internal ManagerWorld(uint sizeHorizontal, uint sizeVertical)
        {
            worldTileData = new WorldTile[sizeHorizontal, sizeVertical];

            this.Inicialize();
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

        }

    }

}
