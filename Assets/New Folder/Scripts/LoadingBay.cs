using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBay : MonoBehaviour
{
    [Serializable]
    public class Storage
    {
        public GameObject ID;
        public StorageUnitBehaviour Unit;
    }

    [SerializeField]
    private Storage[] storageUnits;

    private static readonly Dictionary<GameObject, StorageUnitBehaviour> unitIDs = new();

    private void Awake()
    {
        InitialiseUnits();
    }

    private void InitialiseUnits()
    {
        for (int unitIndex = 0; unitIndex < storageUnits.Length; unitIndex++)
        {
            Storage storage = storageUnits[unitIndex];
            unitIDs.Add(storage.ID, storage.Unit);
        }
    }

    public static void MakeTransfer(GoodUnit unit, GameObject receiver)
    {
        StorageUnitBehaviour storageUnit = unitIDs[receiver];
        storageUnit.ReceiveUnit(unit);
    }
}
