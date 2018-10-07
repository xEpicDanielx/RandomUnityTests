using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Player))]
public class clearDataEditor : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Player player = (Player)target;
        if(GUILayout.Button("Clear Data"))
        {
            player.ClearData(); 
        }
    }

}
