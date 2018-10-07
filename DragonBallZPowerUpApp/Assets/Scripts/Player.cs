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
}

