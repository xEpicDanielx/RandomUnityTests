using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(MenuManager))]
public class menuManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();

        MenuManager Mm = (MenuManager)target;


        if (GUILayout.Button("Print Stack"))
        {
            Mm.printStack(); 

        }
        if(GUILayout.Button("Pop Stack"))
        {
            Mm.popStack();
        }
    }
}
