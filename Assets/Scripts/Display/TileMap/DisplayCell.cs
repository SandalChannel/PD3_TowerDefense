using UnityEngine;
using UnityEngine.Rendering;
using Logic.TileMap;

namespace Display.TileMap
{
    public class DisplayCell : MonoBehaviour
    {
        [SerializeField]
        private CellType _cellType;

        [SerializeField]
        private Renderer _renderer;

        Color _baseColour;

        Color _activeColour = Color.yellow;

        public CellType CellType => _cellType;

        [SerializeField]
        public Vector2Int Coordinate;

        public Coordinates MapCoordinate => new Coordinates(Coordinate.x, Coordinate.y);

        public Cell CellLogic => new Cell(CellType, MapCoordinate.X, MapCoordinate.Y);

        private void Start()
        {
            _baseColour = _renderer.material.color;
        }

        private void Update()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo) && hitInfo.collider.gameObject == this.gameObject)
            {
                _renderer.material.color = _activeColour;
            }
            else
            {
                _renderer.material.color = _baseColour;
            }
        }
    }
}
