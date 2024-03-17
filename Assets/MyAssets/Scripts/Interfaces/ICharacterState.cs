using UnityEngine;

public interface ICharacterState
{
    void EnterState(Character controller);
    void UpdateState(Character controller);
}
