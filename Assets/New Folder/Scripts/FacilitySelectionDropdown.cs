using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FacilitySelectionDropdown : SelectionDropdown<FacilityID>
{
    [SerializeField]
    private TileSelectorBehaviour tileSelector;
    [SerializeField]
    private FacilityController facilityController;
    [SerializeField]
    private FacilitySelectorBehaviour facilitySelector;

    override protected void Awake()
    {
        tileSelector.AddObserverToSelectedEvent(ShowDropdown);
        tileSelector.AddObserverToDeselectedEvent(HideDropdown);
        base.Awake();
        HideDropdown();
    }

    protected override void AddOptionSelectedObservers()
    {
        OptionSelected += facilitySelector.SelectFacility;
    }

    protected override void AddDeselectedObservers()
    {
        Deselected += facilitySelector.Deselect;
    }

    protected override void SetOptions()
    {
        options = facilityController.Buildables;
    }

    protected override void AddDropdownOptions()
    {
        for (int optionIndex = 0; optionIndex < options.Count; optionIndex++)
        {
            string optionText = options[optionIndex].ToString();
            var option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
        }
    }
}
