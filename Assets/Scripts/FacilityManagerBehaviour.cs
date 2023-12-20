using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityManagerBehaviour : MonoBehaviour
{
    private readonly FacilityManager facilityManager = new();

    public List<IFacility> GetFacilities()
    {
        return facilityManager.Facilities;
    }
}
