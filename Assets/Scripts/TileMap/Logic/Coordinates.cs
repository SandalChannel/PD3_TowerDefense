using System;
using System.Runtime.Serialization;
using Unity.Mathematics;

public struct Coordinates
{
    

    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public static bool operator ==(Coordinates a, Coordinates b)
    {
        return a.X == b.X && a.Y == b.Y;
    }
    public static bool operator !=(Coordinates a, Coordinates b)
    {
        return !(a == b);
    }

    public static Coordinates operator -(Coordinates left, Coordinates right)
    {
        Coordinates result;
        result = new Coordinates(left.X - right.X, left.Y - right.Y);
        return result;
    }

    public readonly float Length()
    {
        return math.sqrt(math.pow(X, 2) + math.pow(Y, 2));
    }

    public bool IsAdjacentGrid(Cell other)
    {
        if (other == null) return false;

        if ((other.Coordinates - this).Length() <= 1)
        {
            return true;
        }

        return false;
    }

    public bool IsAdjacentHex(Coordinates other)
    {
        if (other == null) return false;

        int thisZ = -this.X - this.Y;
        int otherZ = -other.X - other.Y;
        if ((Math.Abs(other.X - this.X) + Math.Abs(other.Y - this.Y) + Math.Abs(otherZ - thisZ)) / 2 <= 1) //this is the equation for adjacency on hexagonal grids
        {
            return true;
        }

        return false;
    }

    public int X { get; }
    public int Y { get; }

    public override string ToString() => $"({X}, {Y})";
}
