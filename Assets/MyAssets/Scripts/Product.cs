using DG.Tweening;
using System;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Product : CustomManager
{
    [SerializeField] protected Constants.ProductType _protuctType;

    [SerializeField] protected Vector3 baseRotation;

    [SerializeField] protected Vector3 baseScale;

    [SerializeField] private float characterSpacingUp;

    public Constants.ProductType ProtuctType => _protuctType;

    public float CharacterSpacingUp => characterSpacingUp;

    public void SetBaseTransform()
    {
        transform.parent = null;

        transform.localScale = baseScale;

        transform.rotation = Quaternion.Euler(baseRotation);
    }

    public void AddProductToStackWithJump(Vector3 targetPosition, Action pushStack = null)
    {
        float jumpPower = 2f;

        int numJumps = 1;

        transform.DOLocalRotate(baseRotation, .5f).SetEase(Ease.Linear);

        transform.DOLocalJump(targetPosition, jumpPower, numJumps, .5f).OnComplete(() =>
        {
            if(pushStack != null)
            {
                pushStack();
            }
        });
    }
}