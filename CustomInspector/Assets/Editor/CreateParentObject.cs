using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class CreateParentObject : EditorWindow
{

    string nameInput = "New Parent Object";


    bool twoDimObject = false;
    bool sameYPlane = false;

    GameObject[] selection { get { return Selection.gameObjects; } }

    [MenuItem("GameObject/Parent Maker")]
    public static void ShowWindow()
    {
        GetWindow<CreateParentObject>("Parent Maker");

    }

    private void OnGUI()
    {

        //this is the label for the window
        GUILayout.Label("Select Objects To Make A New Prefab", EditorStyles.boldLabel);

        //these are the fields for the parent if it is a 2D object then the children will have matching z
        nameInput = EditorGUILayout.TextField("Name", nameInput);

        twoDimObject = EditorGUILayout.Toggle(new GUIContent("2D Object", "2D Will have their z set to the New Parent"),twoDimObject);
        sameYPlane = EditorGUILayout.Toggle(new GUIContent("Same Y Axis", "This will set all children's Y position to 0 with Parent"), sameYPlane);




        EditorGUILayout.LabelField("Currently Selected : ", EditorStyles.boldLabel);
        foreach (GameObject gameObj in selection)
        {
            EditorGUILayout.LabelField(gameObj.name);
            this.Repaint();
        }




        if (GUILayout.Button("Make Parent"))
        {
        
            GameObject prefab = new GameObject(nameInput);

            foreach (GameObject gameObj in selection)
            {
                gameObj.transform.SetParent(prefab.transform);
                if (twoDimObject)
                {
                    gameObj.transform.position = new Vector3(gameObj.transform.position.x, gameObj.transform.position.y, prefab.transform.position.z);
                }
                if (sameYPlane)
                {
                    gameObj.transform.position = new Vector3(gameObj.transform.position.x, prefab.transform.position.y, gameObj.transform.position.z);
                }
            }

            prefab.transform.position = new Vector3(0,0,0);

            EditorSceneManager.MarkAllScenesDirty();
        }

    }
}
