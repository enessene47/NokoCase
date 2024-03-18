
using UnityEngine;

public class Constants : MonoSingleton<Constants>
{
    public enum ProductType { Processed, Unprocessed, Transformed}

    [Header("Sheep Setting")]

    [Tooltip("Random point range")] public float wanderRadius = 100f;

    [Tooltip("Waiting time at target location")] public float wanderDelay = 5f;

    [Tooltip("Remaining distance threshold")] public float remainingDistanceThreshold = 1f;
}
