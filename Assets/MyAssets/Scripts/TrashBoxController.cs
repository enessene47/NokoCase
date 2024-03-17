using DG.Tweening;
using System.Collections;
using UnityEngine;

public sealed class TrashBoxController : CustomManager
{
    [SerializeField] private ProductArea _productDroppableArea;

    [SerializeField] private Transform _view;

    [SerializeField] private float _destroySpeed;

    [Header("DoShake Settings")]

    [Tooltip("Swing duration")] [SerializeField] private float duration = 1f;

    [Tooltip(" Swing strength")] [SerializeField] private float strength = 0.5f;

    [Tooltip("Swing frequency")] [SerializeField] private int vibrato = 10;

    [Tooltip("Randomness of the swing")] [SerializeField] private float randomness = 90;

    [Tooltip("Whether to round the position to integer values")] [SerializeField] private bool snapping = false;

    [Tooltip("Whether to slow down towards the end of the swing")] [SerializeField] private bool fadeOut = true;

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

                product.transform.SetParent(transform);

                product.AddProductToStackWithJump(Vector3.zero, () =>
                {
                    product.gameObject.SetActive(false);

                    PoolManager.Instance.SetProductObject(product);

                    _view.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut);
                }
                );
            }
        }
    }
}
