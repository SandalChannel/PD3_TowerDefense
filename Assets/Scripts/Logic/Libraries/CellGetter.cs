using System.Collections.Generic;
using Logic.TileMap;

namespace Logic.Libraries
{
    public static class CellGetter
    {
        public static Cell GetCell(List<Cell> cells, Coordinates coordinates)
        {
            foreach (Cell cell in cells)
            {
                if (cell.Coordinates.ToString() == coordinates.ToString()) //ToString() is required here because the check otherwise is for Type (I think) and therefore always returns false
                {
                    return cell;
                }
            }
            return null;
        }

        public static List<Cell> GetCellsByType(List<Cell> cells, CellType type)
        {
            List<Cell> result = new();
            foreach (Cell cell in cells)
            {
                if (cell.CellType == type)
                {
                    result.Add(cell);
                }
            }
            return result;
        }
    }
}
