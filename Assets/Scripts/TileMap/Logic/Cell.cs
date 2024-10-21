public class Cell
{
    public CellType CellType { get; set; }
    public ICoordinate Coordinates { get; set; }

    public Cell(int xPos, int yPos)
    {
        Coordinates = new GridCoordinates(xPos, yPos);
    }

    public Cell(int qPos, int rPos, int sPos)
    {
        Coordinates = new HexCoordinates(qPos, rPos, sPos);
    }
}
