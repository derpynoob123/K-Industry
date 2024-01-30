using System;
using UnityEngine;

[Serializable]
public class ClockHour : IClockTime
{
    [SerializeField]
    [Range(0, hourTensLimit)]
    private int tens;
    public int Tens
    {
        get => tens;
        set
        {
            if (value > hourTensLimit)
            {
                Debug.LogError("Tens exceeds the limit!");
                return;
            }
            if (value < 0)
            {
                Debug.LogError("Tens less than zero!");
                return;
            }
            tens = value;
        }
    }
    [SerializeField]
    [Range(0, hourOnesLimit)]
    private int ones;
    public int Ones
    {
        get => ones;
        set
        {
            if (value > hourOnesLimit)
            {
                Debug.LogError("Ones exceeds the limit!");
                return;
            }
            if (value < 0)
            {
                Debug.LogError("Ones less than zero!");
                return;
            }
            ones = value;
        }
    }

    private const int hourTensLimit = 2;
    private const int hourOnesLimit = 9;
}
