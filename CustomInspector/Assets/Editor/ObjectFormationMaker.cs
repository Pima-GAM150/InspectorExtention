using UnityEditor;
using UnityEngine;

public class ObjectFormationMaker : EditorWindow
{
    [MenuItem("GameObject/Formation Maker")]
    public static void ShowWindow()
    {
        GetWindow<ObjectFormationMaker>("Formation Maker");
    }


    private void OnGUI()
    {
        GUILayout.Label("Select Objects to put into a formation");
    }

}
