using System.Collections.Generic;
using Logic.TileMap;

namespace Logic.Libraries
{
    public static class CellTypeSetter
    {
        public static void SetCellType(List<Cell> cells, Coordinates coordinates, CellType type)
        {
            Cell cell = CellGetter.GetCell(cells, coordinates);
            cell.CellType = type;
        }
    }
}