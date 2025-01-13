using Command;
using Logic.Command;
using Logic.Enemies;
using Logic.Game;
using StatePattern;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Enemies.States
{
    internal class WalkState : IState
    {
        private readonly Enemy _enemy;

        public WalkState(Enemy enemy)
        {
            _enemy = enemy;
        }
        
        public void OnEnter()
        {
            
        }

        public void Update()
        {
            if (_enemy.Path?.Count > 0)
            {
                _enemy.PrevPosition = _enemy.Position;
                //Position = Path[0].Coordinates;
                MoveCommand<Enemy> moveCommand = new(_enemy, _enemy.Path[0].Coordinates, GameLogic.GameTime);
                CommandHistory.ExecuteCommand(moveCommand);
                _enemy.Path.Remove(_enemy.Path[0]);
            }
            else
            {
                _enemy.StateMachine.MoveToState(_enemy.AttackState);
            }
        }

        public void OnExit()
        {
            
        }
    }
}
