using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VehicleDropdown : SelectionDropdown<VehicleController>
{
    [SerializeField]
    private VehicleFleet vehicleFleet;
    [SerializeField]
    private VehicleSelector vehicleSelector;

    protected override void AddDeselectedObservers()
    {
        Deselected += vehicleSelector.Deselect;
    }

    protected override void AddDropdownOptions()
    {
        for (int optionIndex = 0; optionIndex < options.Count; optionIndex++)
        {
            string id = options[optionIndex].GetFirstGUIDDigits();
            string optionText = $"Vehicle {id}";
            var option = new TMP_Dropdown.OptionData(optionText);
            dropdown.options.Add(option);
        }
    }

    protected override void AddOptionSelectedObservers()
    {
        OptionSelected += vehicleSelector.SelectVehicle;
    }

    protected override void SetOptions()
    {
        options = vehicleFleet.GetFleet();
    }
}
