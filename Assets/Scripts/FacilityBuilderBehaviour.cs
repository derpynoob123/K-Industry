using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacilityBuilderBehaviour : MonoBehaviour
{
    [SerializeField]
    private TileSelectorBehaviour tileSelector;

    private readonly FacilityBuilder facilityBuilder = new();
}
