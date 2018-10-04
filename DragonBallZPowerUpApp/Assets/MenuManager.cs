using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    public List<Transform> children;
    // Use this for initialization
    void Start() {
        foreach (Transform child in transform)
        {
            if (child.name != "CreateWorkout_Menu")
                child.gameObject.SetActive(false);
            children.Add(child);
        }

        /*Debug.Log("HERE IS LIST");
        foreach (Transform c in children)
        {
            Debug.Log(c.name.ToString());
        }*/
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
   }
}
