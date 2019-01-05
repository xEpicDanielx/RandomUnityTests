using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class WorkoutShow : MonoBehaviour {
    public TextMeshProUGUI workoutText;
    public ExerciseTracker et; 
    public void setWorkoutText(Workout workout)
    {
        foreach(Guid guid in workout.exercises.Values)
        {
            workoutText.text += et.dictOfAllExercises[guid].type.ToString() + "\n";
            workoutText.text += et.dictOfAllExercises[guid].reps.ToString() + ": ";
            workoutText.text += et.dictOfAllExercises[guid].sets.ToString() + ": ";
            workoutText.text += et.dictOfAllExercises[guid].weight.ToString() + "\n";
        }
    }
}
