using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityBuilderBehaviour : MonoBehaviour
{
    [SerializeField]
    private TileSelectorBehaviour tileSelector;

    public event Action FacilitySelected;
    public event Action SelectionEnded;

    private readonly FacilityBuilder facilityBuilder = new();
    private IFacility selectedFacility;

    public void SelectFacility(IFacility facility)
    {
        selectedFacility = facility;
        FacilitySelected.Invoke();
    }

    public void EndBuildSelection()
    {
        selectedFacility = null;
        SelectionEnded.Invoke();
    }

    public void BuildFacility()
    {
        facilityBuilder.BuildFacility(tileSelector.GetSelectedTile(), selectedFacility);
    }

    public List<IFacility> GetFacilities()
    {
        return facilityBuilder.BuildableFacilities;
    }
}
