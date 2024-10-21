using System.Collections.Generic;
using UnityEngine;

public abstract class DisplayMap : MonoBehaviour
{
    [SerializeField] GameObject GrassTile;
    [SerializeField] GameObject PathTile;
    [SerializeField] GameObject Tile;

    [SerializeField] int[] MapSize = {10, 10};

    [SerializeField] List<ICoordinate> PathCoords = new List<ICoordinate>()
        {
            //new GridCoordinates(0, 2),
            //new GridCoordinates(1, 2),
            //new GridCoordinates(2, 2),
            //new GridCoordinates(2, 3),
            //new GridCoordinates(3, 3),
            //new GridCoordinates(3, 4),
            //new GridCoordinates(4, 4),
            //new GridCoordinates(5, 4),
            //new GridCoordinates(6, 4),
            //new GridCoordinates(7, 4),
            //new GridCoordinates(8, 4),
            //new GridCoordinates(9, 4)
        };


    void Start()
    {
        Map map = CreateMap(MapSize);

        

        //sets the celltype for the path
        foreach (var coords in PathCoords)
        {
            CellTypeSetter.SetCellType(map.GetAllCells(), coords, CellType.Road);
        }

        //renders the tiles
        InstantiateTiles(map.GetAllCells());
    }

    //vestigial constructor, managed by Unity now
    //public DisplayMap(GameObject tile, GameObject grassTile, GameObject pathTile)
    //{
    //    Tile = tile;
    //    PathTile = pathTile;
    //    GrassTile = grassTile;
    //}

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
            else
            {
                InstantiateTile(Tile, cell);
            }
        }
    }

    public abstract void InstantiateTile(GameObject tile, Cell cell);

    public abstract Map CreateMap(int[] mapSize);

}

