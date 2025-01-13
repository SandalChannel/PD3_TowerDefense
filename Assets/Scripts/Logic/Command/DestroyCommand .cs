using Logic.TileMap;
using Command;
using System;
using Logic.Towers;

namespace Logic.Command
{
    public class DestroyCommand<T> : ICommand where T : LogicBase
    {
        private readonly T _model;

        public float Timestamp { get; set; }

        public DestroyCommand(T model, float time)
        {
            _model = model;
            Timestamp = time;
        }

        public void Execute()
        {
            _model.OnObjectDestroyed();
        }
    }
}
