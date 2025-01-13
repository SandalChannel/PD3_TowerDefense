using System.Collections.Generic;
using Logic.TileMap;
using Logic.Interfaces;
using Logic.Command;
using Command;
using Logic.Game;
using StatePattern;
using Logic.Enemies.States;

namespace Logic.Enemies
{
    public class Enemy : LogicBase, IHasCoordinate, IHasHealth, ICanMove
    {
        public StateMachine StateMachine { get; set; }
        public IState IdleState { get; }
        public IState WalkState { get; }
        public IState AttackState { get; }


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
        public Coordinates PrevPosition { get; set; }

        public List<Cell> Path { get; set; }

        public Enemy(List<Cell> path)
        {
            Path = path;
            Position = path[0].Coordinates;


            IdleState = new IdleState(this);
            WalkState = new WalkState(this);
            AttackState = new AttackState(this);

            StateMachine = new StateMachine(IdleState);
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

                if (_health <= 0)
                {
                    //OnObjectDestroyed();
                    DestroyCommand<Enemy> destroyCommand = new(this, GameLogic.GameTime);
                    CommandHistory.ExecuteCommand(destroyCommand);
                    return;
                }
            }
        }
        public float Damage { get; } = 10f;
    }
}
