using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using System.IO; //filestream
using System.Runtime.Serialization.Formatters.Binary; //no effing idea
using Newtonsoft.Json;
using helperTools; 

public class Player : MonoBehaviour {

    public int PowerLevel;
    public List<Workout> Workouts;
    public GenericDelegate<int> PowerLevelChanged; 
   
    public void Awake()
    {
        if (Workouts == null)
            Workouts = new List<Workout>();

    }

    public void AddWorkout(Workout work)
    {
        Workouts.Add(work);
    }

       
    public void addPowerLevel(int powerAddition)
    {
        PowerLevel += powerAddition;
        if (PowerLevelChanged != null)
            PowerLevelChanged(PowerLevel);
    }

    public void printPowerLevel()
    {
        Debug.Log("POWER LEVEL: " + PowerLevel);
    }

    public void clearWorkout()
    {
        Workouts = new List<Workout>();
    }
}
[Serializable]
public class PlayerData
{
    public int powerLevel;
    public List<Workout> workouts;
}

