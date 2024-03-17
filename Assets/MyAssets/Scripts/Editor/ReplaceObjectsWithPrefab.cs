using UnityEditor;
using UnityEngine;

public class ReplaceObjectsWithPrefab : EditorWindow
{
    private GameObject prefab;

    [MenuItem("Custom/Replace Objects with Prefab")]
    static void CreateWindow()
    {
        ReplaceObjectsWithPrefab window = GetWindow<ReplaceObjectsWithPrefab>();
        window.titleContent = new GUIContent("Replace Objects with Prefab");
        window.Show();
    }

    private void OnGUI()
    {
        prefab = EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), false) as GameObject;

        if (GUILayout.Button("Replace"))
        {
            ReplaceSelectedObjects();
        }
    }

    private void ReplaceSelectedObjects()
    {
        GameObject[] selectedObjects = Selection.gameObjects;

        foreach (GameObject obj in selectedObjects)
        {
            GameObject newObject = PrefabUtility.InstantiatePrefab(prefab) as GameObject;
            newObject.transform.position = obj.transform.position;
            newObject.transform.rotation = obj.transform.rotation;
            newObject.transform.localScale = obj.transform.localScale;
            newObject.transform.parent = obj.transform.parent;

            Undo.RegisterCreatedObjectUndo(newObject, "Replace Objects with Prefab");
            Undo.DestroyObjectImmediate(obj);
        }
    }
}
