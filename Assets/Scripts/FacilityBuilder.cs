using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityBuilder
{
    public List<Facility> BuildableFacilities { get; set; }

    public FacilityBuilder()
    {
        BuildableFacilities = new();
    }
}
