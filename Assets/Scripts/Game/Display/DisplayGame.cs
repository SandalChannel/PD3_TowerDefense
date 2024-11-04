using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayGame : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;

    private GameLogic _game = new GameLogic();

    private List<DisplayEnemy> _enemies = new List<DisplayEnemy>();


    void Start()
    {
        int executionCount = _game.EnemiesToSpawn;
        while (executionCount > 0)
        {
            DisplayEnemy enemySpawnerInstance = this.AddComponent<DisplayEnemy>();
            enemySpawnerInstance.EnemyPrefab = this.EnemyPrefab;
            _enemies.Add(enemySpawnerInstance);
            executionCount--;
        }
    }

    void Update()
    {
        
    }
}
