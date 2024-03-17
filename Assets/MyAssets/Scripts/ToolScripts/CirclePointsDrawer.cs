using UnityEngine;

public static class CirclePointsDrawer
{
    public static Vector3[] GenerateCirclePoints(Transform center, Vector3 target, float radius = 5f, int numberOfPoints = 10, float maxDeviation = .5f, bool clockwise = true)
    {
        if (center == null)
            return null;

        var circlePoints = new Vector3[numberOfPoints];
        var angleIncrement = 2f * Mathf.PI / numberOfPoints;

        // Hedefe en yakýn bir baþlangýç açýsýný hesaplayalým
        float minDistance = float.MaxValue;
        int nearestIndex = 0;

        for (int i = 0; i < numberOfPoints; i++)
        {
            float angle = i * angleIncrement;
            float deviation = Random.Range(-maxDeviation, maxDeviation);
            float x = center.position.x + (radius + deviation) * Mathf.Cos(angle);
            float z = center.position.z + (radius + deviation) * Mathf.Sin(angle);
            circlePoints[i] = new Vector3(x, center.position.y, z);

            float distance = Vector3.Distance(target, circlePoints[i]);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestIndex = i;
            }
        }

        // Noktalarý en yakýn konumdan baþlayacak þekilde sýralayalým
        var reorderedPoints = new Vector3[numberOfPoints];
        for (int i = 0; i < numberOfPoints; i++)
        {
            int index = clockwise ? (nearestIndex + i) % numberOfPoints : (nearestIndex - i + numberOfPoints) % numberOfPoints;
            reorderedPoints[i] = circlePoints[index];
        }

        return reorderedPoints;
    }

    public static Vector3[] GenerateCirclePointsVersion2(Vector3 start, Vector3 end, float? radius = null, int numberOfPoints = 10, float maxDeviation = .5f)
    {
        Vector3 center = (start + end) / 2; // Ortalama ile merkez noktayý hesapla

        if (!radius.HasValue)
        {
            radius = Vector3.Distance(start, center); // Yarýçapý hesapla eðer deðer verilmediyse
        }

        var circlePoints = new Vector3[numberOfPoints];
        var angleIncrement = Mathf.PI / (numberOfPoints - 1); // Sadece yarým daire için deðeri ayarladýk

        // Start noktasýna en yakýn bir baþlangýç açýsýný hesaplayalým
        Vector3 startDirection = (start - center).normalized;
        float startAngle = Mathf.Atan2(startDirection.z, startDirection.x);

        for (int i = 0; i < numberOfPoints; i++)
        {
            float angle = startAngle + i * angleIncrement;
            float deviation = Random.Range(-maxDeviation, maxDeviation);
            float x = center.x + (radius.Value + deviation) * Mathf.Cos(angle);
            float z = center.z + (radius.Value + deviation) * Mathf.Sin(angle);
            circlePoints[i] = new Vector3(x, center.y, z);
        }

        return circlePoints;
    }

    public static Vector3[] GenerateCirclePointsVersion3(Mesh targetMesh, Vector3 start, Vector3 end, float? radius = null, int numberOfPoints = 10, float maxDeviation = .5f)
    {
        Vector3 meshCenter = targetMesh.bounds.center;
        Vector3 center = (start + end) / 2; // Ortalama ile merkez noktayý hesapla

        // Mesh merkezinin baþlangýç noktasýna olan yönü
        Vector3 directionFromMeshCenter = (center - meshCenter).normalized;

        // Yarýçapý hesapla eðer deðer verilmediyse
        if (!radius.HasValue)
        {
            radius = Vector3.Distance(start, center);
        }

        // Yarýçapý mesh'in merkezinin zýttý yönünde ayarla
        center = meshCenter + directionFromMeshCenter * radius.Value;

        var circlePoints = new Vector3[numberOfPoints];
        var angleIncrement = Mathf.PI / (numberOfPoints - 1); // Sadece yarým daire için deðeri ayarladýk

        // Start noktasýna en yakýn bir baþlangýç açýsýný hesaplayalým
        Vector3 startDirection = (start - center).normalized;
        float startAngle = Mathf.Atan2(startDirection.z, startDirection.x);

        for (int i = 0; i < numberOfPoints; i++)
        {
            float angle = startAngle + i * angleIncrement;
            float deviation = Random.Range(-maxDeviation, maxDeviation);
            float x = center.x + (radius.Value + deviation) * Mathf.Cos(angle);
            float z = center.z + (radius.Value + deviation) * Mathf.Sin(angle);
            circlePoints[i] = new Vector3(x, center.y, z);
        }

        return circlePoints;
    }

}
