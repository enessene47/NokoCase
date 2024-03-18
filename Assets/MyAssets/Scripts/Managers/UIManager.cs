using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class UIManager : MonoSingleton<UIManager>
{
    [SerializeField] private GameObject _startPanel;

    [SerializeField] private GameObject _successPanel;

    [SerializeField] private GameObject _failPanel;

    private void Start()
    {
        Observer.Instance.Start += () => _startPanel.SetFalse();

        Observer.Instance.EndGame += (success) =>
        {
            if(success)
                _successPanel.SetTrue();
            else _failPanel.SetTrue();
        };

        _startPanel.SetTrue();
    }

    public void StartButton() => Observer.Instance.Start();
}
