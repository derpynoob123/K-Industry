using UnityEngine;

public class FacilitySelectorDropdown : SelectorDropdown<IFacility>
{


    protected override void Awake()
    {
        dropdown.ClearOptions();
    }

    protected override void InitialiseOptions(IFacility[] options)
    {
        throw new System.NotImplementedException();
    }
}
