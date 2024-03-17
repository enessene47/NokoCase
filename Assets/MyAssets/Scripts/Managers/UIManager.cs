using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private GameObject _startPanel;

    private void Start()
    {
        Observer.Instance.Start += () => _startPanel.SetFalse();

        _startPanel.SetTrue();
    }

    public void StartButton() => Observer.Instance.Start();
}
