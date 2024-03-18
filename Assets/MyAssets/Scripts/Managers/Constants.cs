
using UnityEngine;

public class Constants : MonoSingleton<Constants>
{
    public enum ProductType { Processed, Unprocessed, Transformed}


    [Header("Sheep Setting")]

    [Tooltip("Random point range")] public float wanderRadius = 100f;

    [Tooltip("Waiting time at target location")] public float wanderDelay = 5f;

    [Tooltip("Remaining distance threshold")] public float remainingDistanceThreshold = 1f;


    [Header("DoShake Settings")]

    [Tooltip("Swing duration")] public float duration = 1f;

    [Tooltip(" Swing strength")] public float strength = 0.5f;

    [Tooltip("Swing frequency")] public int vibrato = 10;

    [Tooltip("Randomness of the swing")] public float randomness = 90;

    [Tooltip("Whether to round the position to integer values")] public bool snapping = false;

    [Tooltip("Whether to slow down towards the end of the swing")] public bool fadeOut = true;
}
