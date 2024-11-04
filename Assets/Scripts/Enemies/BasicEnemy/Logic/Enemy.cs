using System.Collections.Generic;
using System.Numerics;
using System;

internal class Enemy
{
    public Cell CurrentCell { get; set; }
    public List<Cell> Path { get; set; }
    public float MovementDelay { get; set; } = 1f;

    public Enemy(List<Cell> path)
    {
        Path = path;
        CurrentCell = path[0];
    }

    public void Tick()
    {
        if (Path?.Count > 0)
        {
            CurrentCell = Path[0];
            Path.Remove(Path[0]);
        }
    }

    
}
