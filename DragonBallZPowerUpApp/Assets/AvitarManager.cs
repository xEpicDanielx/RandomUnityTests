using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvitarManager : MonoBehaviour {
    public Sprite[] images = new Sprite[2];
    public Image avitar;
	// Use this for initialization
	void Start () {
        avitar.sprite = images[0]; 
	}

    public void CheckPowerLevel(int PowerLevel)
    {
        if (PowerLevel > 9000)
        {
            avitar.sprite = images[1];
        }
        else
            avitar.sprite = images[0];
    }
}
