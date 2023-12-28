using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingFacility : Facility, IWare
{
    public PackingFacility()
    {
        ID = FacilityID.PACKING;
    }

    public int CurrentCapacity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public int TotalCapacity { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
}
