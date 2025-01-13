using StatePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Enemies.States
{
    internal class IdleState : IState
    {
        private readonly Enemy _enemy;
        
        public IdleState (Enemy enemy)
        {
            _enemy = enemy;
        }
        
        public void OnEnter()
        {
            
        }

        public void Update()
        {
            //instantly switch to the move state on start
            _enemy.StateMachine.MoveToState(_enemy.WalkState);
        }

        public void OnExit()
        {
            
        }
    }
}
