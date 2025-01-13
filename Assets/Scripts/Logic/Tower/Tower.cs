using System.Collections.Generic;
using Logic.TileMap;
using Logic.Enemies;
using Logic.Interfaces;
using Logic.Castles;
using Logic.Command;
using Command;
using Logic.Game;

namespace Logic.Towers
{
    public class Tower : LogicBase, IHasCoordinate
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

        private readonly float _damage = 10;

        public float DamageDelay = 0.5f;

        public Tower(Coordinates pos)
        {
            Position = pos;
        }

        public void DamageEnemies()
        {
            for (int i = 0; i < GetAllInstancesOfType<Enemy>().Count; i++)
            {
                if (this.Position.IsAdjacentHex(GetAllInstancesOfType<Enemy>()[i].Position))
                {
                    //Enemy.AllInstances[i].Health -= _damage;
                    AttackCommand<Enemy> attackCommand = new AttackCommand<Enemy>(GetAllInstancesOfType<Enemy>()[i], _damage, GameLogic.GameTime);
                    CommandHistory.ExecuteCommand(attackCommand);
                }
            }
        }
    }
}
