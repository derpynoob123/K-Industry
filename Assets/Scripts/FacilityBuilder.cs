using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityBuilder
{
    public List<IFacility> BuildableFacilities { get; set; }

    public FacilityBuilder()
    {
        InitialiseFacilities();
    }

    private void InitialiseFacilities()
    {
        BuildableFacilities = new()
        {
            new PackingHouse(),
            new StorageHouse()
        };
    }

    public void BuildFacility(Tile tile, IFacility facility)
    {
        tile.CurrentFacility = facility;
    }
}
