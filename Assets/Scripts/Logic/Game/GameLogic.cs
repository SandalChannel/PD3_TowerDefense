using System;
using System.Collections.Generic;
using Logic.Enemies;
using Logic.Towers;
using Logic.TileMap;
using Logic.Libraries;
using Logic.Command;
using Command;
using Logic.Castles;

namespace Logic.Game
{
    public class GameLogic
    {
        public event Action<LogicBase> ObjectSpawned;
        public int EnemiesToSpawn { get; } = 6;
        public float SpawnDelay { get; } = 2f;

        public static float GameTime { get; set; } = 0f;

        public static bool IsReplaying = false;

        public Map Map { get; }

        public GameLogic(Map map)
        {
            Map = map;

            GameTime = 0f;
        }

        public void SpawnCastles()
        {
            foreach (Cell goal in CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Goal))
            {
                Castle activeCastle = new(goal.Coordinates, 100f);
                
                SpawnCommand<Castle> spawnCommand = new(activeCastle, ObjectSpawned, GameTime);
                CommandHistory.ExecuteCommand(spawnCommand);
            }
        }

        public void SpawnEnemyAtSpawner()
        {
            List<Cell> starts = CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Spawner);
            List<Cell> ends = CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Goal);
            List<Cell> allRoads = CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Road);
            Enemy activeEnemy = new(PathFinder.FindPath(starts[0], ends[0], allRoads));
            
            //ObjectSpawned?.Invoke(activeEnemy);
            SpawnCommand<Enemy> spawnCommand = new(activeEnemy, ObjectSpawned, GameTime);
            CommandHistory.ExecuteCommand(spawnCommand);

            MoveCommand<Enemy> moveCommand = new(activeEnemy, starts[0].Coordinates, GameTime);
            CommandHistory.ExecuteCommand(moveCommand);
        }

        public void SpawnOrRemoveTower(Coordinates pos)
        {
            bool canSpawn = true;
            for (int i = 0; i < LogicBase.GetAllInstancesOfType<Tower>().Count; i++)
            {
                if (LogicBase.GetAllInstancesOfType<Tower>()[i].Position == pos) //remove tower if the position already contains one
                {
                    canSpawn = false;
                    DestroyCommand<Tower> destroyCommand = new(LogicBase.GetAllInstancesOfType<Tower>()[i], GameTime);
                    CommandHistory.ExecuteCommand(destroyCommand);
                }
            }
            if (canSpawn) //else add a tower
            {
                Tower activeTower = new(pos);

                SpawnCommand<Tower> spawnCommand = new(activeTower, ObjectSpawned, GameTime);
                CommandHistory.ExecuteCommand(spawnCommand);
            }
        }

        public void ReplayCommandAtCurrentTime()
        {

            while (CommandHistory.ReplayStack[0].Timestamp <= GameTime)
            {
                CommandHistory.ReplayCommand(CommandHistory.ReplayStack[0]);
                CommandHistory.ReplayStack.RemoveAt(0);
            }
        }
    }
}
