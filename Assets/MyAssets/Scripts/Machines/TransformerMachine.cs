using System.Collections;
using UnityEngine;

public sealed class TransformerMachine : Machine
{
    [Header("TransformerMachine")]
    [SerializeField] private ProductArea _productDroppableArea;

    protected override void Start()
    {
        base.Start();

        _productDroppableArea.ProductDropLimit = productionLimit;
    }

    protected override bool SetRun() => GameManager.Instance.GameActive && mainProductArea.products.Count < productionLimit && _productDroppableArea.products.Count > 0;

    protected override IEnumerator Production()
    {
        yield return null;

        while (GameManager.Instance.GameActive)
        {
            yield return new WaitForSeconds(productionSpeed);

            if (MachineRun)
            {
                smokeDark.Play();

                var product = _productDroppableArea.products.Pop();

                product.transform.SetParent(transform);

                product.AddProductToStackWithJump(Vector3.zero, () =>
                {
                    PoolManager.Instance.SetProductObject(product);

                    product = PoolManager.Instance.GetProductObject(mainProductArea.ProductType);

                    if (product != null)
                        mainProductArea.SettingProduct(product, transform.position);
                }
                );
            }
            else
                smokeDark.Stop();

            mainProductArea.AINeed = mainProductArea.products.Count > 0 ? true : false;

            _productDroppableArea.AINeed = _productDroppableArea.products.Count < productionLimit ? true : false;
        }
    }
}
