using UnityEngine;
using UnityEditor;

public class ExampleWindow : EditorWindow
{

    string nameInput = "New Prefab Object";

    GameObject newPrefab = new GameObject();
    GameObject[] selection = Selection.gameObjects;


    [MenuItem("Window/Example")]
    public static void ShowWindow()
    {
        GetWindow<ExampleWindow>("Prefab Maker");
            
    }

    private void OnGUI()
    {

        //this is the label for the window
        GUILayout.Label("Select Objects To Make A New Prefab", EditorStyles.boldLabel);

        nameInput = EditorGUILayout.TextField("Name", nameInput);
        

        foreach (GameObject gameObj in selection)
        {
        }


            if (GUILayout.Button("Make Prefab"))
        {
            GameObject prefab = new GameObject(nameInput);
        }

    }
}
