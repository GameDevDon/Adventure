using UnityEngine;
[CreateAssetMenu(fileName = "NewTile", menuName = "GridManager/Tile")]
public class GridTile_SO : ScriptableObject
{
    public int tileXPosition;
    public int tileZPosition;
    public float YOffset = 0f;
    public GameObject tilePrefab;
}
