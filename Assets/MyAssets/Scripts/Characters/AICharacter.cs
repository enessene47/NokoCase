using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : Character
{
    private Transform _targetTransform;

    public AIManagers.AIState AIActiveTaskState { get; private set; }

    public Stack<Product> CollectedProduct => collectedProduct;

    public int ProductMaxStackCount => productMaxStackCount;

    public override bool Collectable(Constants.ProductType productType) => (collectedProduct.Count == 0 || collectedProduct.Peek().ProtuctType == productType) && collectedProduct.Count < productMaxStackCount && NavMeshAgent.isStopped;

    public override bool Droppable(Constants.ProductType productType) => collectedProduct.Count > 0 && collectedProduct.Peek().ProtuctType == productType && NavMeshAgent.isStopped;

    protected override void Start()
    {
        base.Start();

        AIActiveTaskState = AIManagers.AIState.Wait;

        NavMeshAgent.speed = movementSpeed;

        NavMeshAgent.angularSpeed = rotationSpeed;
    }

    private void LateUpdate()
    {
        AIActiveTaskState = AIManagers.Instance.GetAIState(this);

        _targetTransform = AIManagers.Instance.GetAITarget(this);

        if (_targetTransform != null)
        {
            NavMeshAgent.SetDestination(_targetTransform.position);

            NavMeshAgent.isStopped = false;

            if (!NavMeshAgent.pathPending && NavMeshAgent.remainingDistance <= NavMeshAgent.stoppingDistance)
                NavMeshAgent.isStopped = true;
        }
        else
            NavMeshAgent.isStopped = true;

        IsMoving = !NavMeshAgent.isStopped;
    }
}
