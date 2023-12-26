using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FacilitySpawner
{
    private readonly ObjectPool<PackingHouse> pool;
    private readonly int spawnCount;

    public FacilitySpawner(int spawnCount)
    {
        this.spawnCount = spawnCount;
        pool = new(() => { return new(); }, 
        facility => { facility.IsActive = true; },
        facility => { facility.IsActive = false; },
        facility => { facility = null; },
        false, spawnCount, spawnCount * 10);
    }
}
