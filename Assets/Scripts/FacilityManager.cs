using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityManager : MonoBehaviour
{
    private List<IFacility> facilities = new();

    private void Awake()
    {
        facilities.Add(new PackingHouse());
        facilities.Add(new StorageHouse());
    }
}
