using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacter : Character
{
    [SerializeField] private NavMeshAgent _agent;

    public AIManagers.AIState AIActiveTaskState { get; private set; }

    public Stack<Product> CollectedProduct => collectedProduct;

    public int ProductMaxStackCount => productMaxStackCount;

    private Transform _targetTransform;

    public override bool Collectable(Constants.ProductType productType) => (collectedProduct.Count == 0 || collectedProduct.Peek().ProtuctType == productType) && collectedProduct.Count < productMaxStackCount && _agent.isStopped;

    public override bool Droppable(Constants.ProductType productType) => collectedProduct.Count > 0 && collectedProduct.Peek().ProtuctType == productType && _agent.isStopped;

    protected override void Start()
    {
        base.Start();

        AIActiveTaskState = AIManagers.AIState.Wait;

        _agent.speed = movementSpeed;

        _agent.angularSpeed = rotationSpeed;
    }

    private void LateUpdate()
    {
        AIActiveTaskState = AIManagers.Instance.GetAIState(this);

        _targetTransform = AIManagers.Instance.GetAITarget(this);

        if (_targetTransform != null)
        {
            _agent.SetDestination(_targetTransform.position);

            _agent.isStopped = false;

            if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
                _agent.isStopped = true;
        }
        else
            _agent.isStopped = true;

        IsMoving = !_agent.isStopped;
    }
}
