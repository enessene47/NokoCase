using System.Collections;
using UnityEngine;

public sealed class TransformerMachine : Machine
{
    [Header("TransformerMachine")]
    [SerializeField] private ProductArea _productDroppableArea;

    protected override bool SetRun() => GameManager.Instance.GameActive && productCollactableArea.products.Count < productionLimit && _productDroppableArea.products.Count > 0;

    protected override IEnumerator Production()
    {
        yield return null;

        while (GameManager.Instance.GameActive)
        {
            yield return new WaitForSeconds(productionSpeed);

            if (MachineRun)
            {
                var product = _productDroppableArea.products.Pop();

                PoolManager.Instance.SetProductObject(product);

                product = PoolManager.Instance.GetProductObject(productCollactableArea.ProductType);

                if (product != null)
                    productCollactableArea.SettingProduct(product);
            }
        }
    }
}
