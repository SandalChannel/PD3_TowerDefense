using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class DisplayEnemy : MonoBehaviour
{
    [SerializeField] public GameObject EnemyPrefab;

    private Enemy _enemy;

    private float movementCountdown = 1f;

    private List<GameObject> _enemyInstances = new List<GameObject>();

    void Start()
    {
        //old system

        //find all cells by their celltype (note: this cannot get their detailed (oftype(Cell)) information, as this uses GameObjects
        //List<GameObject> cells = new List<GameObject> ();
        //cells.AddRange(GameObject.FindGameObjectsWithTag(CellType.Spawner.ToString()).ToList());
        //cells.AddRange(GameObject.FindGameObjectsWithTag(CellType.Road.ToString()).ToList());
        //cells.AddRange(GameObject.FindGameObjectsWithTag(CellType.Goal.ToString()).ToList());

        //get the cell Positions for use in PathFinder.FindPath()
        //List<System.Numerics.Vector3> cellPositions = new List<System.Numerics.Vector3>();
        //foreach (GameObject cell in cells)
        //{
        //    cellPositions.Add(new System.Numerics.Vector3(cell.transform.position.x, cell.transform.position.y, cell.transform.position.z));
        //}

        List <Cell> cells = GameObject.FindFirstObjectByType<DisplayMap>().Map.GetAllCells();

        List<Cell> path = PathFinder.FindPath(CellGetter.GetCellsByType(cells, CellType.Spawner)[0], CellGetter.GetCellsByType(cells, CellType.Goal)[0], CellGetter.GetCellsByType(cells, CellType.Road));

        _enemy = new Enemy(path);

        movementCountdown = _enemy.MovementDelay;

        _enemyInstances.Add(Instantiate(EnemyPrefab));
    }

    void Update()
    {
        movementCountdown -= Time.deltaTime;
        if (movementCountdown < 0f)
        {
            _enemy.Tick();
            movementCountdown = _enemy.MovementDelay;
        }

        foreach (var enemy in _enemyInstances)
        {
            enemy.transform.position = HexToVector(EnemyPrefab.transform.lossyScale, _enemy.CurrentCell.Coordinates);
        }
    }

    private Vector3 HexToVector(Vector3 scale, Coordinates hex)
    {
        float x = scale.x * (Mathf.Sqrt(3) * hex.X + Mathf.Sqrt(3) / 2 * hex.Y);
        float y = scale.y * ((float)3 / 2 * hex.Y);
        return new Vector3(x, 0, y);
    }

}
