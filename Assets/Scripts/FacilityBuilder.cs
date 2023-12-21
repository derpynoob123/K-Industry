using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityBuilder
{
    public void BuildFacility(Tile tile, IFacility facility)
    {
        tile.CurrentFacility = facility;
    }
}
