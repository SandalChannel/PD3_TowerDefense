using Logic.TileMap;

namespace Logic.Interfaces
{
    public interface ICanMove
    {
        Coordinates PrevPosition { get; set; }
    }
}
