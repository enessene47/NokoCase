using UnityEngine;

public abstract class Product : CustomManager
{
    [SerializeField] protected Constants.ProductType _protuctType;

    [SerializeField] protected Vector3 baseRotation;

    [SerializeField] protected Vector3 baseScale;

    public Constants.ProductType ProtuctType => _protuctType;

    public void SetBaseTransform()
    {
        transform.parent = null;

        transform.localScale = baseScale;

        transform.rotation = Quaternion.Euler(baseRotation);
    }
}