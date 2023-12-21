using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FacilitySelectionDropdown : SelectionDropdown<IFacility>
{
    [SerializeField]
    private FacilityBuilderBehaviour facilityBuilder;
    [SerializeField]
    private FacilityManagerBehaviour facilityManager;
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
        OptionSelected += facilityBuilder.SelectFacility; 
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

    protected override void AddDeselectedObservers()
    {
        Deselected += facilityBuilder.EndBuildSelection;
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
