using System.Collections.Generic;
using UnityEngine;

public class FacilitySpawnerBehaviour : MonoBehaviour
{
    private readonly FacilitySpawner facilitySpawner = new();

    public List<IFacility> GetFacilities()
    {
        return facilitySpawner.Facilities;
    }
}
