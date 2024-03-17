using UnityEngine;

public static class ColorGradientHelper
{
    public static Color[] GenerateColorGradient(int arraySize, Color startColor, Color endColor)
    {
        Color[] colors = new Color[arraySize];

        Gradient gradient = new Gradient();
        GradientColorKey[] colorKeys = new GradientColorKey[2];
        colorKeys[0].color = startColor;
        colorKeys[0].time = 0.0f;
        colorKeys[1].color = endColor;
        colorKeys[1].time = 1.0f;

        GradientAlphaKey[] alphaKeys = new GradientAlphaKey[2];
        alphaKeys[0].alpha = 1.0f;
        alphaKeys[0].time = 0.0f;
        alphaKeys[1].alpha = 1.0f;
        alphaKeys[1].time = 1.0f;

        gradient.SetKeys(colorKeys, alphaKeys);

        for (int i = 0; i < arraySize; i++)
        {
            float t = (float)i / (arraySize - 1);
            colors[i] = gradient.Evaluate(t);
        }

        return colors;
    }

    public static Color GetColorByIndex(int arraySize, Color startColor, Color endColor, int index)
    {
        if (index < 0 || index >= arraySize)
        {
            Debug.LogWarning("Invalid index! Returning the startColor.");
            return startColor;
        }

        float t = (float)index / (arraySize - 1);
        Color interpolatedColor = Color.Lerp(startColor, endColor, t);
        return interpolatedColor;
    }
}
