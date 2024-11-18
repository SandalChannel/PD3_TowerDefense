using System.Collections.Generic;

public class Map
{
    
    
    public int Width { get; set; }
    public int Height { get; set; }

    public MapType Type { get; set; }

    public List<Cell> Cells { get; set; }

    public List<Cell> GetAllCells()
    {
        return Cells;
    }

    public Map(MapType mapType ,int width, int height)
    {
        Width = width;
        Height = height;
        Type = mapType;

        Cells = CellGenerator.GenerateCells(width, height);

    }
}


