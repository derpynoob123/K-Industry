using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FacilitySelectionDropdown : SelectionDropdown<IFacility>
{
    [SerializeField]
    private FacilityManager facilityManager;

    protected override void AddOptionSelectedObservers()
    {

    }

    protected override void AddDropdownOptions()
    {
        options = facilityManager.Facilities;
    }

    protected override void SetOptions()
    {
        for (int optionIndex = 0; optionIndex < options.Count; optionIndex++)
        {
            string optionText = options[optionIndex].Type.ToString();
            var option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
        }
    }
}
