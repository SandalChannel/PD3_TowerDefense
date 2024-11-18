using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class PathFinder
{

    public static List<Cell> FindPath(Cell start, Cell end, List<Cell> nodes)
    {
        nodes.Add(end); //adds the end to the list of possible destination tiles
        
        List<Cell> path = new List<Cell>();

        //build the path
        path.Add(start); //begins with starting cell
        for (int i = 0; i < path.Count(); i++) //every cell to be checked, use for loop becacuse number changes during runtime
        {
            Cell nextItem = FindPathRecursive(path.Last(), end, path, nodes); //check the last added cell against all others

            if (nextItem != null)
            {
                path.Add(nextItem);
            }
        }
        return path;
    }

    private static Cell FindPathRecursive(Cell current, Cell end, List<Cell> path, List<Cell> nodes)
    {
        foreach (Cell item in nodes)
        {
            if (!path.Contains(item) && //the next cell cannot have been used before, and has to be adjacent to the current cell
               (Math.Abs((end.Coordinates.X + end.Coordinates.Y) - (item.Coordinates.X + item.Coordinates.Y))) <= Math.Abs(((end.Coordinates.X + end.Coordinates.Y) - (current.Coordinates.X + current.Coordinates.Y)))) //checks to see which is closer to the end //DIAGONALS ARE ALLOWED
            {
                return item;
            }
        }
        return default(Cell);
    }
}
