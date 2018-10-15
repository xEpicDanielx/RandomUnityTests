using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayerInfoMenu : MonoBehaviour {
    public TextMeshProUGUI HighestLevel, NumberOfWorkouts, PowerLevelNeeded, PowerLevel;
  
    public void UpdateInfo(Player player)
    {
        
        //coming soon
        HighestLevel.text = "Higheset Level: \r\n Super Sayian 1";
        PowerLevelNeeded.text = "Coming Soon";
        
        NumberOfWorkouts.text = "Number Of Workouts: \r\n" +player.Workouts.Count.ToString();
        PowerLevel.text = player.PowerLevel.ToString();
    }

}
