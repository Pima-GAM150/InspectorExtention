using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class CreateParentObject : EditorWindow
{

    string nameInput = "(New Parent Object)";


    bool sameZPlane = false;
    bool sameYPlane = false;
    bool sameXPlane = false;

    GameObject[] selectedObjects { get { return Selection.gameObjects; } }

    [MenuItem("GameObject/Parent Maker")]
    public static void ShowWindow()
    {
        GetWindow<CreateParentObject>("Parent Maker");

    }

    private void OnGUI()
    {

        //this is the label for the window
        GUILayout.Label("Select Objects To Make A New Parent Object", EditorStyles.boldLabel);

        //these are the fields for the parent if it is a 2D object then the children will have matching z
        nameInput = EditorGUILayout.TextField("Name", nameInput);

        sameZPlane = EditorGUILayout.Toggle(new GUIContent("Align Z Axis", "Aligns all children to parents Z axis (Good for 2D)"), sameZPlane);
        sameYPlane = EditorGUILayout.Toggle(new GUIContent("Align Y Axis", "Aligns all children to parents Y axis (Good for 3D)"), sameYPlane);
        sameXPlane = EditorGUILayout.Toggle(new GUIContent("Align X Axis", "Aligns all children to parents X axis"), sameXPlane);



        EditorGUILayout.LabelField("Currently Selected : ", EditorStyles.boldLabel);
        foreach (GameObject gameObj in selectedObjects)
        {
            EditorGUILayout.LabelField(gameObj.name);
            this.Repaint();
        }




        if (GUILayout.Button("Make Parent"))
        {

            GameObject prefab = new GameObject(nameInput);

            if (selectedObjects != null)
            {
                foreach (GameObject gameObj in selectedObjects)
                {
                    gameObj.transform.SetParent(prefab.transform);

                    if (sameZPlane)
                    {
                        gameObj.transform.position = new Vector3(gameObj.transform.position.x, gameObj.transform.position.y, prefab.transform.position.z);
                    }
                    if (sameYPlane)
                    {
                        gameObj.transform.position = new Vector3(gameObj.transform.position.x, prefab.transform.position.y, gameObj.transform.position.z);
                    }
                    if (sameXPlane)
                    {
                        gameObj.transform.position = new Vector3(prefab.transform.position.x, gameObj.transform.position.y, gameObj.transform.position.z);
                    }
                }

                prefab.transform.position = new Vector3(prefab.GetComponentInChildren<Transform>().position.x, prefab.GetComponentInChildren<Transform>().position.y, prefab.GetComponentInChildren<Transform>().position.z);

                EditorSceneManager.MarkAllScenesDirty();
            }
        }

        /*
        if (GUILayout.Button("Make Prefab"))
        {  //Loop through every GameObject in the array above
            foreach (GameObject gameObject in objectArray)
            {
                //Set the path as within the Assets folder, and name it as the GameObject's name with the .prefab format
                string localPath = "Assets/" + gameObject.name + ".prefab";

                //Check if the Prefab and/or name already exists at the path
                if (AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)))
                {
                    //Create dialog to ask if User is sure they want to overwrite existing Prefab
                    if (EditorUtility.DisplayDialog("Are you sure?",
                        "The Prefab already exists. Do you want to overwrite it?",
                        "Yes",
                        "No"))
                    //If the user presses the yes button, create the Prefab
                    {
                        CreateNew(gameObject, localPath);
                    }
                }
                //If the name doesn't exist, create the new Prefab
                else
                {
                    Debug.Log(gameObject.name + " is not a Prefab, will convert");
                    CreateNew(gameObject, localPath);
                }
            }
        }

     

    }

    static void CreateNew(GameObject obj, string localPath)
    {
        //Create a new Prefab at the path given
        Object prefab = PrefabUtility.CreatePrefab(localPath, obj);
        PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.ConnectToPrefab);
    }
    */
    }
}
