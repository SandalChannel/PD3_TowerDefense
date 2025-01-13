using System.Collections.Generic;
using Logic.TileMap;

namespace Logic.Libraries
{
    public static class MapGenerator
    {
        public static Map GenerateMap(MapType mapType, int[] mapSize)
        {
            //creates new map of correct type
            Map map = new(mapType, mapSize[0], mapSize[1]);

            //actually sets the tile type
            map = SetMapCellTypes(map);

            return map;
        }

        private static Map SetMapCellTypes(Map map)
        {
            List<Coordinates> PathCoords = new()
        {
            new(1, 1),
            new(1, 2),
            new(1, 3),
            new(1, 4),
            new(1, 5),
            new(1, 6),
            new(1, 7),
            new(1, 8),
            new(2, 8),
            new(3, 8),
            new(3, 7),
            new(3, 6),
            new(3, 5),
            new(3, 4),
            new(3, 3),
            new(3, 2),
            new(3, 1),
            new(4, 1),
            new(5, 1),
            new(5, 2),
            new(5, 3),
            new(5, 4),
            new(5, 5),
            new(5, 6),
            new(5, 7),
            new(5, 8),
            new(6, 8),
            new(7, 8),
            new(7, 7),
            new(7, 6),
            new(7, 5),
            new(7, 4),
            new(7, 3),
            new(7, 2),
            new(7, 1),
            new(8, 1),
        };
            List<Coordinates> SpawnerCoords = new()
        {
            new Coordinates(1, 1)
        };
            List<Coordinates> GoalCoords = new()
        {
            new Coordinates(8, 1)
        };
            List<Coordinates> BuildableCoords = new()
        {
            new Coordinates(2, 2),
            new Coordinates(4, 3),
            new Coordinates(6, 4),
            new Coordinates(8, 5)
        };


            //sets the celltype for the path and other tile types
            foreach (var coords in PathCoords)
            {
                CellTypeSetter.SetCellType(map.GetAllCells(), coords, CellType.Road);
            }
            foreach (var coords in SpawnerCoords)
            {
                CellTypeSetter.SetCellType(map.GetAllCells(), coords, CellType.Spawner);
            }
            foreach (var coords in GoalCoords)
            {
                CellTypeSetter.SetCellType(map.GetAllCells(), coords, CellType.Goal);
            }
            foreach (var coords in BuildableCoords)
            {
                CellTypeSetter.SetCellType(map.GetAllCells(), coords, CellType.Buildable);
            }

            return map;
        }
    }
}
