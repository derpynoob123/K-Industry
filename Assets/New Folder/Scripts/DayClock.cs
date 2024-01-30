using UnityEngine;

public class DayClock : MonoBehaviour
{
    [SerializeField]
    private GameManagerScript time;

    [SerializeField]
    private int[] hoursOfDay = { 0, 0 };
    public int[] HoursOfDay
    {
        get => hoursOfDay;
        private set
        {
            if (value[0] > hourLimit)
            {
                Debug.LogError("Hour exceeds the limit!");
                return;
            }
            if (value[0] < 0 || value[1] < 0)
            {
                Debug.LogError("Hour less than zero!");
                return;
            }
            hoursOfDay = value;
        }
    }

    [SerializeField]
    private int[] minutesOfDay = { 0, 0 };
    public int[] MinutesOfDay
    {
        get => minutesOfDay;
        private set
        {
            if (value[0] > minuteLimit)
            {
                Debug.LogError("Minute exceeds the limit!");
                return;
            }
            if (value[0] < 0 || value[1] < 0)
            {
                Debug.LogError("Minute less than zero!");
                return;
            }
            minutesOfDay = value;
        }
    }

    private const string o = "0";
    private const int hourLimit = 2;
    private const int minuteLimit = 6;

    private void Update()
    {
        string hours = time.hoursTime.ToString();
        if (hours.Length != HoursOfDay.Length)
        {
            hours = $"{o}{hours}";
        }
        for (int hourIndex = 0; hourIndex < HoursOfDay.Length; hourIndex++)
        {
            string hour = hours.Substring(hourIndex, 1);
            HoursOfDay[hourIndex] = int.Parse(hour);
        }

        int minutesInInt = Mathf.FloorToInt(time.minutesTime);
        string minutes = minutesInInt.ToString();
        if (minutes.Length != MinutesOfDay.Length)
        {
            minutes = $"{o}{minutes}";
        }
        for (int minuteIndex = 0; minuteIndex < MinutesOfDay.Length; minuteIndex++)
        {
            string minute = minutes.Substring(minuteIndex, 1);
            MinutesOfDay[minuteIndex] = int.Parse(minute);
        }
    }

    public bool IsSameHour(int[] hour)
    {
        if (HoursOfDay[0] == hour[0] && HoursOfDay[1] == hour[1])
        {
            return true;
        }
        return false;
    }

    public bool IsSameMinute(int[] minute)
    {
        if (MinutesOfDay[0] == minute[0] && MinutesOfDay[1] == minute[1])
        {
            return true;
        }
        return false;
    }
}
