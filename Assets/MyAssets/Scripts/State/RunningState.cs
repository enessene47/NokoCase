
public class RunningState : ICharacterState
{
    public void EnterState(Character controller)
    {
        controller.GetCharacteAnimator.SetBool("isRunning", true);
    }

    public void UpdateState(Character controller)
    {
        if (!controller.IsMoving)
        {
            controller.TransitionToState(controller.IdleState);
        }
    }
}