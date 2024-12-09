using UnityEngine;
using UnityEngine.Rendering;
using Logic.TileMap;

namespace Display.TileMap
{
    public class DisplayCell : MonoBehaviour
    {
        [SerializeField]
        private CellType _cellType;

        public CellType CellType => _cellType;

        [SerializeField]
        public Vector2Int Coordinate;

        public Coordinates MapCoordinate => new Coordinates(Coordinate.x, Coordinate.y);

        public Cell CellLogic => new Cell(CellType, MapCoordinate.X, MapCoordinate.Y);
    }
}
