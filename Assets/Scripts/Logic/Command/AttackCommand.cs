using Command;
using System;

namespace Logic.Command
{
    public class AttackCommand<T> : ICommand where T : Interfaces.IHasHealth
    {
        private readonly T _target;
        private readonly float _damage;

        public float Timestamp { get; set; }

        public AttackCommand(T target, float damage, float time)
        {
            _target = target;
            _damage = damage;
            Timestamp = time;
        }
        

        public void Execute()
        {
            _target.Health -= _damage;
        }
    }
}
