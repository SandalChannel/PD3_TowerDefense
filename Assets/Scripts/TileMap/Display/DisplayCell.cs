using UnityEngine;
using UnityEngine.Rendering;

public class DisplayCell : MonoBehaviour
{
    [SerializeField]
    private CellType _cellType;

    public CellType CellType => _cellType;

    public Cell Cell { get; private set; }

    public virtual void SetModel(Cell cell)
    {
        Cell = cell;

    }
}
