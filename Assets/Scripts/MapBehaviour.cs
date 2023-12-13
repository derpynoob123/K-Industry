using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject tilePrefab;
    [SerializeField]
    private GameObject tilesContainer;
    [SerializeField]
    private Grid grid;

    private Map map = new();

    private void Start()
    {

    }
}
