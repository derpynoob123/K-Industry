using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageHouse : IFacility
{
    public FacilityType Type { get; set; }
    public int Price { get; set; }
}