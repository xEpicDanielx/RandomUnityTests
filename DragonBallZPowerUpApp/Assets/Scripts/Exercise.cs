using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO; //filestream
using System.Runtime.Serialization.Formatters.Binary; //no effing idea

[Serializable]
public class Exercise{
    //public List<Set> sets;
    public string id;
    public int sets;
    public int reps;
    public int weight; 
}
