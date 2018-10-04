using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO; //filestream
using System.Runtime.Serialization.Formatters.Binary; //no effing idea

[Serializable]
public class Workout{
    public DateTime timeOfWorkout;
    public Dictionary<string,Exercise> exercises; 
	// Use this for initialization
    
}
