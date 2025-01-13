using Command;
using Logic.Castles;
using Logic.Command;
using Logic.Game;
using StatePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Enemies.States
{
    internal class AttackState : IState
    {
        private readonly Enemy _enemy;
        
        public AttackState(Enemy enemy)
        {
            _enemy = enemy;
        }
        
        public void OnEnter()
        {
            
        }

        public void Update()
        {
            //TryAttack
            for (int i = 0; i < LogicBase.GetAllInstancesOfType<Castle>().Count; i++) 
            {
                if (LogicBase.GetAllInstancesOfType<Castle>()[i].Position == _enemy.Position)
                {
                    //Castle.AllInstances[i].Health -= _damage;
                    AttackCommand<Castle> attackCommand = new(LogicBase.GetAllInstancesOfType<Castle>()[i], _enemy.Damage, GameLogic.GameTime);
                    CommandHistory.ExecuteCommand(attackCommand);
                }
            }
        }

        public void OnExit()
        {
            
        }
    }
}
