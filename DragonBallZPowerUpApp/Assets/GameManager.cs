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
            exerciseTracker.addExercise(kvp.Value);
        }
        //to dictionary (key slelctor, element selector)
        //first lambda is how to get key, second is how to get element.
        //turns type into key.. because this tracks individual exercise
        //dictionary is now flipped. string first then guid!!!
        Dictionary<string, Guid> cw2 = cw.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.id);

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
