using Logic.TileMap;
using System.Collections.Generic;

namespace Logic.Castles
{

    public class Castle : LogicBase
    {
        public static List<Castle> AllInstances = new List<Castle>();

        public bool IsAlive { get; set; } = true;

        private Coordinates _position;
        public Coordinates Position { get => _position; private set { _position = value; } }

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

        public Castle(Coordinates position, float health)
        {
            Position = position;
            Health = health;
            AllInstances.Add(this);
        }
    }
}
