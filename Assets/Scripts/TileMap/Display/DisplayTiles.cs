using System.Collections.Generic;
using UnityEngine;

public class DisplayTiles : ScriptableObject
{
    GameObject GrassTile;
    GameObject PathTile;
    GameObject Tile;
    
    public DisplayTiles(GameObject tile, GameObject grassTile, GameObject pathTile)
    {
        Tile = tile;
        PathTile = pathTile;
        GrassTile = grassTile;
    }

    public void InstantiateTiles(List<Cell> map)
    {
        foreach (Cell cell in map)
        {
            if (cell.CellType == CellType.Road)
            {
                Instantiate(PathTile, new Vector3(cell.Coordinates.X, 0, cell.Coordinates.Y), Quaternion.identity);
            }
            else if (cell.CellType == CellType.Grass)
            {
                Instantiate(GrassTile, new Vector3(cell.Coordinates.X, 0, cell.Coordinates.Y), Quaternion.identity);
            }
            else
            {
                Instantiate(Tile, new Vector3(cell.Coordinates.X, 0, cell.Coordinates.Y), Quaternion.identity);
            }
        }
    }
    
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
