using System.Collections.Generic;
using UnityEngine;

public abstract class ProductArea : CustomManager
{
    public Constants.ProductType ProductType;

    [Header("Production Spawn Setting")]

    [SerializeField] private Vector3 _spawnStartPoint;

    [SerializeField] private int _rows;

    [SerializeField] private int _columns;

    [SerializeField] private float _spacingRow;

    [SerializeField] private float _spacingColumn;

    [SerializeField] private float _spacingUp;

    public Stack<Product> products = new();

    public bool AINeed { get; set; }

    public int ProductDropLimit { get; set; }

    public abstract void CharacterInteraction(Character character);

    public void SettingProduct(Product product, Vector3 spawnPoint)
    {
        product.SetBaseTransform();

        product.transform.position = spawnPoint;

        int productCount = products.Count;

        int rowPoint = productCount % _rows;

        int columnPoint = (productCount / _rows) % _columns;

        int upPoint = productCount / (_rows * _columns);

        product.transform.SetParent(transform);

        Vector3 localPos = transform.right *- 1f * (columnPoint * _spacingRow) +
                           transform.forward * (rowPoint * _spacingColumn) +
                           transform.up * (upPoint * _spacingUp);

        localPos += _spawnStartPoint;

        product.gameObject.SetTrue();

        products.Push(product);

        product.AddProductToStackWithJump(localPos);
    }
}
