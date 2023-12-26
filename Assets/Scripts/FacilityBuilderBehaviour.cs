using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BuildableFacility
{
    [SerializeField]
    private GameObject facilityPrefab;
}

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
        selectedFacility.ToString();
        FacilitySelected.Invoke();
    }

    public void EndBuildSelection()
    {
        selectedFacility = null;
        SelectionEnded.Invoke();
    }

    public List<IFacility> GetFacilities()
    {
        return facilityBuilder.BuildableFacilities;
    }
}
