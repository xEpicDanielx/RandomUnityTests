using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;
using System.IO; 

public class ExerciseTracker : MonoBehaviour {
    //Exercise Name 
    public static Dictionary<Guid, Exercise> dictOfAllExercises;

    private static string SaveFilePath = "/exercises.dat";


    public void addExercise(Exercise ex)
    {
        if (dictOfAllExercises.ContainsKey(ex.id))
        {
            Debug.Log("ATTEMPTED TO ADD EXISTING EXERCISE TO TRACKER");
            return;
        }
        dictOfAllExercises.Add(ex.id, ex);
        //printDict();
        Save(); 
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
        Load();

        if (dictOfAllExercises == null)
            dictOfAllExercises = new Dictionary<Guid, Exercise>();

    }

    public void Save()
    {
        try
        {

            var dataJson = JsonConvert.SerializeObject(dictOfAllExercises);

            File.WriteAllText(Application.persistentDataPath + SaveFilePath, dataJson);
            //Debug.Log(dataJson);
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
                    dictOfAllExercises = data; 
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
    public void ClearData()
    {
        if (File.Exists(Application.persistentDataPath + SaveFilePath))
        {
            try
            {
                File.Delete(Application.persistentDataPath + SaveFilePath);
            }
            catch (Exception e)
            {
                Debug.Log("ERROR. Not Sure whatsup: " + e.ToString());
            }
        }

        Debug.Log("Data Cleared");

    }


























    #endregion
}
