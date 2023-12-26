using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FacilitySpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private MapBehaviour map;
    [SerializeField]
    private List<GameObject> spawns;

    private readonly Spawner<GameObject> facilitySpawner;
}
