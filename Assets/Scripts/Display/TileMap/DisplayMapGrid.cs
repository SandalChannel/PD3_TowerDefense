using System.Collections.Generic;
using UnityEngine;
using Display.Libraries;
using Logic.TileMap;

namespace Display.TileMap
{
    public class DisplayMapGrid : DisplayMap
    {

        public override void InstantiateTile(GameObject tile, Cell cell)
        {
            GameObject tileInstance = Instantiate(tile, CoordinateConverter.GridToVector(tile.transform.lossyScale, cell.Coordinates), Quaternion.identity, this.transform);

            tileInstance.GetComponent<DisplayCell>().MapCoordinate = cell.Coordinates; //sets the coordinates of the cell inside the DisplayCell component, for later reference.
        }

        public override Map CreateMapFromCells(List<Cell> cells)
        {
            Map map = new(MapType.Grid, cells);
            return map;
        }
    }
}


