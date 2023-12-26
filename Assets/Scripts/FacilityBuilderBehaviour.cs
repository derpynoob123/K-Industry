using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityBuilderBehaviour : MonoBehaviour
{
    [SerializeField]
    private TileSelectorBehaviour tileSelector;
    [SerializeField]
    private List<BuildableFacility> buildableFacilities;

    public event Action FacilitySelected;
    public event Action SelectionEnded;

    private readonly FacilityBuilder facilityBuilder = new();
    private Facility selectedFacility;

    private void Awake()
    {
        
    }

    private void InitialiseFacilities()
    {
        
    }

    public void SelectFacility(Facility facility)
    {
        selectedFacility = facility;
        FacilitySelected.Invoke();
    }

    public void EndBuildSelection()
    {
        selectedFacility = null;
        SelectionEnded.Invoke();
    }

    public List<Facility> GetFacilities()
    {
        return facilityBuilder.BuildableFacilities;
    }
}
