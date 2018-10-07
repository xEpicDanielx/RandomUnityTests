using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerLevelManager : MonoBehaviour {
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
        return 1000;  
    }
   
}
