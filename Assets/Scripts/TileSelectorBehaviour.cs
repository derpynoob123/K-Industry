using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSelectorBehaviour : MonoBehaviour
{
    [SerializeField]
    private MapBehaviour map;

    private TileSelector tileSelector = new();
}
