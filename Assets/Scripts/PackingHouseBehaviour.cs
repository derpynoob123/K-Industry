using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingHouseBehaviour : FacilityBehaviour
{
    private readonly PackingHouse packingHouse = new();

    private void Awake()
    {
        packingHouse.Class = facilityClass;
    }
}
