using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System; 

public class WorkoutAddMenu : MonoBehaviour {
    public Player player;
    
    // Use this for initialization
    void Start () {
		
	}

    public Workout CreateWorkout()
    {
        Workout w = new Workout();
        w.timeOfWorkout = DateTime.Now;
        return w; 
    }
    public void AddWorkout()
    {
        player.AddWorkout(CreateWorkout());
       
    }
  
}
