using System;
using System.Collections.Generic;
using Logic.Enemies;
using Logic.Towers;
using Logic.TileMap;
using Logic.Libraries;
using Logic.Command;
using Logic.Castles;
using Command;

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

        public void SpawnEnemyAtSpawner()
        {
            List<Cell> starts = CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Spawner);
            List<Cell> ends = CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Goal);
            List<Cell> allRoads = CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Road);
            Enemy activeEnemy = new Enemy(PathFinder.FindPath(starts[0], ends[0], allRoads));
            
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
                    //LogicBase.GetAllInstancesOfType<Tower>()[i].OnObjectDestroyed();
                    DestroyCommand<Tower> destroyCommand = new(LogicBase.GetAllInstancesOfType<Tower>()[i], GameTime);
                    CommandHistory.ExecuteCommand(destroyCommand);
                }
            }
            if (canSpawn) //else add a tower
            {
                Tower activeTower = new Tower(pos);

                //ObjectSpawned?.Invoke(activeTower);
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
            
            
            //for (int i = 0; i < CommandHistory.ReplayStack.Count; i++)
            //{
            //    if (CommandHistory.ReplayStack[i].Timestamp >= GameTime)
            //    {
            //        CommandHistory.ReplayCommand(CommandHistory.ReplayStack[i]);
            //        CommandHistory.ReplayStack.RemoveAt(i);
            //    }
            //}
        }
    }
}
