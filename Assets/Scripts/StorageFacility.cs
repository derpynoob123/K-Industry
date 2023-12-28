using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageFacility: Facility, IWare
{
    public StorageFacility()
    {
        ID = FacilityID.STORAGE;
    }

    public int CurrentCapacity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int TotalCapacity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}