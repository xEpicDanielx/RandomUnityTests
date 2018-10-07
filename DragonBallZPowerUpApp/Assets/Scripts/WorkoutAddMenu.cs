using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System; 

public class WorkoutAddMenu :MonoBehaviour {
    public delegate void WorkoutCreated(Workout w);
    public WorkoutCreated workoutCreatedEvent =null; 
    
    public void CreateWorkout()
    {
        Workout w = new Workout
        {
            timeOfWorkout = DateTime.Now
        };
        workoutCreatedEvent(w); 
    }
   
  
}
