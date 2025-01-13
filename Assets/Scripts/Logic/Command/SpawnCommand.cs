using Command;
using System;

namespace Logic.Command
{
    public class SpawnCommand<T> : ICommand where T : LogicBase
    {
        private readonly T _model;
        private event Action<T> ObjectSpawnedAction;

        public float Timestamp { get; set; }

        public SpawnCommand(T model, Action<T> objectSpawnedAction, float time)
        {
            _model = model;
            ObjectSpawnedAction = objectSpawnedAction;
            Timestamp = time;
        }

        public void Execute()
        {
            ObjectSpawnedAction?.Invoke(_model);
        }
    }
}
