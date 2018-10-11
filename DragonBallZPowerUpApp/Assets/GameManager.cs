using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.IO; //filestream
using System.Runtime.Serialization.Formatters.Binary; //no effing idea
using Newtonsoft.Json;

public class GameManager : MonoBehaviour {
    public ExerciseManager exMan;
    public WorkoutManager workMan;
    public Player player;
    public PowerLevelManager powerLevelManager;
    public ExerciseTracker exerciseTracker;
    public AvitarManager avitarManager;


    public static string appDataPath;

    // Use this for initialization
    void Start () {
        appDataPath = Application.persistentDataPath;
        Debug.Log(appDataPath);
        Load();
        subscribeToDelegates();
	}
	
    public void subscribeToDelegates()
    {
        exMan.ExerciseCreated += exerciseAdded;
        workMan.WorkoutCreated += workoutCreated;
        player.PowerLevelChanged += showNewPowerLevel;
    }

    public void exerciseAdded(Exercise ex)
    {
        exerciseTracker.addExercise(ex);
        workMan.addToWorkout(ex);
    }

    public void addExercise()
    {
    }

    public void workoutCreated(Workout w)
    {
        player.AddWorkout(w);
        exMan.clearWorkout();
        player.addPowerLevel(powerLevelManager.powerToAdd());
        findHighestWorkout(w);
        Save();
    }

    public void showNewPowerLevel(int powerLevel)
    {
        avitarManager.CheckPowerLevel(powerLevel);
    }

    public void findHighestWorkout(Workout w)
    {
        //loops over all exercise types. then prints out highest for each type!
        foreach (string exerciseType in w.exercises.Keys)
        {
            Debug.Log("HIGHEST SCORE FOR" + exerciseType + ": " + exerciseTracker.highestScore(exerciseType));
        }
    }

    public void printWorkouts()
    {
        if (File.Exists(appDataPath + PlayerSaveFilePath))
        {
            FileStream file = null;
            try
            {
                string fileJson = File.ReadAllText(appDataPath + PlayerSaveFilePath);
                PlayerData data = JsonConvert.DeserializeObject<PlayerData>(fileJson);
                if (data != null)
                {
                    player.PowerLevel = data.powerLevel;
                    player.Workouts = data.workouts;


                    if (data.workouts != null)
                    {
                        Debug.Log("You Have :" + data.workouts.Count + " Workouts");
                        Dictionary<Guid, Exercise> exerciser = exerciseTracker.getAllExercises();
                        int index = 1;
                        foreach (Workout wo in player.Workouts)
                        {
                            Debug.Log("Workout: " + index);
                            foreach (KeyValuePair<string, Guid> kvp in wo.exercises)
                            {
                                Exercise ex = exerciser[kvp.Value];
                                Debug.Log(ex);
                                Debug.Log(ex.reps);
                                
                            }
                            index += 1;
                        }

                        Debug.Log("=================END OF WORKOUT========================");
                    }
                    else
                        Debug.Log("NOWORKOUT");
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
        else
        {
            Debug.Log("NO FILE TO LOAD");
        }
    }

 
    public static string PlayerSaveFilePath = "/player.dat";
    public static string ExerciseSaveFilePath = "/exercises.dat";
    public void Save()
    {
        Debug.Log(appDataPath+PlayerSaveFilePath);
        //Player Save ============================
        FileStream file = null;
        try
        {
            PlayerData data = new PlayerData();
            data.powerLevel = player.PowerLevel;
            data.workouts = player.Workouts;
            var dataJson = JsonConvert.SerializeObject(data);

            File.WriteAllText(appDataPath + PlayerSaveFilePath, dataJson);
            Debug.Log(dataJson);
        }
        finally
        {
            if (file != null)
            {
                file.Dispose();
            }
        }
        Debug.Log("Saved Player");

        //=========================================
        try
        {

            var dataJson = JsonConvert.SerializeObject(exerciseTracker.getAllExercises());

            File.WriteAllText(appDataPath + ExerciseSaveFilePath, dataJson);
            Debug.Log(dataJson);
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public void Load()
    {
        //Player-----------
        if (File.Exists(appDataPath + PlayerSaveFilePath))
        {
            FileStream file = null;
            try
            {
                string fileJson = File.ReadAllText(appDataPath + PlayerSaveFilePath);
                PlayerData data = JsonConvert.DeserializeObject<PlayerData>(fileJson);
                if (data != null)
                {
                    player.PowerLevel = data.powerLevel;
                    player.Workouts = data.workouts;
                    Debug.Log(player.PowerLevel);
                    Debug.Log(player.Workouts);
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
        //Exercise---------------
        if (File.Exists(appDataPath + ExerciseSaveFilePath))
        {
            try
            {
                string fileJson = File.ReadAllText(appDataPath + ExerciseSaveFilePath);
                Dictionary<Guid, Exercise> data = JsonConvert.DeserializeObject<Dictionary<Guid, Exercise>>(fileJson);
                if (data != null)
                {
                    exerciseTracker.dictOfAllExercises = data;
                }
                else
                    Debug.Log("No Exercises to load");
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
    }
    public void ClearData()
    {
        player.clearWorkout();
        exerciseTracker.clearEx();
        if (File.Exists(Application.persistentDataPath + PlayerSaveFilePath))
        {
            try
            {
                File.Delete(Application.persistentDataPath + PlayerSaveFilePath);
            }
            catch (Exception e)
            {
                Debug.Log("ERROR. Not Sure whatsup: " + e.ToString());
            }
        }

        Debug.Log("Data Cleared");

        if (File.Exists(Application.persistentDataPath + ExerciseSaveFilePath))
        {
            try
            {
                File.Delete(Application.persistentDataPath + ExerciseSaveFilePath);
            }
            catch (Exception e)
            {
                Debug.Log("ERROR. Not Sure whatsup: " + e.ToString());
            }
        }
        Debug.Log("Data Cleared");


    }
}
