using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DisplayMapGrid : DisplayMap
{
    
    public override void InstantiateTile(GameObject tile, Cell cell)
    {
        GameObject tileInstance = Instantiate(tile, CoordinateConverter.GridToVector(tile.transform.lossyScale, (Coordinates)cell.Coordinates), Quaternion.identity);
    }

    public override Map CreateMap(int[] mapSize)
    {
        return new Map(MapType.Grid ,mapSize[0], mapSize[1]);
    }
}


