using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;

public class DisplayGame : MonoBehaviour
{
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private GameObject TowerPrefab;

    private DisplayMap mapDisplay;

    private GameLogic _game;

    private List<DisplayEnemy> _enemies = new List<DisplayEnemy>();
    private List<DisplayTower> _towers = new List<DisplayTower>();

    private float SpawnCountdown = 1f;
    private int EnemySpawnCount = 6;

    //all spawned objects will react to this
    protected void HandleObjectSpawned(object sender, ObjectSpawnedOrDestroyedEventArgs<Enemy> e)
    {
        AddEnemyPresenterInstance(e.ObjectToSpawn);
    }
    protected void HandleObjectSpawned(object sender, ObjectSpawnedOrDestroyedEventArgs<Tower> e)
    {
        AddTowerPresenterInstance(e.ObjectToSpawn);

    }


    void Start()
    {
        mapDisplay = FindAnyObjectByType<DisplayMap>();
        _game = new GameLogic(mapDisplay.Map);
        SpawnCountdown = _game.SpawnDelay;
        EnemySpawnCount = _game.EnemiesToSpawn;
        _game.EnemySpawned += HandleObjectSpawned;
        _game.TowerSpawned += HandleObjectSpawned;
    }

    void Update()
    {
        SpawnCountdown -= Time.deltaTime;
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                GameObject hitObject = hitInfo.collider.gameObject;

                DisplayCell hitCell;
                hitObject.TryGetComponent<DisplayCell>(out hitCell);
                if (hitCell.CellType == CellType.Buildable)
                {
                    _game.SpawnTower(hitCell.CellLogic.Coordinates);
                }
            }
        }

        if (EnemySpawnCount > 0 && SpawnCountdown <= 0)
        {
            _game.SpawnEnemyAtSpawner();
            EnemySpawnCount--;
            SpawnCountdown = _game.SpawnDelay;
        }

        for (int i = 0; i < _enemies.Count; i++) //removes enemy when it's marked as dead //is done every frame, could be more efficient
        {
            if (_enemies[i].Logic.IsAlive == false)
            {
                _enemies.Remove(_enemies[i]);
            }
        }
    }

    private void AddEnemyPresenterInstance(Enemy enemy)
    {
        //create towers (prefabs + linking models to presenters)
        GameObject enemyInstance = Instantiate(EnemyPrefab);
        DisplayEnemy enemyInstanceDisplay = enemyInstance.GetComponent<DisplayEnemy>();
        enemyInstanceDisplay.Logic = enemy;
        _enemies.Add(enemyInstanceDisplay);
    }

    private void AddTowerPresenterInstance(Tower tower)
    {
        //create enemies (prefabs + linking models to presenters)
        GameObject towerInstance = Instantiate(TowerPrefab);
        DisplayTower towerInstanceDisplay = towerInstance.GetComponent<DisplayTower>();
        towerInstanceDisplay.Logic = tower;
        _towers.Add(towerInstanceDisplay);
    }
}
