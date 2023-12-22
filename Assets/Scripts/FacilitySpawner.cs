using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class FacilitySpawner
{
    private readonly IFacility facility;
    private readonly ObjectPool<IFacility> pool;
    private readonly int spawnCount;

    public FacilitySpawner(IFacility facility, int spawnCount)
    {
        this.facility = facility;
        this.spawnCount = spawnCount;
    }
}
