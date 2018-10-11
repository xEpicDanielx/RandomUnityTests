using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using helperTools;
public class PowerLevelManager : MonoBehaviour {

    public GenericDelegate<int> PowerLevelIncrease;
    
    int PowerLevel;

    public int powerToAdd()
    {
        if(PowerLevelIncrease != null)
            PowerLevelIncrease(1000);
        return 1000;  
    }
   
}
