using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ExerciseMenuDisplay : MonoBehaviour {
    public MenuManager menuManager; 
    public TextMeshProUGUI upperText;
    public TextMeshProUGUI lowerText;
    public TextMeshProUGUI centerText;
    public Transform targetMenu;
    public WorkoutShow ws; 
    public Workout workout; 
    public enum layoutType
    {
        pastWorkout,
        exerciseDisplay
    };
   
    public void setLayout(layoutType layout)
    {
        switch (layout)
        {
            case layoutType.pastWorkout:
                upperText.gameObject.SetActive(false); 
                lowerText.gameObject.SetActive(false);
               centerText.gameObject.SetActive(true); 
                break;
            case layoutType.exerciseDisplay:
                upperText.gameObject.SetActive(true);
                lowerText.gameObject.SetActive(true);
                centerText.gameObject.SetActive(false);
                break;
            default:
                break; 
        }
    }

   /* public void setTargetMenu(Transform target)
    {
        targetMenu = target;
    }*/

    public void setTargetMenu(WorkoutShow workoutShow)
    {
        ws = workoutShow;
    }

    public void showWorkout()
    {
        ws.setWorkoutText(workout);
        menuManager.SetActiveMenu(ws.transform);
    }

}
