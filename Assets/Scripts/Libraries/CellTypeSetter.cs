using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class CellTypeSetter
{
    public static void SetCellType(List<Cell> cells, Coordinates coordinates, CellType type)
    {
        Cell cell = CellGetter.GetCell(cells, coordinates);
        cell.CellType = type;
    }
}
