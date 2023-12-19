using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityManager : MonoBehaviour
{
    public List<IFacility> Facilities { get; set; }

    private void Awake()
    {
        Facilities = new()
        {
            new PackingHouse(),
            new StorageHouse()
        };
    }
}
