using System.Collections.Generic;

public class Map
{

    public MapType Type { get; set; }

    public List<Cell> Cells { get; set; }

    public List<Cell> GetAllCells()
    {
        return Cells;
    }

    public Map(MapType mapType, int width, int height) //use when generating new map
    {
        Type = mapType;

        Cells = CellGenerator.GenerateCells(width, height);

    }

    public Map(MapType mapType, List<Cell> cells) //use when getting map from list of cells
    {
        Cells = cells;
    }
}


