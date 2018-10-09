using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class WorkoutManager : MonoBehaviour {
    public delegate void WorkoutCreated(Workout w);
    public WorkoutCreated workoutCreatedEvent = null;

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
        workoutCreatedEvent(w);
    }

}
