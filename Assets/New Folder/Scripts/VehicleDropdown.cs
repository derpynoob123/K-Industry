using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VehicleDropdown : SelectionDropdown<VehicleController>
{
    [SerializeField]
    private VehicleFleet vehicleFleet;

    protected override void AddDeselectedObservers()
    {

    }

    protected override void AddDropdownOptions()
    {
        for (int optionIndex = 0; optionIndex < options.Count; optionIndex++)
        {
            string optionText = options[optionIndex].GetGUID();
            var option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
        }
    }

    protected override void AddOptionSelectedObservers()
    {

    }

    protected override void SetOptions()
    {
        options = vehicleFleet.GetFleet();
    }
}
