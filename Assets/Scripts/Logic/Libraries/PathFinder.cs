using System.Collections.Generic;
using System.Linq;
using Logic.TileMap;

namespace Logic.Libraries
{
    public static class PathFinder
    {

        public static List<Cell> FindPath(Cell start, Cell end, List<Cell> nodes)
        {
            nodes.Add(end); //adds the end to the list of possible destination tiles

            List<Cell> path = new() { start }; //begin with starting cell

            for (int i = 0; i < path.Count(); i++) //every cell to be checked, use for loop becacuse number changes during runtime
            {
                Cell nextItem = FindPathRecursive(path.Last(), path, nodes); //check the last added cell against all others

                if (nextItem != null)
                {
                    path.Add(nextItem);
                }
            }
            return path;
        }

        private static Cell FindPathRecursive(Cell current, List<Cell> path, List<Cell> nodes)
        {
            foreach (Cell item in nodes)
            {
                if (!path.Contains(item) && (item.Coordinates.IsAdjacentHex(current.Coordinates)))//the next cell cannot have been used before, and has to be adjacent to the current cell                                                                            
                {
                    return item;
                }
            }
            return default;
        }
    }
}
