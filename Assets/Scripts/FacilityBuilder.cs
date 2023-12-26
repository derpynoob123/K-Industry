using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class FacilityBuilder
{
    public List<Facility> BuildableFacilities { get; set; }
    public Facility SelectedFacility { get; private set; }

    public event Action Selected;
    public event Action Deselected;

    public FacilityBuilder()
    {
        BuildableFacilities = new();
    }

    public void SelectFacility(Facility facility)
    {
        SelectedFacility = facility;
        Selected.Invoke();
    }

    public void Deselect()
    {
        SelectedFacility = null;
        Deselected.Invoke();
    }
}
