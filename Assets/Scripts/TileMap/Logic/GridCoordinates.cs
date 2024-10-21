using System.Runtime.Serialization;

public struct GridCoordinates : ICoordinate
{
    public GridCoordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; }
    public int Y { get; }

    public override string ToString() => $"({X}, {Y})";
}
