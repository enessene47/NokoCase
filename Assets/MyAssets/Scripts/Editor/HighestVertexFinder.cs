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
        MeshFilter[] allMeshFilters = FindObjectsOfType<MeshFilter>(); // Sahnedeki tüm MeshFilter'leri al.

        List<KeyValuePair<GameObject, int>> vertexCounts = new List<KeyValuePair<GameObject, int>>();

        foreach (MeshFilter mf in allMeshFilters)
        {
            vertexCounts.Add(new KeyValuePair<GameObject, int>(mf.gameObject, mf.sharedMesh.vertexCount));
        }

        // Vertex sayýsýna göre büyükten küçüðe sýrala
        vertexCounts.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

        // Sýralý vertex sayýlarý ve objeleri yazdýr
        foreach (KeyValuePair<GameObject, int> pair in vertexCounts)
        {
            Debug.Log("Objekt: " + pair.Key.name + " , Vertex Sayýsý: " + pair.Value, pair.Key);
        }
    }
}
#endif
