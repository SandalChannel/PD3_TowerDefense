using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public static class CellGenerator
{
    public static List<Cell> GenerateCells(int width, int height)
    {
        //create cell list
        List<Cell> cells = new List<Cell>();

        //generates all required cells
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                cells.Add(new Cell(i, j));
            }
        }

        return cells;
    }
}
