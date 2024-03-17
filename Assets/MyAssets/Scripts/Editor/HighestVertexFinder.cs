#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

public class HighestVertexFinder : Editor
{
    [MenuItem("Tools/Sort Objects by Vertex Count")]
    static void SortObjectsByVertexCount()
    {
        MeshFilter[] allMeshFilters = FindObjectsOfType<MeshFilter>(); // Sahnedeki t�m MeshFilter'leri al.

        List<KeyValuePair<GameObject, int>> vertexCounts = new List<KeyValuePair<GameObject, int>>();

        foreach (MeshFilter mf in allMeshFilters)
        {
            vertexCounts.Add(new KeyValuePair<GameObject, int>(mf.gameObject, mf.sharedMesh.vertexCount));
        }

        // Vertex say�s�na g�re b�y�kten k����e s�rala
        vertexCounts.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

        // S�ral� vertex say�lar� ve objeleri yazd�r
        foreach (KeyValuePair<GameObject, int> pair in vertexCounts)
        {
            Debug.Log("Objekt: " + pair.Key.name + " , Vertex Say�s�: " + pair.Value, pair.Key);
        }
    }
}
#endif
