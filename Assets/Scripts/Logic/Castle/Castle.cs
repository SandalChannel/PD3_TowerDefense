using Logic.Enemies;
using Logic.TileMap;
using System.Collections.Generic;
using Logic.Game;
using Logic.Interfaces;
using Logic.Command;
using Command;

namespace Logic.Castles
{
    public class Castle : LogicBase, IHasCoordinate, IHasHealth
    {
        private Coordinates _position;
        public Coordinates Position { get => _position; set { _position = value; } }

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

                if (_health <= 0)
                {
                    //OnObjectDestroyed();
                    DestroyCommand<Castle> destroyCommand = new(this, GameLogic.GameTime);
                    CommandHistory.ExecuteCommand(destroyCommand);
                    return;
                }
            }
        }

        public Castle(Coordinates position, float health)
        {
            Position = position;
            Health = health;
        }
    }
}
