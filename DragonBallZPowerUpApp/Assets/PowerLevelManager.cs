using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLevelManager : MonoBehaviour {
    public delegate void PowerLevelIncrease(int pw);
    public PowerLevelIncrease powerLevelIncreasedEvent = null;
    /// <summary>
    /// Improving a workout
    /// bonuses such as: Consistency
    /// Random Challenges 
    /// ads 
    /// </summary>
    int PowerLevel;
    /// <summary>
    /// How much power needs to be added based upon last workout
    /// </summary>
    /// <returns></returns>
    public int powerToAdd()
    {
        if(powerLevelIncreasedEvent!=null)
            powerLevelIncreasedEvent(1000);
        return 1000;  
    }
   
}
