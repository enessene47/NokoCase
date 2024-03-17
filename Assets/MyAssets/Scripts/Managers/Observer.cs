using System;

public sealed class Observer : MonoSingleton<Observer>
{
    public Action Start;

    public Action<bool> EndGame;
}
