using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(GameManager))]
public class clearDataEditor : Editor {
    bool clearConsole = true;
   // SerializedProperty workouts;

    private void OnEnable()
    {
       // workouts = serializedObject.FindProperty("Workouts");
    }
    public override void OnInspectorGUI()
    {
       
        base.OnInspectorGUI();

        GameManager gm = (GameManager)target;
        
        clearConsole = EditorGUILayout.Toggle("Clear Data Before Printing", clearConsole);

        if (GUILayout.Button("Clear Data"))
        {
            gm.ClearData();
          
        }
        if(GUILayout.Button("Print Workouts"))
        {
            if (clearConsole)
                clearLogWindow();
            gm.printWorkouts();
        }

        if(GUILayout.Button("Print Power Level"))
        {
            if (clearConsole)
                clearLogWindow();
            gm.player.printPowerLevel();
        }


        if (GUILayout.Button("Clear Debug Window"))
        {
            clearLogWindow();
        }

    }

    public void clearLogWindow()
    {
        var assembly = Assembly.GetAssembly(typeof(SceneView));
        var type = assembly.GetType("UnityEditor.LogEntries");
        var method = type.GetMethod("Clear");
        method.Invoke(new object(), null);
    }

}
[CustomEditor(typeof(ExerciseTracker))]
public class clearExDataEditor : Editor
{
    public override void OnInspectorGUI()
    {

        base.OnInspectorGUI();
        
        ExerciseTracker et = (ExerciseTracker)target;


        if (GUILayout.Button("Clear Data"))
        {
           // et.ClearData();
        }
    }
}
