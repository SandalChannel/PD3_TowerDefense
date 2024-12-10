using System;
using System.Collections.Generic;
using Logic.Enemies;
using Logic.Towers;
using Logic.TileMap;
using Logic.Libraries;
using Logic.Castles;

namespace Logic.Game
{
    public class GameLogic
    {
        public event EventHandler<ObjectSpawnedOrDestroyedEventArgs<Tower>> TowerSpawned;
        public event EventHandler<ObjectSpawnedOrDestroyedEventArgs<Enemy>> EnemySpawned;

        public int EnemiesToSpawn { get; } = 6;
        public float SpawnDelay { get; } = 2f;

        public Map Map { get; }


        public List<Enemy> Enemies { get; set; }
        public List<Tower> Towers { get; set; }

        public GameLogic(Map map)
        {
            Map = map;
            Enemies = new List<Enemy>();
            Towers = new List<Tower>();
        }

        public void SpawnEnemyAtSpawner()
        {
            Enemy activeEnemy = new Enemy(PathFinder.FindPath(CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Spawner)[0], CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Goal)[0], CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Road)));
            Enemies.Add(activeEnemy);
            EnemySpawned?.Invoke(this, new ObjectSpawnedOrDestroyedEventArgs<Enemy>(activeEnemy));

            foreach (Tower tower in Towers) //update the list of enemies available for the towers
            {
                tower.Enemies = Enemies;
            }
        }

        public void SpawnTower(Coordinates pos)
        {
            bool canSpawn = true;
            foreach (Tower tower in Towers)
            {
                if (tower.Position == pos)
                {
                    canSpawn = false; break;
                }
            }
            if (canSpawn)
            {
                Tower activeTower = new Tower(pos);
                Towers.Add(activeTower);
                activeTower.Enemies = Enemies;
                TowerSpawned?.Invoke(this, new ObjectSpawnedOrDestroyedEventArgs<Tower>(activeTower));
            }
        }
    }
}
