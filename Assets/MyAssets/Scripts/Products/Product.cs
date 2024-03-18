using DG.Tweening;
using System;
using UnityEngine;

public abstract class Product : CustomManager
{
    [SerializeField] protected Constants.ProductType protuctType;

    [SerializeField] protected Vector3 baseRotation;

    [SerializeField] protected Vector3 baseScale;

    [SerializeField] protected float characterSpacingUp;

    public Constants.ProductType ProtuctType => protuctType;

    public float CharacterSpacingUp => characterSpacingUp;

    public void SetBaseTransform()
    {
        transform.parent = null;

        transform.localScale = baseScale;

        transform.rotation = Quaternion.Euler(baseRotation);
    }

    public void AddProductToStackWithJump(Vector3 targetPosition, Action act = null)
    {
        float jumpPower = 2f;

        int numJumps = 1;

        transform.DOLocalRotate(baseRotation, .5f).SetEase(Ease.Linear);

        transform.DOLocalJump(targetPosition, jumpPower, numJumps, .5f).OnComplete(() =>
        {
            if(act != null)
                act();
        });
    }
}