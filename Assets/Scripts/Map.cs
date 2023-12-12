using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    private Grid grid;

    private void Start()
    {
        var worldPosition = grid.GetCellCenterWorld(new Vector3Int(0, 0));
    }
}
