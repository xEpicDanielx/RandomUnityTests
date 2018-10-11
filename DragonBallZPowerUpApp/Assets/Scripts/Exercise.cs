using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO; //filestream
using System.Runtime.Serialization.Formatters.Binary; //no effing idea
using System.Text; 

[Serializable]
public class Exercise{
    public Guid id; 
    public string type;
    public int sets;
    public int reps;
    public int weight;

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
            sb.AppendLine("NAME: " + type);
            sb.AppendLine("Sets: " + sets);
            sb.AppendLine("Reps: " + reps);
            sb.AppendLine("Weight: " +weight);
            sb.AppendLine("--------------------------------");

        return sb.ToString(); 
    }
}
