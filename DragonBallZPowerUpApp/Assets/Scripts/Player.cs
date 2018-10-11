using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 
using System.IO; //filestream
using System.Runtime.Serialization.Formatters.Binary; //no effing idea
using Newtonsoft.Json;
using helperTools; 

public class Player : MonoBehaviour {

    public int PowerLevel;
    public List<Workout> Workouts;
    public GenericDelegate<int> PowerLevelChanged; 
   
    //public PowerLevelChanged powerLevelChangedEvent = null;

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
        int index = 1;

        if (Workouts != null)
        {
            Debug.Log("You Have :" + Workouts.Count+ " Workouts"); 
            foreach (Workout wo in Workouts)
            {
               Debug.Log(index+") WORKOUT START:");
               wo.PrintExercises();
                index++;
            }
            
            Debug.Log("=================END OF WORKOUT========================");
        }
        else
            Debug.Log("NOWORKOUT");         
    }
       
    public void addPowerLevel(int powerAddition)
    {
        PowerLevel += powerAddition;
        if (PowerLevelChanged != null)
            PowerLevelChanged(PowerLevel);
    }

    public void printPowerLevel()
    {
        Debug.Log("POWER LEVEL: " + PowerLevel);
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

