using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using System.IO; //filestream
using System.Runtime.Serialization.Formatters.Binary; //no effing idea

public class Player : MonoBehaviour {

    public int PowerLevel;
    public List<Workout> Workouts;

    private static string SaveFilePath = "/player.dat";
    
    public void Awake()
    {
        Load();
  
        if (Workouts == null)
            Workouts = new List<Workout>();

        //printWorkouts(); 
    }



    public void AddWorkout(Workout work)
    {
        Workouts.Add(work);
        Save();
    }

    public void printWorkouts()
    {

        if (Workouts != null)
        {
            foreach (Workout wo in Workouts)
            {
               Debug.Log("WORKOUT START:");
               wo.PrintExercises();
            }
            Debug.Log("=================END OF WORKOUT========================");
        }
        else
            Debug.Log("NOWORKOUT");
            
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
            var dataJson = JsonUtility.ToJson(data,true);

            data.printWorkouts(); 
            File.WriteAllText(Application.persistentDataPath + SaveFilePath, dataJson);
            Debug.Log(dataJson);
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
                  string fileJson = File.ReadAllText(Application.persistentDataPath + SaveFilePath);
                  PlayerData data = JsonUtility.FromJson<PlayerData>(fileJson);
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
                    if(file != null)
                    {
                        file.Dispose();
                    }
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
            catch(Exception e)
            {
                Debug.Log("ERROR. Not Sure whatsup: " + e.ToString());
            }
        }

        Debug.Log("Data Cleared"); 
       
    }

}
[Serializable]
public class PlayerData
{
    public int powerLevel;
    public List<Workout> workouts;

    public void printWorkouts()
    {

        if (workouts != null)
        {
            foreach (Workout wo in workouts)
            {
                Debug.Log("----------------------------------:Workout Start:");
                foreach (KeyValuePair<string, Exercise> kvp in wo.exercises)
                {
                    Debug.Log("NAME: " + kvp.Key);
                    Debug.Log("Sets: " + kvp.Value.sets);
                    Debug.Log("Reps: " + kvp.Value.reps);
                    Debug.Log("Weight: " + kvp.Value.weight);
                    Debug.Log("--------------------------------");
                }
            }
            Debug.Log("=================END OF WORKOUT========================");
        }
        else
            Debug.Log("NOWORKOUT");

    }
}

