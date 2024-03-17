using UnityEngine;
using System.Collections.Generic;

public class EllipticPointsGenerator : MonoBehaviour
{
    public Transform startPointTransform;
    public Transform endPointTransform;
    public int pointCount = 100;
    public float averageRadius = 5f;
    public float amplitude = 2f; // Kývrým miktarý

    private Vector3[] points = null;

    private void Start()
    {
        if (startPointTransform == null || endPointTransform == null)
        {
            Debug.LogError("Start veya End Transform belirtilmemiþ!");
            return;
        }

        points = CirclePointsDrawer.GenerateCirclePointsVersion2(startPointTransform.position, endPointTransform.position, 10f, 5, .5f);

    }

    List<Vector3> GenerateSemiCirclePoints(Vector3 start, Vector3 end, int count)
    {
        List<Vector3> points = new List<Vector3>();

        Vector3 center = (start + end) / 2;
        float radius = Vector3.Distance(start, center);

        Vector3 startToEnd = end - start;
        float startAngle = Mathf.Atan2(startToEnd.z, startToEnd.x) - Mathf.PI / 2;

        for (int i = 0; i < count; i++)
        {
            float fraction = (float)i / (count - 1);
            float theta = startAngle + Mathf.PI * fraction;

            // Kývrýmlarý ekleyerek radyusu deðiþtir:
            float r = radius + amplitude * Mathf.Sin(5 * theta);

            float x = r * Mathf.Cos(theta) + center.x;
            float z = r * Mathf.Sin(theta) + center.z;

            points.Add(new Vector3(x, 0f, z));
        }

        return points;
    }


    private void OnDrawGizmos()
    {
        if (points == null)
            return;

        Gizmos.color = Color.red;

        foreach (var point in points)
            Gizmos.DrawSphere(point, .3f);
    }
}
