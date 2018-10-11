using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using System.IO; 

public class ExerciseTracker : MonoBehaviour {
    //Exercise Name 
    public Dictionary<Guid, Exercise> dictOfAllExercises;

    public void addExercise(Exercise ex)
    {
        if (dictOfAllExercises.ContainsKey(ex.id))
        {
            Debug.Log("ATTEMPTED TO ADD EXISTING EXERCISE TO TRACKER");
            return;
        }
        dictOfAllExercises.Add(ex.id, ex);
    }

    public Exercise highestScore(string type)
    {
        int highestValue =0;
        Exercise bestExercise = null;

        foreach (Exercise exercise in dictOfAllExercises.Values)
        {
           if(exercise.type == type)
            {
                if(exercise.weight > highestValue)
                {
                    bestExercise = exercise;
                    highestValue = bestExercise.weight; 
                }
            }
        }

        return bestExercise; 
        
    }

    public void PrintExercises()
    {
        foreach (KeyValuePair<Guid, Exercise> kvp in dictOfAllExercises)
        {
            Exercise exercise = kvp.Value;
            Debug.Log(exercise);
        }
    }
    public void printDict()
    {
        Debug.Log("FROM DICTIONARY");
        foreach (Exercise exercise in dictOfAllExercises.Values)
        {
            Debug.Log(exercise);
        }

        Debug.Log("END");
    }
    #region Save Data
    public void Awake()
    {

        if (dictOfAllExercises == null)
            dictOfAllExercises = new Dictionary<Guid, Exercise>();

    }

    public Dictionary<Guid, Exercise> getAllExercises()
    {
        return dictOfAllExercises; 
    }
   


























    #endregion
}
