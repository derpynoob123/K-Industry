using System;
using UnityEngine;

public class DayClock : MonoBehaviour
{
    [Serializable]
    public class ClockTime
    {
        private readonly int tensLimit;
        private readonly int onesLimit;

        private int tens;
        public int Tens
        {
            get => tens;
            set
            {
                if (value > tensLimit)
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

        private int ones;
        public int Ones
        {
            get => ones;
            set
            {
                if (value > onesLimit)
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

        public ClockTime(int tensLimit, int onesLimit)
        {
            this.tensLimit = tensLimit;
            this.onesLimit = onesLimit;
        }
    }

    [SerializeField]
    private GameManagerScript time;

    [SerializeField]
    private ClockTime hoursOfDay = new(hourTensLimit, hourOnesLimit);

    [SerializeField]
    private ClockTime minutesOfDay = new(minuteTensLimit, minuteOnesLimit);

    public event Action MinuteChanged;
    public event Action HourChanged;

    private const string o = "0";

    private const int hourTensLimit = 2;
    private const int hourOnesLimit = 9;

    private const int minuteTensLimit = 6;
    private const int minuteOnesLimit = 9;

    private const int lengthLimit = 2;

    private void Update()
    {
        string hours = time.hoursTime.ToString();
        if (hours.Length != lengthLimit)
        {
            hours = $"{o}{hours}";
        }
        string hourTens = hours[..1];
        hoursOfDay.Tens = int.Parse(hourTens);
        string hourOnes = hours.Substring(1, 1);
        hoursOfDay.Ones = int.Parse(hourOnes);

        int minutesInInt = Mathf.FloorToInt(time.minutesTime);
        string minutes = minutesInInt.ToString();
        if (minutes.Length != lengthLimit)
        {
            minutes = $"{o}{minutes}";
        }
        string minuteTens = minutes[..1];
        minutesOfDay.Ones = int.Parse(minuteTens);
        string minuteOnes = minutes.Substring(1, 1);
        minutesOfDay.Tens = int.Parse(minuteOnes);
    }

    public bool IsSameTimeOfDay(ClockTime hours, ClockTime minutes)
    {
        if (IsSameHour(hours) && IsSameMinute(minutes))
        {
            return true;
        }
        return false;
    }

    public bool IsSameHour(ClockTime hours)
    {
        if (hours.Tens == hoursOfDay.Tens && hours.Ones == hoursOfDay.Ones)
        {
            return true;
        }
        return false;
    }

    public bool IsSameMinute(ClockTime minutes)
    {
        if (minutes.Tens == minutesOfDay.Tens && minutes.Ones == minutesOfDay.Ones)
        {
            return true;
        }
        return false;
    }
}
