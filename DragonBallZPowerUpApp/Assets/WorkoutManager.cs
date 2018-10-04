using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class WorkoutManager : MonoBehaviour {
    public delegate void WorkoutCreated(Workout w);
    public WorkoutCreated workoutCreatedEvent = null;

    public ExerciseManager exMan;
    public Dictionary<string, Exercise> currentWorkout = new Dictionary<string, Exercise>();


    void Start()
    {
        exMan.exerciseAddedToWorkoutEvent += exerciseAdded;
    }

    public void exerciseAdded(Dictionary<string,Exercise> cw)
    {
    }
    public void CreateWorkout()
    {
        Workout w = new Workout
        {
            timeOfWorkout = DateTime.Now
        };
        workoutCreatedEvent(w);
    }

}
