using System.Collections.Generic;
using UnityEngine;

public abstract class DisplayMap : MonoBehaviour
{
    [SerializeField] GameObject GrassTile;
    [SerializeField] GameObject PathTile;
    [SerializeField] GameObject BuildableTile;
    [SerializeField] GameObject SpawnerTile;
    [SerializeField] GameObject GoalTile;
    [SerializeField] GameObject Tile;
    

    [SerializeField] int[] MapSize = {10, 10};

    [SerializeField] List<Coordinates> PathCoords = new List<Coordinates>()
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

    [SerializeField]
    List<Coordinates> SpawnerCoords = new List<Coordinates>()
        {
            new Coordinates(0, 2)
        };

    [SerializeField]
    List<Coordinates> GoalCoords = new List<Coordinates>()
        {
            new Coordinates(9, 4)
        };

    [SerializeField]
    List<Coordinates> BuildableCoords = new List<Coordinates>()
        {
            new Coordinates(3, 2),
            new Coordinates(5, 5)
        };

    public Map Map { get; set; }


    void Awake()
    {
        Map = CreateMap(MapSize);

        //actually sets the tile type
        SetMapCellTypes(Map);

        //renders the tiles
        InstantiateTiles(Map.GetAllCells());
    }

    //vestigial constructor, managed by Unity now
    //public DisplayMap(GameObject tile, GameObject grassTile, GameObject pathTile)
    //{
    //    Tile = tile;
    //    PathTile = pathTile;
    //    GrassTile = grassTile;
    //}

    public void SetMapCellTypes(Map map)
    {
        //sets the celltype for the path
        foreach (var coords in PathCoords)
        {
            CellTypeSetter.SetCellType(map.GetAllCells(), coords, CellType.Road);
        }
        foreach (var coords in SpawnerCoords)
        {
            CellTypeSetter.SetCellType(map.GetAllCells(), coords, CellType.Spawner);
        }
        foreach (var coords in GoalCoords)
        {
            CellTypeSetter.SetCellType(map.GetAllCells(), coords, CellType.Goal);
        }
        foreach (var coords in BuildableCoords)
        {
            CellTypeSetter.SetCellType(map.GetAllCells(), coords, CellType.Buildable);
        }

    }

    public void InstantiateTiles(List<Cell> map)
    {
        foreach (Cell cell in map)
        {
            if (cell.CellType == CellType.Road)
            {
                InstantiateTile(PathTile, cell);
            }
            else if (cell.CellType == CellType.Grass)
            {
                InstantiateTile(GrassTile, cell);
            }
            else if (cell.CellType == CellType.Spawner)
            {
                InstantiateTile(SpawnerTile, cell);
            }
            else if (cell.CellType == CellType.Goal)
            {
                InstantiateTile(GoalTile, cell);
            }
            else if (cell.CellType == CellType.Buildable)
            {
                InstantiateTile(BuildableTile, cell);
            }
            else
            {
                InstantiateTile(Tile, cell);
            }
        }
    }

    public abstract void InstantiateTile(GameObject tile, Cell cell);

    public abstract Map CreateMap(int[] mapSize);

}


