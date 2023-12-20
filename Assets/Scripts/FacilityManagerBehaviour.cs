using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityManagerBehaviour : MonoBehaviour
{
    private readonly FacilityManager facilityManager = new();

    private void Awake()
    {
        InitialiseFacilities();
    }

    private void InitialiseFacilities()
    {
        facilityManager.Facilities.Add(new PackingHouse());
        facilityManager.Facilities.Add(new StorageHouse());
    }
}
