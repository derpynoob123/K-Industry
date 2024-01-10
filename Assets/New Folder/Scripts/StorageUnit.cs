using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    private int currentCapacity;
    public int CurrentCapacity
    {
        get
        {
            return currentCapacity;
        }

        set
        {
            if (value < 0)
            {
                currentCapacity = 0;
            }
            else if (value > MaximumCapacity)
            {
                currentCapacity = MaximumCapacity;
            }
            else
            {
                currentCapacity = value;
            }
        }
    }

    public StorageUnit(int maximumCapacity)
    {
        MaximumCapacity = maximumCapacity;
    }
}
