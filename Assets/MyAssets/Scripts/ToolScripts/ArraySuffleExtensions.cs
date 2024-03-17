using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ArraySuffleExtensions
{
    public static T[] Shuffle<T>(this T[] array)
    {
        var random = new System.Random();

        T[] shuffledArray = array.OrderBy(x => random.Next()).ToArray();

        return shuffledArray;
    }

    public static T[] Shuffle<T>(this List<T> array)
    {
        var random = new System.Random();

        T[] shuffledArray = array.OrderBy(x => random.Next()).ToArray();

        return shuffledArray;
    }

    public static void SetTrue(this GameObject gameObject) => gameObject.SetActive(true);
    public static void SetTrue(this Transform transform) => transform.gameObject.SetActive(true);

    public static void SetFalse(this GameObject gameObject) => gameObject.SetActive(false);
    public static void SetFalse(this Transform transform) => transform.gameObject.SetActive(false);

    public static void AllSetActive(this List<GameObject> gameObjects, bool state)
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(state);
        }
    }

    public static void AllSetActive(this List<Transform> transforms, bool state)
    {
        foreach (var transform in transforms)
        {
            transform.gameObject.SetActive(state);
        }
    }

    public static void AllSetActive(this GameObject[] gameObjects, bool state)
    {
        foreach (var gameObject in gameObjects)
        {
            gameObject.SetActive(state);
        }
    }

    public static void AllSetActive(this Transform[] transforms, bool state)
    {
        foreach (var transform in transforms)
        {
            transform.gameObject.SetActive(state);
        }
    }
}
