using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodUnit
{
    private int lifeTimeInHours;
    public int LifeTimeInHours
    {
        get
        {
            return lifeTimeInHours;
        }
        set
        {
            if (value < lifeTimeInHours)
            {
                lifeTimeInHours = 0;
            }
            else
            {
                lifeTimeInHours = value;
            }
        }
    }
}
