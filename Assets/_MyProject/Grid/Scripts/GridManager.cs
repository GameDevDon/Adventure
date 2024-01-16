// Script to build grid of prefabs at runtime with navigation mesh over them,
// the object containinghe grid must have a NavMeshSurface component
// with the 'Collect Objects' Property set to 'Children'

using Unity.AI.Navigation;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject gridContainerObject;
    [SerializeField] private Vector3 gridOrigin=Vector3.zero;
    [SerializeField] private int gridSizeX = 0;
    [SerializeField] private int gridSizeZ = 0;
    [SerializeField] private float gridY = 0f;
    [SerializeField] private float gridCellSize = 1f;
    [SerializeField] private GameObject defaultTilePrefab;
    [SerializeField] private GridTile_SO[] tiles;


    void Awake()
    {
        if (gridOrigin == null || gridSizeX <= 0 || gridSizeZ <= 0 || gridCellSize <= 0f || defaultTilePrefab == null || tiles.Length == 0)
        {
            Debug.LogError("One or more properties have not been set on the GridManager script");
        }
        else
        {
            if (gridContainerObject == null)
            {
                gridContainerObject = new GameObject("Grid");
                gridContainerObject.transform.position = gridOrigin;
            }
        }
        // Loop through the Z & X axis
        for (int gridX = 0; gridX < gridSizeX; gridX++)
        {
            for (int gridZ = 0; gridZ < gridSizeZ; gridZ++)
            {
                // Loop through the array of set tiles
                for (int i = 0; i < tiles.Length; i++)
                {
                    // if a tile has been set for this location use it
                    if (tiles[i].tileXPosition == gridX && tiles[i].tileZPosition == gridZ)
                    {
                        GameObject tile= Instantiate(tiles[i].tilePrefab, gridContainerObject.transform);
                        tile.transform.position = new Vector3(gridX * gridCellSize, tiles[i].YOffset, gridZ * gridCellSize);
                    }
                    // otherwise use the default tile
                    else
                    {
                        GameObject tile = Instantiate(defaultTilePrefab, gridContainerObject.transform);
                        tile.transform.position = new Vector3(gridX * gridCellSize, gridY, gridZ * gridCellSize);
                    }   
                }
            }
        }
        if (gridContainerObject.TryGetComponent<NavMeshSurface>(out NavMeshSurface surface))
        {
            surface.BuildNavMesh();
        }
        else
        {
            Debug.LogError("No NavMeshSurface component on " + gridContainerObject.name);
        }
    }
}
