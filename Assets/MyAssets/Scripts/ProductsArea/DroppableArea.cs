using UnityEngine;

public sealed class DroppableArea : ProductArea, IDroppable
{
    public override void CharacterInteraction(Character character)
    {
        if(character.Droppable(ProductType) && (ProductDropLimit == 0 || ProductDropLimit > products.Count))
            Drop(character.ProductDrop());
    }

    public void Drop(Product product)
    {
        if (product == null)
            return;

        SettingProduct(product, product.transform.position);
    }

}
