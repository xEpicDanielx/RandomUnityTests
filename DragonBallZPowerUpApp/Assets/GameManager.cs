using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public ExerciseManager exMan;
    public WorkoutManager workMan;
    public Player player;

    // Use this for initialization
    void Start () {
        subscribeToDelegates();
	}
	
    public void subscribeToDelegates()
    {
        exMan.exerciseAddedToWorkoutEvent += exerciseAdded;
        workMan.workoutCreatedEvent += workoutCreated;
    }

    public void exerciseAdded(Dictionary<string, Exercise> cw)
    {
        foreach (KeyValuePair<string, Exercise> kvp in cw)
        {
            Debug.Log("NAME: " + kvp.Key);
        }
        workMan.addToWorkout(cw);
    }

    public void workoutCreated(Workout w)
    {
        player.AddWorkout(w);
        exMan.clearWorkout();
    }
}
