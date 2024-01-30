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

    public void SendUnit(GameObject receiver)
    {
        GoodUnit unit = storageUnit.UnloadGoodUnit();
        LoadingBay.MakeTransfer(unit, receiver);
    }

    public void ReceiveUnit(GoodUnit unit)
    {
        storageUnit.LoadGoodUnit(unit);
    }
}
