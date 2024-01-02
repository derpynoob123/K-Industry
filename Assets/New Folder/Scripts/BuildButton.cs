using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
    [SerializeField]
    private FacilitySpawnerBehaviour facilitySpawner;
    [SerializeField]
    private FacilitySelectorBehaviour facilitySelector;

    private void Awake()
    {
        facilitySelector.AddObserverToSelectedEvent(ShowButton);
        facilitySelector.AddObserverToDeselectedEvent(HideButton);
        HideButton();
    }

    public void ShowButton()
    {
        gameObject.SetActive(true);
    }

    public void HideButton()
    {
        gameObject.SetActive(false);
    }
}
