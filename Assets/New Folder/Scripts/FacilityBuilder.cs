using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityBuilder : MonoBehaviour
{
    public event Action Built;

    public void Build()
    {
        if (!CanBuild())
        {
            return;
        }
        Built.Invoke();
    }

    private bool CanBuild()
    {
        return true;
    }
}
