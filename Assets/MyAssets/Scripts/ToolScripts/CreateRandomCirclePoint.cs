using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CreateRandomCirclePoint
{
    public static Vector3 GenerateRandomCirclePoint(Vector3 center, float radius)
    {
        var ang = Random.value * 360;

        Vector3 pos;

        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);

        pos.y = -2f;

        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);

        return pos;
    }
}
