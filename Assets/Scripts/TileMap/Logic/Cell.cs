using Unity.VisualScripting;

public class Cell
{
    public CellType CellType { get; set; }
    public Coordinates Coordinates { get; set; }

    public Cell(int xPos, int yPos)
    {
        Coordinates = new Coordinates(xPos, yPos);
    }

    public override string ToString()
    {
        return $"Type: {CellType}, at: {Coordinates}";
    }

}
