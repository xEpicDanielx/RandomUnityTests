using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExerciseTracker : MonoBehaviour {
    //Exercise Name 
    public static Dictionary<Guid, Exercise> idToExercises;

    private static string SaveFilePath = "/exercises.dat";


    public void Awake()
    {
        Load();

        if (Workouts == null)
            Workouts = new List<Workout>();

        //printWorkouts(); 
    }

    public void Save()
    {
        FileStream file = null;
        try
        {
            printWorkouts();
            PlayerData data = new PlayerData();
            data.powerLevel = PowerLevel;
            data.workouts = Workouts;
            var dataJson = JsonConvert.SerializeObject(data);

            File.WriteAllText(Application.persistentDataPath + SaveFilePath, dataJson);
            Debug.Log(dataJson);
        }
        finally
        {
            if (file != null)
            {
                file.Dispose();
            }
        }
        Debug.Log("Saved");

    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + SaveFilePath))
        {
            FileStream file = null;
            try
            {
                string fileJson = File.ReadAllText(Application.persistentDataPath + SaveFilePath);
                PlayerData data = JsonConvert.DeserializeObject<PlayerData>(fileJson);
                if (data != null)
                {
                    PowerLevel = data.powerLevel;
                    Workouts = data.workouts;
                }
                else
                    Debug.Log("No Data");
            }
            finally
            {
                if (file != null)
                {
                    file.Dispose();
                }
            }
        }
    }



    public void addExercise(Exercise ex)
    {
        idToExercises.Add(ex.id, ex); 
    }

    public void PrintExercises()
    {
        foreach (KeyValuePair<Guid, Exercise> kvp in idToExercises)
        {
            Exercise exercise = kvp.Value;
            Debug.Log(exercise);
        }
    }
}
