using UnityEngine;
using Display.TileMap;
using Display.Enemies;
using Display.Towers;
using Logic.Game;
using Logic.Enemies;
using Logic.Towers;
using Display.Castles;
using Logic.Castles;

namespace Display.Game
{
    public class DisplayGame : MonoBehaviour
    {
        [SerializeField] private GameObject EnemyPrefab;
        [SerializeField] private GameObject TowerPrefab;
        [SerializeField] private GameObject CastlePrefab;

        private DisplayMap mapDisplay;

        private GameLogic _game;

        private float SpawnCountdown = 1f;
        private int EnemySpawnCount = 6;

        //all spawned objects will react to this
        protected void HandleObjectSpawned(LogicBase model)
        {
            if (model.GetType() == typeof(Enemy))
            {
                AddEnemyPresenterInstance((Enemy)model);
            }
            if (model.GetType() == typeof(Tower))
            {
                AddTowerPresenterInstance((Tower)model);
            }
            if (model.GetType() == typeof(Castle))
            {
                AddCastlePresenterInstance((Castle)model);
            }
        }


        private void Start()
        {
            mapDisplay = FindAnyObjectByType<DisplayMap>();
            _game = new GameLogic(mapDisplay.Map);
            
            SpawnCountdown = _game.SpawnDelay;
            EnemySpawnCount = _game.EnemiesToSpawn;
            _game.ObjectSpawned += HandleObjectSpawned;


            _game.SpawnCastles();
        }

        private void Update()
        {
            GameLogic.GameTime += Time.deltaTime; //updates the internal gameTime
            
            SpawnCountdown -= Time.deltaTime;

            if (Input.GetMouseButtonDown(0) && !GameLogic.IsReplaying)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hitInfo))
                {
                    GameObject hitObject = hitInfo.collider.gameObject;

                    hitObject.TryGetComponent<DisplayCell>(out DisplayCell hitCell);
                    if (hitCell.CellType == CellType.Buildable && hitCell != null)
                    {
                        _game.SpawnOrRemoveTower(hitCell.CellLogic.Coordinates);
                    }
                }
            }

            if (EnemySpawnCount > 0 && SpawnCountdown <= 0 && !GameLogic.IsReplaying)
            {
                _game.SpawnEnemyAtSpawner();
                EnemySpawnCount--;
                SpawnCountdown = _game.SpawnDelay;
            }

            if (GameLogic.IsReplaying)
            {
                _game.ReplayCommandAtCurrentTime();
            }

        }

        private void AddEnemyPresenterInstance(Enemy enemy)
        {
            //create towers (prefabs + linking models to presenters)
            GameObject enemyInstance = Instantiate(EnemyPrefab);
            DisplayEnemy enemyInstanceDisplay = enemyInstance.GetComponent<DisplayEnemy>();
            enemyInstanceDisplay.Logic = enemy;
        }

        private void AddTowerPresenterInstance(Tower tower)
        {
            //create enemies (prefabs + linking models to presenters)
            GameObject towerInstance = Instantiate(TowerPrefab);
            DisplayTower towerInstanceDisplay = towerInstance.GetComponent<DisplayTower>();
            towerInstanceDisplay.Logic = tower;
        }

        private void AddCastlePresenterInstance(Castle castle)
        {
            //create castles (prefabs + linking models to presenters)
            GameObject castleInstance = Instantiate(CastlePrefab);
            DisplayCastle castleInstanceDisplay = castleInstance.GetComponent<DisplayCastle>();
            castleInstanceDisplay.Logic = castle;
        }
    }
}
