using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayGame : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;

    private DisplayMap mapDisplay;

    private GameLogic _game;

    private List<DisplayEnemy> _enemies = new List<DisplayEnemy>();


    void Start()
    {
        mapDisplay = FindAnyObjectByType<DisplayMap>();
        _game = new GameLogic(mapDisplay.Map);

        //create enemies (prefabs + linking models to presenters)
        foreach(Enemy enemy in _game.Enemies)
        {
            GameObject enemyInstance = Instantiate(EnemyPrefab);
            DisplayEnemy enemyInstanceDisplay = enemyInstance.GetComponent<DisplayEnemy>();
            enemyInstanceDisplay.Logic = enemy;
            _enemies.Add(enemyInstanceDisplay);
        }
    }

    void Update()
    {
        
    }
}
