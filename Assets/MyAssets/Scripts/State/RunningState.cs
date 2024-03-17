
public class RunningState : ICharacterState
{
    public void EnterState(Character controller)
    {
        controller.Animator.SetBool("isRunning", true);
    }

    public void UpdateState(Character controller)
    {
        if (!controller.IsMoving)
        {
            controller.TransitionToState(controller.IdleState);
        }
    }
}