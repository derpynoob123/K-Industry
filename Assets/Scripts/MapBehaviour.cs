using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private Grid grid;

    private Map map;

    private void Awake()
    {
        map = new(8, 8);
    }

    private void Start()
    {
        map.InitialiseGrid();
    }
}
