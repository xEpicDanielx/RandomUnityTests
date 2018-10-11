using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO; //filestream
using System.Runtime.Serialization.Formatters.Binary; //no effing idea

[Serializable]
public class Workout{
    public DateTime timeOfWorkout;
    public Dictionary<string,Guid> exercises; 
	// Use this for initialization
    public void PrintExercises()
    {
        foreach (KeyValuePair<string, Guid> kvp in exercises)
        {
            //Exercise exercise = ExerciseTracker.dictOfAllExercises[kvp.Value];
            Debug.Log(kvp.Key.ToString());
        }
    }
}
