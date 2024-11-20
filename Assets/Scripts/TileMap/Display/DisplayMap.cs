using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class DisplayMap : MonoBehaviour
{
    [SerializeField] public GameObject GrassTile;
    [SerializeField] public GameObject PathTile;
    [SerializeField] public GameObject BuildableTile;
    [SerializeField] public GameObject SpawnerTile;
    [SerializeField] public GameObject GoalTile;
    [SerializeField] public GameObject Tile;
    int[] MapSize = { 10, 10 };

    public Map Map { get; private set; }

    //ONLY FOR DEBUGGING: map creation is handled in the Editor now.
    public void Awake()
    {
        if (this.transform.childCount == 0) //map doesnt exist yet
        {
            CreateMapInstance();
        }
        List<Cell> cells = GetCellsFromChildren();
        Map = CreateMapFromCells(cells);
    }

    public void CreateMapInstance()
    {
        Map map = MapGenerator.GenerateMap(MapType.Hexagon, MapSize);

        InstantiateTiles(map.GetAllCells());
    }

    public void InstantiateTiles(List<Cell> mapCells)
    {
        foreach (Cell cell in mapCells)
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

    private List<Cell> GetCellsFromChildren()
    {
        DisplayCell[] displayCells = this.GetComponentsInChildren<DisplayCell>();

        List<Cell> cells = new List<Cell>();
        foreach (DisplayCell displayCell in displayCells)
        {
            cells.Add(displayCell.CellLogic);
        }
        return cells;
    }

    public abstract Map CreateMapFromCells(List<Cell> cells);

    public abstract void InstantiateTile(GameObject tile, Cell cell);

}


