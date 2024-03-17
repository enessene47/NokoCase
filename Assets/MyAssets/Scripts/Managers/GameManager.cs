using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class GameManager : MonoSingleton<GameManager>
{
    public bool GameActive { get; private set; }

    private void Awake()
    {
        Time.timeScale = 1f;
    }

    private void Start()
    {
        Observer.Instance.Start += () => GameActive = true;
    }
}
