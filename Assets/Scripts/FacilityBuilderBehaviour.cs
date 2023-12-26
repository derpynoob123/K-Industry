using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityBuilderBehaviour : MonoBehaviour
{
    [SerializeField]
    private TileSelectorBehaviour tileSelector;
    [SerializeField]
    private List<GameObject> facilityPrefabs;

    private readonly FacilityBuilder facilityBuilder = new();

    private void Awake()
    {
        InitialiseFacilities();
    }

    private void InitialiseFacilities()
    {
        for (int facilityIndex = 0; facilityIndex < facilityPrefabs.Count; facilityIndex++)
        {

        }
    }

    public void SelectFacility(Facility facility)
    {
        facilityBuilder.SelectFacility(facility);
    }

    public void EndBuildSelection()
    {
        facilityBuilder.Deselect();
    }

    public List<Facility> GetFacilities()
    {
        return facilityBuilder.BuildableFacilities;
    }

    public void AddObserverToSelectedEvent(Action observer)
    {
        facilityBuilder.Selected += observer;
    }

    public void AddObserverToDeselectedEvent(Action observer)
    {
        facilityBuilder.Deselected += observer;
    }
}
