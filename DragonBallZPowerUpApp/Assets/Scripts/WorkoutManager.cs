﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class WorkoutManager : MonoBehaviour {
    public delegate void WorkoutCreated(Workout w);
    public WorkoutCreated workoutCreatedEvent = null;

    public Dictionary<string, Exercise> currentWorkout;

    public void addToWorkout(Dictionary<string, Exercise> cW)
    {
        currentWorkout = cW; 
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