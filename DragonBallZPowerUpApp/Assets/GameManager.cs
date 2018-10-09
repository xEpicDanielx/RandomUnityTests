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
        exMan.exerciseAddedEvent += exerciseAdded;
        workMan.workoutCreatedEvent += workoutCreated;
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
    }
    public void findHighestWorkout(Workout w)
    {
        //loops over all exercise types. then prints out highest for each type!
        foreach(string exerciseType in w.exercises.Keys)
        {
            Debug.Log("HIGHEST SCORE FOR" + exerciseType + ": " + exerciseTracker.highestScore(exerciseType));
        }
    }
}
