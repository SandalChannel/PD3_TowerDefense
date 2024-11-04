using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class DisplayMapHex : DisplayMap
{
    //vestigial
    //public DisplayMapHex(GameObject tile, GameObject grassTile, GameObject pathTile) : base(tile, grassTile, pathTile) { }

    private Vector3 HexToVector(Vector3 scale, Coordinates hex)
    {
        float x = scale.x * (Mathf.Sqrt(3) * hex.X + Mathf.Sqrt(3) / 2 * hex.Y);
        float y = scale.y * ((float)3/ 2 * hex.Y);
        return new Vector3(x, 0, y);
    }
    public override void InstantiateTile(GameObject tile, Cell cell)
    {
        GameObject tileInstance = Instantiate(tile, HexToVector(tile.transform.lossyScale, cell.Coordinates), Quaternion.identity);
        tileInstance.tag = cell.CellType.ToString();
    }

    public override Map CreateMap(int[] mapSize)
    {
        return new Map(MapType.Hexagon, mapSize[0], mapSize[1]);
    }
}


