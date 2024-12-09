using NUnit.Framework;
using System.Collections.Generic;
using Logic.TileMap;
using Logic.Enemies;

namespace Logic.Towers
{
    public class Tower : LogicBase
    {
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

        public List<Enemy> Enemies = new List<Enemy>();

        private float _damage = 10;

        public float DamageDelay = 0.5f;

        public Tower(Coordinates pos)
        {
            Position = pos;
        }

        public void DamageEnemies()
        {
            foreach (Enemy enemy in Enemies)
            {
                if (this.Position.IsAdjacentHex(enemy.Position))
                {
                    enemy.Health -= _damage;
                }
            }
        }
    }
}
