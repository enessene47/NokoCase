using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class HeatingSelectedObject
{
    static HeatingSelectedObject()
    {
        SceneView.duringSceneGui += OnSceneGUI;
    }

    private static void OnSceneGUI(SceneView sceneView)
    {
        if (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.G)
        {
            if (Selection.activeGameObject != null)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    Selection.activeGameObject.transform.position = hit.point;

                    Event.current.Use();
                }
            }
        }
    }
}
