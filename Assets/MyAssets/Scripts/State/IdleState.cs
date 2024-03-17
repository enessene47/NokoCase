
public class IdleState : ICharacterState
{
    public void EnterState(Character controller)
    {
        controller.Animator.SetBool("isRunning", false);
    }


    public void UpdateState(Character controller)
    {
        if (controller.IsMoving)
        {
            controller.TransitionToState(controller.RunningState);
        }
    }
}