using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character")]

    [SerializeField] protected Rigidbody physics;

    [SerializeField] protected Animator animator;

    [SerializeField] protected Transform stackPoint;

    [SerializeField] protected float movementSpeed = 5.0f;

    [SerializeField] protected float rotationSpeed = 5.0f;

    [SerializeField] protected int productStackCount;

    [SerializeField] private float _interactionSpeed = 1.0f;
    
    public ICharacterState CurrentState;

    public ICharacterState IdleState = new IdleState();

    public ICharacterState RunningState = new RunningState();

    protected Stack<Product> collectedProduct = new();

    protected ProductArea productArea = null;

    private float _interactionTimeCounter = 0.0f;

    public Animator Animator { get { return animator; }}

    public bool IsMoving { get; set; }

    public bool Collectable(Constants.ProductType productType) => (collectedProduct.Count == 0 || collectedProduct.Peek().ProtuctType == productType) && collectedProduct.Count < productStackCount;
    public bool Droppable(Constants.ProductType productType) => collectedProduct.Count > 0 && collectedProduct.Peek().ProtuctType == productType;

    protected virtual void Start()
    {
        TransitionToState(IdleState);
    }

    void Update()
    {
        CurrentState.UpdateState(this);
    }

    public void ProductCollect(Product product)
    {
        collectedProduct.Push(product);

        product.gameObject.SetFalse();
    }

    public Product ProductDrop()
    {
        if (collectedProduct.Count == 0)
             return null;

        var product = collectedProduct.Pop();

        return product;
    }

    public void TransitionToState(ICharacterState state)
    {
        CurrentState = state;

        CurrentState.EnterState(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out ProductArea productArea))
        {
            this.productArea = productArea;

            _interactionTimeCounter = 0f;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(productArea != null)
        {
            _interactionTimeCounter += Time.deltaTime;

            if (_interactionTimeCounter >= _interactionSpeed)
            {
                productArea.CharacterInteraction(this);

                _interactionTimeCounter = 0f;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out ProductArea productArea))
            productArea = null;

    }
}
