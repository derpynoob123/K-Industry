using System.Collections.Generic;

public class StorageUnit
{
    private int maximumCapacity;
    public int MaximumCapacity
    {
        get
        {
            return maximumCapacity;
        }
        private set
        {
            if (value <= 0)
            {
                maximumCapacity = 1;
            }
            else
            {
                maximumCapacity = value;
            }
        }
    }

    public List<GoodUnit> GoodUnits { get; private set; }

    public StorageUnit(int maximumCapacity)
    {
        MaximumCapacity = maximumCapacity;
        GoodUnits = new();
    }

    public void LoadGoodUnit(GoodUnit unit)
    {
        if (!HasCapacity())
        {
            return;
        }

        GoodUnits.Add(unit);
    }

    public GoodUnit UnloadGoodUnit()
    {
        if (GoodUnits.Count <= 0)
        {
            return new();
        }

        int index = GoodUnits.Count - 1;
        GoodUnit unit = GoodUnits[index];
        GoodUnits.Remove(unit);
        return unit;
    }

    private bool HasCapacity()
    {
        return GoodUnits.Count < MaximumCapacity;
    }}
