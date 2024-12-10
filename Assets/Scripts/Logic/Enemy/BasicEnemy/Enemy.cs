using System.Collections.Generic;
using System.Numerics;
using System;
using Logic.TileMap;
using Logic.Castles;

namespace Logic.Enemies
{
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
        public Coordinates PrevPosition;

        public List<Cell> Path { get; set; }

        public Enemy(List<Cell> path)
        {
            Path = path;
            Position = path[0].Coordinates;
        }

        public float ActionDelay { get; } = 0.5f;


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

        private readonly float _damage = 10f;

        public void AdvancePath()
        {
            if (Path?.Count > 0)
            {
                PrevPosition = Position;
                Position = Path[0].Coordinates;
                Path.Remove(Path[0]);
            }
        }

        public void TryAttack()
        {
            foreach (Castle castle in Castle.AllInstances)
            {
                if (castle.Position == Position)
                {
                    castle.Health -= _damage;
                }
            }

        }


    }
}
