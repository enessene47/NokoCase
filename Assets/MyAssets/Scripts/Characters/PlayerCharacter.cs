using UnityEngine;

public sealed class PlayerCharacter : Character
{
    [Header("PlayerCharacter")]

    [SerializeField] private Joystick _joystick;

    [SerializeField] private Transform _characterModel;

    protected override void Start()
    {
        base.Start();
    }

    private void FixedUpdate()
    {
        Vector3 movementDirection = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        if (movementDirection != Vector3.zero)
        {
            Move();

            IsMoving = true;

            RotateCharacterModel(movementDirection);
        }
        else
            IsMoving = false;
    }

    private void RotateCharacterModel(Vector3 direction)
    {
        Quaternion newRotation = Quaternion.LookRotation(direction);

        _characterModel.rotation = Quaternion.Slerp(_characterModel.rotation, newRotation, rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {
        Rigidbody.MovePosition(Rigidbody.position + _characterModel.forward * movementSpeed * Time.fixedDeltaTime);
    }
}
