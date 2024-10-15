using System.Collections.Generic;

public class Game
{
    void Start()
    {
        Map map = new Map(10, 10);

        List<Coordinates> pathCoords = new List<Coordinates>()
        {
            new Coordinates(0, 2),
            new Coordinates(1, 2),
            new Coordinates(2, 2),
            new Coordinates(2, 3),
            new Coordinates(3, 3),
            new Coordinates(3, 4),
            new Coordinates(4, 4),
            new Coordinates(5, 4),
            new Coordinates(6, 4),
            new Coordinates(7, 4),
            new Coordinates(8, 4),
            new Coordinates(9, 4)
        };

        //sets the celltype for the path
        foreach (var coords in pathCoords)
        {
            CellTypeSetter.SetCellType(map.GetAllCells(), coords, CellType.Road);
        }
    }

    void Update()
    {
        
    }
}
