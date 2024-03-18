using System.Collections;
using UnityEngine;

public abstract class Machine : CustomManager
{
    [Header("Machine")]

    [SerializeField] protected Constants.ProductType productionType;

    [SerializeField] protected int productionLimit;

    [SerializeField] protected float productionSpeed;

    [SerializeField] protected Animator productionAnimator;

    [SerializeField] protected ProductArea mainProductArea;

    [SerializeField] protected ParticleSystem smokeDark;    
    

    public bool MachineRun {  get; private set; }

    protected virtual void Start()
    {
        Observer.Instance.Start += () => StartCoroutine(Production());

        mainProductArea.ProductDropLimit = productionLimit;
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
            if(MachineRun)
            {
                smokeDark.Play();

                var product = PoolManager.Instance.GetProductObject(productionType);

                if (product != null)
                    mainProductArea.SettingProduct(product, transform.position);
            }
            else
                smokeDark.Stop();

            mainProductArea.AINeed = mainProductArea.products.Count > 0 ? true : false;

            yield return new WaitForSeconds(productionSpeed);
        }
    }
}
