using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageHouse : IFacility
{
    public string Class { get; set; }
    public bool IsActive { get; set; }
    public int Price { get; set; }

    public StorageHouse()
    {
        Class = "Storage";
    }
}