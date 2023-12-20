using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FacilitySelectionDropdown : SelectionDropdown<IFacility>
{
    [SerializeField]
    private FacilitySelectorBehaviour facilitySelector;
    [SerializeField]
    private FacilityManager facilityManager;

    protected override void AddOptionSelectedObservers()
    {

    }

    protected override void SetOptions()
    {
        options = facilityManager.Facilities;
    }

    protected override void AddDropdownOptions()
    {
        for (int optionIndex = 0; optionIndex < options.Count; optionIndex++)
        {
            string optionText = options[optionIndex].Type.ToString();
            var option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
        }
    }
}
