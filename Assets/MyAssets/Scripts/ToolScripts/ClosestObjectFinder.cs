using System.Collections.Generic;
using UnityEngine;

public static class ClosestObjectFinder
{
    public static Transform FindClosestObject(List<Transform> objects, Transform target)
    {
        if (objects == null || objects.Count == 0)
            return null;

        Transform closestObject = null;

        float closestDistance = Mathf.Infinity;

        foreach (var obj in objects)
        {
            if (!obj.gameObject.activeSelf)
                continue;

            float distanceToTarget = Vector3.Distance(obj.transform.position, target.position);

            if (distanceToTarget < closestDistance)
            {
                closestObject = obj.transform;
                closestDistance = distanceToTarget;
            }
        }

        return closestObject;
    }

    public static Transform FindClosestObject(Transform[] objects, Transform target)
    {
        if (objects == null || objects.Length == 0)
            return null;

        Transform closestObject = null;

        float closestDistance = Mathf.Infinity;

        foreach (var obj in objects)
        {
            if (!obj.gameObject.activeSelf)
                continue;

            float distanceToTarget = Vector3.Distance(obj.transform.position, target.position);

            if (distanceToTarget < closestDistance)
            {
                closestObject = obj.transform;
                closestDistance = distanceToTarget;
            }
        }

        return closestObject;
    }

    public static Vector3 ClosestVertexToPoint(this Mesh mesh, Vector3 point)
    {
        Vector3[] vertices = mesh.vertices;
        float minDistanceSqr = Mathf.Infinity; // Baþlangýç deðeri olarak sonsuz kabul ediyoruz.
        Vector3 closestVertex = Vector3.zero;

        foreach (Vector3 vertex in vertices)
        {
            Vector3 diff = point - vertex;
            float distSqr = diff.sqrMagnitude; // Kare deðerini alýyoruz çünkü karekök hesaplamasý pahalýdýr.

            if (distSqr < minDistanceSqr)
            {
                minDistanceSqr = distSqr;
                closestVertex = vertex;
            }
        }

        return closestVertex;
    }
}
