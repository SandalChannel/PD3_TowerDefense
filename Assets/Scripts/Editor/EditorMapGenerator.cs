using UnityEngine;
using UnityEditor;
using Display.TileMap;

namespace Editor
{
    public class EditorMapGenerator : MonoBehaviour
    {

        [MenuItem("Editor Scripts/Map/Generate Map")]
        static void Create()
        {
            GameObject GrassTile = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/HexCells/GrassTile.prefab");
            GameObject PathTile = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/HexCells/RoadTile.prefab");
            GameObject BuildableTile = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/HexCells/BuildableTile.prefab");
            GameObject SpawnerTile = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/HexCells/SpawnerTile.prefab");
            GameObject GoalTile = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/HexCells/GoalTile.prefab");
            GameObject Tile = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/HexCells/HexTile.prefab");


            GameObject map = new("MapManager");
            DisplayMap displayMap = map.AddComponent<DisplayMapHex>();

            displayMap.GrassTile = GrassTile;
            displayMap.PathTile = PathTile;
            displayMap.BuildableTile = BuildableTile;
            displayMap.SpawnerTile = SpawnerTile;
            displayMap.GoalTile = GoalTile;
            displayMap.Tile = Tile;

            displayMap.CreateMapInstance();
        }
    }
}
