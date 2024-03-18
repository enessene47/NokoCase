using DG.Tweening;
using System.Collections;
using UnityEngine;

public sealed class TrashBoxMachine : Machine
{
    [SerializeField] private ProductArea _productDroppableArea;

    [SerializeField] private Transform _view;

    [SerializeField] private float _destroySpeed;

    protected override bool SetRun() => _productDroppableArea.products.Count > 0;

    protected override IEnumerator Production()
    {
        yield return null;

        while (GameManager.Instance.GameActive)
        {
            yield return new WaitForSeconds(productionSpeed);

            if (MachineRun)
            {
                var product = _productDroppableArea.products.Pop();

                product.transform.SetParent(transform);

                product.AddProductToStackWithJump(Vector3.zero, () =>
                {
                    product.gameObject.SetActive(false);

                    PoolManager.Instance.SetProductObject(product);
                }
                );
            }

            mainProductArea.AINeed = mainProductArea.products.Count < productionLimit ? true : false;
        }
    }
}
