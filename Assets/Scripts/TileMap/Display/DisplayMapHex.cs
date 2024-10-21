using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DisplayMapHex : DisplayMap
{
    //vestigial
    //public DisplayMapHex(GameObject tile, GameObject grassTile, GameObject pathTile) : base(tile, grassTile, pathTile) { }

    private Vector3 HexToVector(Vector3 scale, HexCoordinates hex)
    {
        float x = scale.x * (Mathf.Sqrt(3) * hex.Q + Mathf.Sqrt(3) / 2 * hex.R);
        float y = scale.y * ((float)3/ 2 * hex.R);
        return new Vector3(x, 0, y);
    }
    public override void InstantiateTile(GameObject tile, Cell cell)
    {
        Instantiate(tile, HexToVector(tile.transform.lossyScale, (HexCoordinates)cell.Coordinates), Quaternion.identity);
    }

    public override Map CreateMap(int[] mapSize)
    {
        return new Map(MapType.Hexagon, mapSize[0], mapSize[1]);
    }
}


