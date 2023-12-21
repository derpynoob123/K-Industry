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

    public void SelectFacility(IFacility facility)
    {
        confirmBuildButton.SetActive(true);
    }

    public void EndBuildSelection()
    {
        confirmBuildButton.SetActive(false);
    }
}
