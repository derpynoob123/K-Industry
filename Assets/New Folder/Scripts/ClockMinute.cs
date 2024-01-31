using System;
using UnityEngine;

[Serializable]
public class ClockMinute : IClockTime
{
    [SerializeField]
    [Range(0, minuteTensLimit)]
    private int tens;
    public int Tens
    {
        get => tens;
        set
        {
            if (value > minuteTensLimit)
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
    [Range(0, minuteOnesLimit)]
    private int ones;
    public int Ones
    {
        get => ones;
        set
        {
            if (value > minuteOnesLimit)
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

    private const int minuteTensLimit = 6;
    private const int minuteOnesLimit = 9;

    public static bool IsSameMinute(ClockMinute minuteA, ClockMinute minuteB)
    {
        if (minuteA.Tens == minuteB.Tens && minuteA.Ones == minuteB.Ones)
        {
            return true;
        }
        return false;
    }
}
