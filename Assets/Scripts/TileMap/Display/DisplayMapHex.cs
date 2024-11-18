using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DisplayMapHex : DisplayMap
{
    public override void InstantiateTile(GameObject tile, Cell cell)
    {
        GameObject tileInstance = Instantiate(tile, CoordinateConverter.HexToVector(tile.transform.lossyScale, cell.Coordinates), Quaternion.identity);
    }

    public override Map CreateMap(int[] mapSize)
    {
        return new Map(MapType.Hexagon, mapSize[0], mapSize[1]);
    }
}


