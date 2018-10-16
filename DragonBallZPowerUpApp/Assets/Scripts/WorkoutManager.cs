using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using helperTools;

public class WorkoutManager : MonoBehaviour {
    public GenericDelegate<Workout> WorkoutCreated;

    public Dictionary<string, Guid> currentWorkout = new Dictionary<string, Guid>();

    public void addToWorkout(Exercise ex)
    {
        currentWorkout.Add(ex.type, ex.id);
    }

    public void CreateWorkout()
    {
        Workout w = new Workout
        {
            timeOfWorkout = DateTime.Now,
            exercises = currentWorkout
        };
        WorkoutCreated(w);
        printWorkout();
        clearWorkout();
    }

    public void clearWorkout()
    {
        currentWorkout.Clear();
    }
    public void printWorkout()
    {
        foreach(KeyValuePair<string,Guid> workout in currentWorkout)
        {
            Debug.Log(workout.Key);
        }
    }
}
