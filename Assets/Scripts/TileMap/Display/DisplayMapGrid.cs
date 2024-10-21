using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DisplayMapGrid : DisplayMap
{
    //vestigial
    //public DisplayMapGrid(GameObject tile, GameObject grassTile, GameObject pathTile) : base(tile, grassTile, pathTile) { }

    private Vector3 GridToVector(Vector3 scale, GridCoordinates grid)
    {
        float x = scale.x * grid.X;
        float y = scale.y * grid.Y;
        return new Vector3(x, 0, y);
    }
    public override void InstantiateTile(GameObject tile, Cell cell)
    {
        Instantiate(tile, GridToVector(tile.transform.lossyScale, (GridCoordinates)cell.Coordinates), Quaternion.identity);
    }

    public override Map CreateMap(int[] mapSize)
    {
        return new Map(MapType.Grid ,mapSize[0], mapSize[1]);
    }
}


