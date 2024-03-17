using System.Collections;
using UnityEngine;

public sealed class TrashBoxController : CustomManager
{
    [SerializeField] private ProductArea _productDroppableArea;

    [SerializeField] private float _destroySpeed;

    private void Start()
    {
        Observer.Instance.Start += () => StartCoroutine(RunDestroy());
    }

    private IEnumerator RunDestroy()
    {
       yield return null;

       while (GameManager.Instance.GameActive)
        {
            yield return new WaitForSeconds(_destroySpeed);

            if(_productDroppableArea.products.Count > 0)
            {
                var product = _productDroppableArea.products.Pop();

                if (product != null)
                {
                    product.gameObject.SetActive(false);

                    PoolManager.Instance.SetProductObject(product);
                }
            }
        }
    }
}
