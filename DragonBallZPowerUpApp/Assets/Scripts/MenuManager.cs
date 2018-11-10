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
    public Transform lastScreen;
    public Transform startingMenu; 

    public Stack<Transform> visitHistory = new Stack<Transform>(); 

    public Sprite[] backgroundImageSelections = new Sprite[2];
    
    // Use this for initialization
    void Start() {

        foreach (Transform child in transform)
        {
            if (child.name != startingMenu.name)
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                pushStack(child);
            }

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
        pushStack(activeMenu); 
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

    public void printStack()
    {
        Debug.Log("STARTING:");
        foreach(Transform t in visitHistory)
        {
            Debug.Log(t.name.ToString());
        }

        Debug.Log("END");
    }

    public void popStack()
    {
        if(visitHistory.Count > 1)
        {
            visitHistory.Pop().gameObject.SetActive(false);
            visitHistory.Peek().gameObject.SetActive(true);
        }
    }
    
    public void pushStack(Transform page)
    {
       
        if (visitHistory.Count != 0)
        {
            Transform lastPage = visitHistory.Peek();
            lastPage.gameObject.SetActive(false);
        }
          

        visitHistory.Push(page);

       
        page.gameObject.SetActive(true); 
    }
}
