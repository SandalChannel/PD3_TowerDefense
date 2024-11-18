using System;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic
{
    public int EnemiesToSpawn { get; } = 6;

    public Map Map { get; }

    public List<Enemy> Enemies { get; } = new List<Enemy>();
    public GameLogic(Map map)
    {
        Map = map;

        while (EnemiesToSpawn > 0)
        {
            Enemies.Add(new Enemy(PathFinder.FindPath(CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Spawner)[0], CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Goal)[0], CellGetter.GetCellsByType(Map.GetAllCells(), CellType.Road))));

            EnemiesToSpawn--;
        }
            
    }
}
