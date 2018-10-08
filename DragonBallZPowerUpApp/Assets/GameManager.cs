using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq; 

public class GameManager : MonoBehaviour {
    public ExerciseManager exMan;
    public WorkoutManager workMan;
    public Player player;
    public PowerLevelManager powerLevelManager;
    public ExerciseTracker exerciseTracker; 

    // Use this for initialization
    void Start () {
        subscribeToDelegates();
	}
	
    public void subscribeToDelegates()
    {
        exMan.exerciseCreatedEvent += exerciseAdded;
       
        workMan.workoutCreatedEvent += workoutCreated;
    }

    public void exerciseAdded(Dictionary<string, Exercise> cw)
    {
        foreach (KeyValuePair<string, Exercise> kvp in cw)
        {
            Debug.Log("NAME: " + kvp.Key);
            exerciseTracker.addExercise(kvp.Value);
        }
        Dictionary<string, Guid> cw2 = cw.ToDictionary(kvp => kvp.Value.type, kvp => kvp.Value.id); 
        workMan.addToWorkout(cw2);

    }

    public void addExercise()
    {
        Debug.Log("HI");
    }

    public void workoutCreated(Workout w)
    {
        player.AddWorkout(w);
        exMan.clearWorkout();
        player.addPowerLevel(powerLevelManager.powerToAdd()); 
    }
}
