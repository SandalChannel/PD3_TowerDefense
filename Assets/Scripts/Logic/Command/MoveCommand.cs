using Logic.TileMap;
using Command;
using System;

namespace Logic.Command
{
    public class MoveCommand<T> : ICommand where T : Interfaces.IHasCoordinate, Interfaces.ICanMove
    {
        private readonly T _model;
        private readonly Coordinates _destination;

        public float Timestamp { get; set; }

        public MoveCommand(T model, Coordinates destination, float time)
        {
            _model = model;
            _destination = destination;
            Timestamp = time;
        }

        public void Execute()
        {
            _model.PrevPosition = _model.Position;
            _model.Position = _destination;
        }

    }
}
