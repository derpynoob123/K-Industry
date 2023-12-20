using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FacilitySelectionDropdown : SelectionDropdown<IFacility>
{
    [SerializeField]
    private FacilityBuilderBehaviour facilityBuilder;
    [SerializeField]
    private FacilityManagerBehaviour facilityManager;

    protected override void AddOptionSelectedObservers()
    {

    }

    protected override void SetOptions()
    {
        options = facilityManager.GetFacilities();
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
