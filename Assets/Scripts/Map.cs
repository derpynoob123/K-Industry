using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private Grid grid;

    private void Start()
    {
        int rowLength = 8;
        int columnLength = 8;
        for (int row = 0; row < rowLength; row++)
        {
            for (int column = 0; column < columnLength; column++)
            {
                var worldPosition = grid.GetCellCenterWorld(new Vector3Int(row, column));
                Instantiate(tilePrefab, worldPosition, Quaternion.identity);
            }
        }
    }
}
