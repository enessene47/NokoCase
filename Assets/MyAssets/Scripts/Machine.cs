using System.Collections;
using UnityEngine;

public abstract class Machine : CustomManager
{
    [Header("Machine")]

    [SerializeField] protected Constants.ProductType productionType;

    [SerializeField] protected int productionLimit;

    [SerializeField] protected float productionSpeed;

    [SerializeField] protected Animator productionAnimator;

    [SerializeField] protected ProductArea productCollactableArea;

    public bool MachineRun {  get; private set; }

    protected virtual void Start()
    {
        Observer.Instance.Start += () => StartCoroutine(Production());
    }

    private void Update()
    {
        MachineRun = SetRun();

        productionAnimator.SetBool("Run", MachineRun);
    }

    protected abstract bool SetRun();

    protected virtual IEnumerator Production()
    {
        yield return null;

        while(GameManager.Instance.GameActive)
        {
            yield return new WaitForSeconds(productionSpeed);

            if(MachineRun)
            {
                var product = PoolManager.Instance.GetProductObject(productionType);

                if (product != null)
                    productCollactableArea.SettingProduct(product);
            }
        }
    }
}
