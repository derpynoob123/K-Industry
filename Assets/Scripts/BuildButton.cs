using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
    [SerializeField]
    private FacilitySelectorBehaviour facilityBuilder;

    private void Awake()
    {
        facilityBuilder.AddObserverToSelectedEvent(ShowButton);
        facilityBuilder.AddObserverToDeselectedEvent(HideButton);
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
