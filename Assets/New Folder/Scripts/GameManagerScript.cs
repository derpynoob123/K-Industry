using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerScrip : MonoBehaviour
{
    #region Variables
    public float userName;

    public float money;
    public float moneyText;

    //Time variables
    public int minMul = 60;
    public float minutesTime;
    public int hoursTime;
    public int day;
    public int dayCount;
    public int week;
    public bool skipCheck;

    public float locOrderTimer;
    public float intOrderTimer;
    public float orderGenTime;

    //Customer variables
    public int locRep;
    public int intRep;

    public float minBanana;
    public float maxBanana;
    public float minMoney;
    public float maxMoney;
    public float minTimeD;
    public float maxTimeD;

    public float locBanana;
    public float intBanana;
    public float locMoney;
    public float intMoney;
    public float locTimeD;
    public float intTimeD;

    public float[] locOrders;
    public float[] intOrders;

    //TextUI
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI dayText;
    public TextMeshProUGUI weekText;

    public GameObject startButton;

    public string sceneName = "MainGameplayScene";
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        minutesTime = 0;
        hoursTime = 0;
        day = 0;
        dayCount = 0;
        week = 0;

        skipCheck = false;

        locRep = 50;
        intRep = 50;

        orderGenTime = 10f;

        minBanana = 0;
        minMoney = 0;
        minTimeD = 0f;

        maxBanana = 50;
        maxMoney = 100;
        maxTimeD = 120f;

        locOrders = new float[3] { Random.Range(minBanana, maxBanana), Random.Range(minMoney, maxMoney), Random.Range(minTimeD, maxTimeD) };
    }

    // Update is called once per frame
    void Update()
    {
        #region In-game time counting
        //Timer counting
        minutesTime += minMul * Time.deltaTime;
        int minInt = (int)minutesTime;
        Debug.Log(minutesTime);

        if (minutesTime >= 60)
        {
            minutesTime = 0;
            hoursTime++;
        }

        if (hoursTime >= 24)
        {
            hoursTime = 0;
            day++;
            dayCount++;
            skipCheck = false;
        }

        if (dayCount >= 7)
        {
            week++;
            dayCount = 0;
        }
        #endregion

        #region Slow down In-game time for player change
        if ((hoursTime >= 17) && (skipCheck == false))
        {
            minMul = 1;
        }
        else
        {
            minMul = 60;
        }
        #endregion

        #region Display variables onto UI
        timeText.text = $"{hoursTime}:{minInt}";
        dayText.text = $"Day: {day}";
        weekText.text = $"Week: {week}";
        #endregion

        orderGenTime -= Time.deltaTime;

        if (locTimeD >= 0)
        {
            locTimeD -= minMul * Time.deltaTime;
        }

        //LocalMarketOrderGenerator();
    }

    //Start screen to main play screen
    public void StartGame()
    {
        SceneManager.LoadScene(sceneName);
    }

    public void SkipButton()
    {
        skipCheck = true;
    }

    //public void LocalMarketOrderGenerator()
    //{
    //    if (orderGenTime <= 0)
    //    {
    //        orderGenTime = 10f;
    //        locBanana = Random.Range(minBanana, maxBanana);
    //        locMoney = Random.Range(minMoney, maxMoney);
    //        locTimeD = Random.Range(minTimeD, maxTimeD);
    //    }

    //    if (orderGenTime <= 0)
    //    {
    //        for (int i = 0; i < locOrders.Length; i++)
    //        {
    //            locOrders[i] = Random.Range(minTimeD, maxTimeD);

    //            float locTimeD = locOrders[2];
    //            Debug.Log(locTimeD);
    //        }
    //    }
    //}
}
