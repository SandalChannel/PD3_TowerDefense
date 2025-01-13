using System.Collections.Generic;
using Logic.TileMap;

namespace Logic.Libraries
{
    public static class CellGenerator
    {
        public static List<Cell> GenerateCells(int width, int height)
        {
            //create cell list
            List<Cell> cells = new();

            //generates all required cells
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    cells.Add(new Cell(CellType.Grass, i, j));
                }
            }

            return cells;
        }
    }
}
