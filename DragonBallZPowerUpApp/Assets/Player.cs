using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using System.IO; //filestream
using System.Runtime.Serialization.Formatters.Binary; //no effing idea

public class Player : MonoBehaviour {
    public WorkoutAddMenu Wom; 

    public int PowerLevel;
    public List<Workout> Workouts;

    private static string SaveFilePath = "/player.dat";
    
    public void Awake()
    {
        Load();
        if (Workouts == null)
            Workouts = new List<Workout>();
        printWorkouts(); 
        setDelegates(); 
    }

    public void setDelegates()
    {
        Wom.workoutCreatedEvent += AddWorkout;
    }
    public void AddWorkout(Workout work)
    {
        Debug.Log(work.timeOfWorkout + " HERE IS TIME");
        Workouts.Add(work);
        Save();
    }

    public void printWorkouts()
    {
        foreach (Workout t in Workouts)
        {
            Debug.Log(t.timeOfWorkout.ToString());
        }
        Debug.Log("------------------");
    }
    public void Save()
    {
        FileStream file = null;
        try
        {
            BinaryFormatter bf = new BinaryFormatter();
 
            file = File.Open(Application.persistentDataPath + SaveFilePath, FileMode.OpenOrCreate);

            PlayerData data = new PlayerData();
            data.powerLevel = PowerLevel;
            data.workouts = Workouts;

            bf.Serialize(file, data);
        }
        finally
        {
            if(file != null)
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
                    BinaryFormatter bf = new BinaryFormatter();
                    file = File.Open(Application.persistentDataPath + SaveFilePath, FileMode.Open);

                    PlayerData data = (PlayerData)bf.Deserialize(file);
                    PowerLevel = data.powerLevel;
                    Workouts = data.workouts; 
                }
                finally
                {
                    if(file != null)
                    {
                        file.Dispose();
                    }
                }
            } 
    }

}
[Serializable]
public class PlayerData
{
    public int powerLevel;
    public List<Workout> workouts;
}

