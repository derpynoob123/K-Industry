using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FacilitySelectionDropdown : SelectionDropdown<Facility>
{
    [SerializeField]
    private TileSelectorBehaviour tileSelector;

    override protected void Awake()
    {
        tileSelector.AddObserverToSelectedEvent(ShowDropdown);
        tileSelector.AddObserverToDeselectedEvent(HideDropdown);
        base.Awake();
        HideDropdown();
    }

    protected override void AddOptionSelectedObservers()
    {

    }

    protected override void SetOptions()
    {

    }

    protected override void AddDropdownOptions()
    {
        for (int optionIndex = 0; optionIndex < options.Count; optionIndex++)
        {
            string optionText = options[optionIndex].Class;
            var option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
        }
    }

    protected override void AddDeselectedObservers()
    {

    }

    public void ShowDropdown()
    {
        gameObject.SetActive(true);
    }

    public void HideDropdown()
    {
        ResetSelectionToDefault();
        gameObject.SetActive(false);
    }
}
