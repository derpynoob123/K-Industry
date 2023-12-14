using System.Collections.Generic;
using UnityEngine;

public class FacilitySelectorDropdown : SelectionDropdown<IFacility>
{
    override protected void Awake()
    {
        options.Add(new StorageHouse());
        options.Add(new PackingHouse());

    }
}
