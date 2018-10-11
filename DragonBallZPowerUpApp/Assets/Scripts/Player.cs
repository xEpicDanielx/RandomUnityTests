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
   
    //public PowerLevelChanged powerLevelChangedEvent = null;

 
    public void Awake()
    {
        if (Workouts == null)
            Workouts = new List<Workout>();

        //printWorkouts(); 
    }



    public void AddWorkout(Workout work)
    {
        Workouts.Add(work);
    }

    public void printWorkouts()
    {
        int index = 1;

        if (Workouts != null)
        {
            Debug.Log("You Have :" + Workouts.Count+ " Workouts"); 
            foreach (Workout wo in Workouts)
            {
               Debug.Log(index+") WORKOUT START:");
               wo.PrintExercises();
                index++;
            }
            
            Debug.Log("=================END OF WORKOUT========================");
        }
        else
            Debug.Log("NOWORKOUT");         
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

}
[Serializable]
public class PlayerData
{
    public int powerLevel;
    public List<Workout> workouts;
}

