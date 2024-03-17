using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class RandomExtensions
{
    public static T GetRandomItem<T>(this List<T> list)
    {
        if (list == null || list.Count == 0)
            return default;

        int randomIndex = UnityEngine.Random.Range(0, list.Count);
        return list[randomIndex];
    }

    public static T GetRandomItem<T>(this T[] array)
    {
        if (array == null || array.Length == 0)
            return default;

        int randomIndex = UnityEngine.Random.Range(0, array.Length);
        return array[randomIndex];
    }

    private static System.Random rand = new System.Random();

    public static T RandomEnumValue<T>() where T : Enum
    {
        Array value = Enum.GetValues(typeof(T));

        return (T)value.GetValue(rand.Next(value.Length));
    }

    public static int FindIndexOfClosest(this List<Vector3> list, Vector3 targetPosition)
    {
        if (list == null || list.Count == 0)
            return -1; // List boþ olduðu durumda geçerli bir index bulunamaz.

        float closestDistanceSqr = float.MaxValue; // Baþlangýçta en yakýn mesafeyi sonsuz olarak ayarlýyoruz.
        int closestIndex = -1; // Baþlangýçta en yakýn index'i geçerli olmayan bir deðer olarak ayarlýyoruz.

        for (int i = 0; i < list.Count; i++)
        {
            float distanceSqr = (list[i] - targetPosition).sqrMagnitude;
            if (distanceSqr < closestDistanceSqr)
            {
                closestDistanceSqr = distanceSqr;
                closestIndex = i;
            }
        }

        return closestIndex; // En yakýn pozisyonun index'ini döndürüyoruz.
    }
}
