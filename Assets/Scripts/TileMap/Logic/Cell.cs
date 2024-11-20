using Unity.VisualScripting;

public class Cell
{
    public CellType CellType { get; set; }
    public Coordinates Coordinates { get; set; }

    public Cell(CellType cellType, int xPos, int yPos)
    {
        CellType = cellType;
        Coordinates = new Coordinates(xPos, yPos);
    }

    public bool IsAdjacent(Cell other)
    {
        if (other == null) return false;

        if ((this.Coordinates.X <= other.Coordinates.X + 1 && this.Coordinates.X >= other.Coordinates.X - 1) &&
            (this.Coordinates.Y <= other.Coordinates.Y + 1 && this.Coordinates.Y >= other.Coordinates.Y - 1))
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"Type: {CellType}, at: {Coordinates}";
    }



}
