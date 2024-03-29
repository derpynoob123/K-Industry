﻿using System;

[Serializable]
public class TimeInstance
{
    public ClockHour Hour = new();
    public ClockMinute Minute = new();

    public static bool IsSameTime(TimeInstance timeA, TimeInstance timeB)
    {
        bool areHoursSame = ClockHour.IsSameHour(timeA.Hour, timeB.Hour);
        bool areMinutesSame = ClockMinute.IsSameMinute(timeA.Minute, timeB.Minute);
        if (areHoursSame && areMinutesSame)
        {
            return true;
        }
        return false;
    }
}
