using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityBuilderBehaviour : MonoBehaviour
{
    [SerializeField]
    private TileSelectorBehaviour tileSelector;
    [SerializeField]
    private GameObject confirmBuildButton;

    private readonly FacilityBuilder facilityBuilder = new();
    private IFacility selectedFacility;

    public void SelectFacility(IFacility facility)
    {
        selectedFacility = facility;
        confirmBuildButton.SetActive(true);
    }

    public void EndBuildSelection()
    {
        selectedFacility = null;
        confirmBuildButton.SetActive(false);
    }

    public void BuildFacility()
    {
        facilityBuilder.BuildFacility(tileSelector.GetSelectedTile(), selectedFacility);
    }
}
