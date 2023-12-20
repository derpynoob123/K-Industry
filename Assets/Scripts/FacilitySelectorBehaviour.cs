using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilitySelectorBehaviour : MonoBehaviour
{
    private readonly FacilitySelector facilitySelector = new();

    public void SelectFacility(IFacility facility)
    {
        facilitySelector.SelectedFacility = facility;
    }
}
