public struct HexCoordinates : ICoordinate
{
    public HexCoordinates(int q, int r, int s)
    {
        Q = q;
        R = r;
        S = s;
    }

    public int Q { get; }
    public int R { get; }
    public int S { get; }

    public override string ToString() => $"({Q}, {R}, {S})";
}
