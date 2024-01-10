using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageUnitBehaviour : MonoBehaviour
{
    [SerializeField]
    private int maximumCapacity;

    private StorageUnit storageUnit;

    private void Awake()
    {
        storageUnit = new(maximumCapacity);
    }
}
