using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManagerBehaviour : MonoBehaviour
{
    [SerializeField]
    private Map map;

    private BuildManager buildManager = new();
}
