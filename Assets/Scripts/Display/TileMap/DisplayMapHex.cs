using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Display.Libraries;
using Logic.TileMap;

namespace Display.TileMap
{
    public class DisplayMapHex : DisplayMap
    {
        public override void InstantiateTile(GameObject tile, Cell cell)
        {
            GameObject tileInstance = Instantiate(tile, CoordinateConverter.HexToVector(tile.transform.lossyScale, cell.Coordinates), Quaternion.identity, this.transform);

            tileInstance.GetComponent<DisplayCell>().Coordinate = new Vector2Int(cell.Coordinates.X, cell.Coordinates.Y); //sets the coordinates of the cell inside the DisplayCell component, for later reference.
        }

        public override Map CreateMapFromCells(List<Cell> cells)
        {
            Map map = new Map(MapType.Hexagon, cells);
            return map;
        }
    }
}


