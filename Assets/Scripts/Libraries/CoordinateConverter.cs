using UnityEngine;

public static class CoordinateConverter
{
    public static Vector3 HexToVector(Vector3 scale, Coordinates hex)
    {
        float x = scale.x * (Mathf.Sqrt(3) * hex.X + Mathf.Sqrt(3) / 2 * hex.Y);
        float y = scale.y * ((float)3 / 2 * hex.Y);
        return new Vector3(x, 0, y);
    }

    public static Vector3 GridToVector(Vector3 scale, Coordinates grid)
    {
        float x = scale.x * grid.X;
        float y = scale.y * grid.Y;
        return new Vector3(x, 0, y);
    }
}
