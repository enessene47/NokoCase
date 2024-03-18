
public class IdleState : ICharacterState
{
    public void EnterState(Character controller)
    {
        controller.GetCharacteAnimator.SetBool("isRunning", false);
    }


    public void UpdateState(Character controller)
    {
        if (controller.IsMoving)
        {
            controller.TransitionToState(controller.RunningState);
        }
    }
}