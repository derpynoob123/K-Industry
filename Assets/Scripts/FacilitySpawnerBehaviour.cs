using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FacilitySpawnerBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject facilityPrefab;
    [SerializeField]
    private int spawnCount;
    private readonly ObjectPool<GameObject> pool;

    private readonly FacilitySpawner facilitySpawner;
}
