using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingHouse : IFacility
{
    public FacilityType Type { get; set; }
    public int Price { get; set; }

    public PackingHouse()
    {
        Type = FacilityType.PACKINGHOUSE;
    }
}
