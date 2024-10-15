using System.Collections.Generic;

public class Map
{
    public int Width { get; set; }
    public int Height { get; set; }

    public List<Cell> Cells { get; set; }

    public List<Cell> GetAllCells()
    {
        return Cells;
    }

    public Map(int width, int height)
    {
        Width = width;
        Height = height;

        Cells = CellGridGenerator.GenerateCells(width, height);
    }
}

public static class CellGridGenerator
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

public static class CellTypeSetter
{
    public static void SetCellType(List<Cell> cells, Coordinates coordinates, CellType type)
    {
        Cell cell = CellGetter.GetCell(cells ,coordinates);
        cell.CellType = type;
    }
}

public static class CellGetter
{
    public static Cell GetCell(List<Cell> cells, Coordinates coordinates)
    {
        foreach (Cell cell in cells)
        {
            if (cell.Coordinates.X == coordinates.X && cell.Coordinates.Y == coordinates.Y)
            {
                return cell;
            }
        }
        return null;
    }
}
