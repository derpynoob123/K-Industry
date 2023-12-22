using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildButton : MonoBehaviour
{
    [SerializeField]
    private FacilityBuilderBehaviour facilityBuilder;

    private void Awake()
    {
        facilityBuilder.FacilitySelected += ShowButton;
        facilityBuilder.SelectionEnded += HideButton;
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