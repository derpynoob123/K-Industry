using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private Sprite tilePrefab;
    [SerializeField]
    private Grid grid;

    private void Start()
    {
        var worldPosition = grid.GetCellCenterWorld(new Vector3Int(1, 0, 0));
        Instantiate(tilePrefab, worldPosition, Quaternion.identity);
    }
}
