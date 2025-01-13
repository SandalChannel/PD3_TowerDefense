using System.Collections.Generic;
using UnityEngine;
using Logic.TileMap;
using Logic.Libraries;


namespace Display.TileMap
{
    public abstract class DisplayMap : MonoBehaviour
    {
        public GameObject GrassTile;
        public GameObject PathTile;
        public GameObject BuildableTile;
        public GameObject SpawnerTile;
        public GameObject GoalTile;
        public GameObject Tile;
        private readonly int[] MapSize = { 10, 10 };

        public Map Map { get; private set; }

        private void Awake()
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

        private void InstantiateTiles(List<Cell> mapCells)
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

            List<Cell> cells = new();
            foreach (DisplayCell displayCell in displayCells)
            {
                cells.Add(displayCell.CellLogic);
            }
            return cells;
        }

        public abstract Map CreateMapFromCells(List<Cell> cells);

        public abstract void InstantiateTile(GameObject tile, Cell cell);

    }
}


