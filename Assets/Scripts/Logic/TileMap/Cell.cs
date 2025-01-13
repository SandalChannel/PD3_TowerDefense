using Logic.Interfaces;

namespace Logic.TileMap
{
    public class Cell// : IHasCoordinate
    {
        public CellType CellType { get; set; }
        public Coordinates Coordinates { get; set; }

        public Cell(CellType cellType, int xPos, int yPos)
        {
            CellType = cellType;
            Coordinates = new Coordinates(xPos, yPos);
        }



        public override string ToString()
        {
            return $"Type: {CellType}, at: {Coordinates}";
        }



    }
}
