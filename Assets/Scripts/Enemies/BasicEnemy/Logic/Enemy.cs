using System.Collections.Generic;
using System.Numerics;
using System;
public class Enemy : LogicBase
{
    public bool IsAlive { get; set; } = true;
    
    private Coordinates _position;
    public Coordinates Position
    {
        get => _position;
        set
        {
            //checks to see if anything actually changed or not (otherwise this would be called every frame)
            if (_position == value) return;

            _position = value;
            OnPropertyChanged(nameof(Position));
        }
    }

    public List<Cell> Path { get; set; }

    public Enemy(List<Cell> path)
    {
        Path = path;
        Position = path[0].Coordinates;
    }

    public float MovementDelay { get; } = 0.5f;


    private float _health = 100f;
    public float Health
    {
        get => _health;
        set
        {
            //checks to see if anything actually changed or not (otherwise this would be called every frame)
            if (_health == value) return;

            _health = value;
            OnPropertyChanged(nameof(Health));
        }
    }

    public void AdvancePath()
    {
        if (Path?.Count > 0)
        {
            Position = Path[0].Coordinates;
            Path.Remove(Path[0]);
        }
    }

    


}
