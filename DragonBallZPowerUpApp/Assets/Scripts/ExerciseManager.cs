using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using helperTools; 
public class ExerciseManager : MonoBehaviour {
    [SerializeField]
    public Dictionary<string, Exercise> currentWorkout = new Dictionary<string, Exercise>();
    
    //public Exercise currentExercise; 
    public Text eTitle, eSets, eReps, eWeight;


    public GenericDelegate<Exercise> ExerciseCreated;
   

    public void createExercise()
    {
        int eS, eR, eW;
        if (eTitle.text == null ||
            !int.TryParse(eSets.text, out eS)|| 
            !int.TryParse(eReps.text, out eR) || 
            !int.TryParse(eWeight.text, out eW))
        {
            Debug.Log("ERROR Missing Field");
        }
        else
        {
            Exercise currentExercise = new Exercise();

            currentExercise.id = Guid.NewGuid();
            currentExercise.type = eTitle.text;
            currentExercise.reps = eR;
            currentExercise.sets = eS;
            currentExercise.weight = eW;

            addExToWorkout(currentExercise);
        }
   
       
    }
    public void addExToWorkout(Exercise ex)
    {
        if (currentWorkout.ContainsKey(ex.type)||currentWorkout==null)
            Debug.Log("EXERCISE ALREADY EXSISTS!");
        else
        {
            currentWorkout.Add(ex.type, ex);
            ExerciseCreated(ex); 
        }

    }
    public void printDictionary()
    {
        Debug.Log("CURRENT DICTIONARY =====================");
        foreach (KeyValuePair<string, Exercise> kvp in currentWorkout)
        {
            Debug.Log("NAME: " + kvp.Key);
            Debug.Log("Sets: " + kvp.Value.sets);
            Debug.Log("Reps: " + kvp.Value.reps);
            Debug.Log("Weight: " + kvp.Value.weight);
            Debug.Log("--------------------------------");
        }
        Debug.Log("==========================================");
    }

    public void clearWorkout()
    {
        currentWorkout.Clear(); 
    }

}
