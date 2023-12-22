using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilitySpawner
{
    public List<IFacility> Facilities { get; set; }

    public FacilitySpawner()
    {
        InitialiseFacilities();
    }

    private void InitialiseFacilities()
    {
        Facilities = new()
        {
            new PackingHouse(),
            new StorageHouse()
        };
    }
}
