using UnityEngine;
using UnityEditor;
using System.Reflection;

[CustomEditor(typeof(Player))]
public class clearDataEditor : Editor {
    bool clearConsole = false;
    SerializedProperty workouts;

    private void OnEnable()
    {
        workouts = serializedObject.FindProperty("Workouts");
    }
    public override void OnInspectorGUI()
    {
       
        base.OnInspectorGUI();

        Player player = (Player)target;
        
        clearConsole = EditorGUILayout.Toggle("Clear Data Before Printing", clearConsole);

        if (GUILayout.Button("Clear Data"))
        {
            player.ClearData();
        }
        if(GUILayout.Button("Print Data"))
        {
            if (clearConsole)
                clearLogWindow();
            player.printWorkouts();
        }

        if(GUILayout.Button("Print Power Level"))
        {
            if (clearConsole)
                clearLogWindow();
            player.printPowerLevel();
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
            et.ClearData();
        }
    }
}
