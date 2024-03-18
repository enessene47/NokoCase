using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Character")]

    [SerializeField] protected Rigidbody physics;

    [SerializeField] protected Animator animator;

    [SerializeField] protected Transform stackPoint;

    [Header("Move Seetings")]

    [SerializeField] protected float movementSpeed = 5.0f;

    [SerializeField] protected float rotationSpeed = 5.0f;

    [Header("Stack Settings")]

    [SerializeField] protected int productMaxStackCount;

    [SerializeField] protected float interactionSpeed = .5f;

    [Header("Stack Tilt Settings")]

    [SerializeField] protected float tiltAngle = 10.0f;

    [SerializeField] protected float lerpSpeed = 5.0f;

    public ICharacterState CurrentState;

    public ICharacterState IdleState = new IdleState();

    public ICharacterState RunningState = new RunningState();

    protected Stack<Product> collectedProduct = new();

    protected ProductArea productArea = null;

    protected Quaternion startRotation;

    protected Quaternion targetRotation;

    private float _interactionTimeCounter = 0.0f;

    public Animator Animator { get { return animator; }}

    public bool IsMoving { get; set; }

    public virtual bool Collectable(Constants.ProductType productType) => (collectedProduct.Count == 0 || collectedProduct.Peek().ProtuctType == productType) && collectedProduct.Count < productMaxStackCount;
    public virtual bool Droppable(Constants.ProductType productType) => collectedProduct.Count > 0 && collectedProduct.Peek().ProtuctType == productType;

    protected virtual void Start()
    {
        TransitionToState(IdleState);

        startRotation = transform.localRotation;
    }

    void Update()
    {
        CurrentState.UpdateState(this);

        targetRotation = IsMoving ? Quaternion.Euler(-tiltAngle, 0, 0) : startRotation;

        stackPoint.localRotation = Quaternion.Lerp(stackPoint.localRotation, targetRotation, Time.deltaTime * lerpSpeed);
    }

    public void ProductCollect(Product product)
    {
        product.transform.SetParent(stackPoint);

        collectedProduct.Push(product);

        product.AddProductToStackWithJump(Vector3.zero + Vector3.up * collectedProduct.Count * product.CharacterSpacingUp);
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

            if (_interactionTimeCounter >= interactionSpeed)
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
