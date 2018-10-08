using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using System.IO; 

public class ExerciseTracker : MonoBehaviour {
    //Exercise Name 
    public static Dictionary<Guid, Exercise> idToExercises;

    private static string SaveFilePath = "/exercises.dat";


    public void addExercise(Exercise ex)
    {
        if (idToExercises.ContainsKey(ex.id))
        {
            Debug.Log("ATTEMPTED TO ADD EXISTING EXERCISE TO TRACKER");
            return;
        }
        idToExercises.Add(ex.id, ex);
        Save(); 
    }

    public Exercise highestScore(string type)
    {
        int highestValue =0;
        Exercise bestExercise = null;

        foreach (Exercise exercise in idToExercises.Values)
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
        foreach (KeyValuePair<Guid, Exercise> kvp in idToExercises)
        {
            Exercise exercise = kvp.Value;
            Debug.Log(exercise);
        }
    }

    #region Save Data
    public void Awake()
    {
        Load();

        if (idToExercises == null)
            idToExercises = new Dictionary<Guid, Exercise>();

    }

    public void Save()
    {
        try
        {

            var dataJson = JsonConvert.SerializeObject(idToExercises);

            File.WriteAllText(Application.persistentDataPath + SaveFilePath, dataJson);
            Debug.Log(dataJson);
        }
        catch(Exception e)
        {
            Debug.Log(e); 
        }


    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + SaveFilePath))
        {
            try
            {
                string fileJson = File.ReadAllText(Application.persistentDataPath + SaveFilePath);
                Dictionary<Guid, Exercise> data = JsonConvert.DeserializeObject<Dictionary<Guid,Exercise>>(fileJson);
                if (data != null)
                {
                    idToExercises = data; 
                }
                else
                    Debug.Log("No Exercises to load");
            }
            catch(Exception e)
            {
                Debug.Log(e); 
            }
        }
    }
    #endregion
}
