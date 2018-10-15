using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using helperTools; 
public class MenuManager : MonoBehaviour {

    public Image backgroundImage; 
    public List<Transform> children;
    public Player player; 
    public PlayerInfoMenu pInfoMenu;
    public GenericDelegate newScreenSelected; 

    public Sprite[] backgroundImageSelections = new Sprite[2];
    
    // Use this for initialization
    void Start() {
        foreach (Transform child in transform)
        {
            if (child.name != "CreateWorkout_Menu")
                child.gameObject.SetActive(false);
            children.Add(child);
        }
        newScreenSelected();
       
    }

    public void UpdatePlayerInfo(Player p)
    {
        player = p;
        if(pInfoMenu != null)
        {
            pInfoMenu.UpdateInfo(player);
        }
    }

    public void SetActiveMenu(Transform activeMenu)
   {
        if(children.Contains(activeMenu))
        {
            foreach (Transform child in transform)
            {
                if (child != activeMenu)
                    child.gameObject.SetActive(false);
                else
                    child.gameObject.SetActive(true); 
            }
        }
        newScreenSelected(); 
   }


    public void setBackgroundImage(int powerLevel)
    {
        if (powerLevel > 10000)
        {
            backgroundImage.sprite = backgroundImageSelections[1];
        }
        else
            backgroundImage.sprite = backgroundImageSelections[0];
    }
}
