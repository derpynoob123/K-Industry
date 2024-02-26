using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderGenerationScript : MonoBehaviour
{
    [SerializeField]
    // Array to store the random values
    public float[,] locOrder = new float[3, 0];
    public float[] orderTiming;

    // Timer variables
    public float timeRemaining;
    public float startTime = 10;
    public bool timerIsRunning = false;
    public float timeToDeliver;

    // Order variables
    public float banana;
    public float money;
    public float timeValue;

    void Start()
    {
        // Start the timer
        timeRemaining = startTime;
        timerIsRunning = true; 
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                timeToDeliver -= Time.deltaTime;
            }
            else
            {
                // Generate random values
                banana = Random.Range(0f, 10f);
                money = Random.Range(0f, 1000f);
                timeValue = Random.Range(0f, 10000f);

                // Add the random values to the array
                float[,] newValues = new float[locOrder.GetLength(0), locOrder.GetLength(1) + 1];
                for (int i = 0; i < locOrder.GetLength(0); i++)
                {
                    for (int j = 0; j < locOrder.GetLength(1); j++)
                    {
                        newValues[i, j] = locOrder[i, j];
                    }
                }
                newValues[0, newValues.GetLength(1) - 1] = banana;
                newValues[1, newValues.GetLength(1) - 1] = money;
                newValues[2, newValues.GetLength(1) - 1] = timeValue;
                locOrder = newValues;

                timeToDeliver = timeValue;

                // Reset the timer
                timeRemaining = startTime;
            }
        }

        for (int i = 0; i < orderTiming.Length; i++)
        {
            timeValue = orderTiming[i];
            orderTiming[i] -= Time.deltaTime * 60;

            if (timeValue <= 0)
            {
                
            }
        }
    }
}