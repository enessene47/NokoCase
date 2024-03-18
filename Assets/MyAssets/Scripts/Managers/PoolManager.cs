using System.Collections.Generic;
using UnityEngine;

public sealed class PoolManager : MonoSingleton<PoolManager>
{
    [SerializeField] private GameObject _processedObjectPrefab;

    [SerializeField] private GameObject _unprocessedObjectPrefab;

    [SerializeField] private GameObject _transformedObjectPrefab;

    [SerializeField] private int _productCount;

    private Queue<Product> _processedQueue = new();

    private Queue<Product> _unprocessedQueue = new();

    private Queue<Product> _transformedQueue = new();

    private void Awake()
    {
        CreatePoolObject(_processedQueue, _processedObjectPrefab, _productCount);

        CreatePoolObject(_unprocessedQueue, _unprocessedObjectPrefab, _productCount);

        CreatePoolObject(_transformedQueue, _transformedObjectPrefab, _productCount);
    }

    private void CreatePoolObject<T>(Queue<T> queue, GameObject prefab, int count = 1)
    {
        GameObject obj = null;

        for(int i = 0; i <= count; i++)
        {
            obj = Instantiate(prefab);

            obj.hideFlags = HideFlags.HideInHierarchy;

            obj.SetFalse();

            queue.Enqueue(obj.GetComponent<T>());
        }
    }

    public Product GetProductObject(Constants.ProductType productType)
    {
        switch(productType)
        {
            case Constants.ProductType.Processed:

                if(_processedQueue.Count == 0)
                    CreatePoolObject(_processedQueue, _processedObjectPrefab);

                return _processedQueue.Dequeue();

            case Constants.ProductType.Unprocessed:
                if (_unprocessedQueue.Count == 0)
                    CreatePoolObject(_unprocessedQueue, _unprocessedObjectPrefab);

                return _unprocessedQueue.Dequeue();

            case Constants.ProductType.Transformed:
                if (_transformedQueue.Count == 0)
                    CreatePoolObject(_transformedQueue, _transformedObjectPrefab);

                return _transformedQueue.Dequeue();

            default: return null;
        }
    }

    public void SetProductObject(Product product)
    {
        product.gameObject.SetFalse();

        switch (product.ProtuctType)
        {
            case Constants.ProductType.Processed:

                _processedQueue.Enqueue(product);

                break;

            case Constants.ProductType.Unprocessed:
                _unprocessedQueue.Enqueue(product);

                break;

            case Constants.ProductType.Transformed:
                _transformedQueue.Enqueue(product);

                break;
        }
    }
}
