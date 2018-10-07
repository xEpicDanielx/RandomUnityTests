using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO; //filestream
using System.Runtime.Serialization.Formatters.Binary; //no effing idea

[Serializable]
public class Workout{
    public DateTime timeOfWorkout;
    public Dictionary<string,Exercise> exercises; 
	// Use this for initialization
    
    public void PrintExercises()
    {
        foreach (KeyValuePair<string, Exercise> kvp in exercises)
        {
            Debug.Log("NAME: " + kvp.Key);
            Debug.Log("Sets: " + kvp.Value.sets);
            Debug.Log("Reps: " + kvp.Value.reps);
            Debug.Log("Weight: " + kvp.Value.weight);
            Debug.Log("--------------------------------");
        }
    }
}
