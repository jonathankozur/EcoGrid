using System;
using System.Collections.Generic;
using System.Linq;

public struct GridCoordinate : IEquatable<GridCoordinate>
{
    public int X { get; }
    public int Y { get; }

    public GridCoordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object obj)
    {
        if (obj is GridCoordinate other)
        {
            return X == other.X && Y == other.Y;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public bool Equals(GridCoordinate other)
    {
        return X == other.X && Y == other.Y;
    }

    public int DistanceTo(GridCoordinate other)
    {
        return Math.Max(Math.Abs(X - other.X), Math.Abs(Y - other.Y));
    }
}