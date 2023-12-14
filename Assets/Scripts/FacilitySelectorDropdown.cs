using System.Collections.Generic;
using UnityEngine;

public class FacilitySelectorDropdown : SelectorDropdown<IFacility>
{
    override protected void Awake()
    {
        options.Add(new StorageHouse());
        options.Add(new PackingHouse());

    }
}
