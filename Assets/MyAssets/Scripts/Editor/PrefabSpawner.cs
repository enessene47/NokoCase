using UnityEditor;
using UnityEngine;

public class PrefabSpawner : EditorWindow
{
    private GameObject parentObject;

    private GameObject prefab;

    private float radius;

    private int count;

    [MenuItem("Tools/Prefab Spawner")]
    public static void ShowWindow()
    {
        GetWindow<PrefabSpawner>("Prefab Spawner");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Prefab Spawner", EditorStyles.boldLabel);

        parentObject = EditorGUILayout.ObjectField("Parent Object", parentObject, typeof(GameObject), true) as GameObject;

        prefab = EditorGUILayout.ObjectField("Prefab", prefab, typeof(GameObject), false) as GameObject;

        radius = EditorGUILayout.FloatField("Radius", radius);

        count = EditorGUILayout.IntField("Count", count);

        if (GUILayout.Button("Spawn Prefabs"))
        {
            SpawnPrefabs();
        }
    }

    private void SpawnPrefabs()
    {
        if (parentObject == null)
        {
            Debug.LogError("Parent Object is not assigned.");

            return;
        }

        if (prefab == null)
        {
            Debug.LogError("Prefab is not assigned.");

            return;
        }

        float angleDelta = 360f / count;

        for (int i = 0; i < count; i++)
        {
            float angle = i * angleDelta;

            Vector3 spawnPosition = parentObject.transform.position + new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0f, Mathf.Sin(angle * Mathf.Deg2Rad)) * radius;

            GameObject spawnedPrefab = PrefabUtility.InstantiatePrefab(prefab) as GameObject;

            spawnedPrefab.transform.parent = parentObject.transform;

            spawnedPrefab.transform.position = spawnPosition;

            spawnedPrefab.transform.rotation = Quaternion.identity;
        }
    }
}
