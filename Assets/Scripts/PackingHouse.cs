using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackingHouse : IFacility
{
    public string Class { get; set; }
    public bool IsActive { get; set; }
    public int Price { get; set; }

    public PackingHouse()
    {
        Class = "Packing";
    }
}
