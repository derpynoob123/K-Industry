using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityManager
{
    public List<IFacility> Facilities { get; set; }

    public FacilityManager()
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
