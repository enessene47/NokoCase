using UnityEngine;

public sealed class DroppableArea : ProductArea, IDroppable
{
    public override void CharacterInteraction(Character character)
    {
        Debug.Log(character.Droppable(ProductType));

        if(character.Droppable(ProductType))
            Drop(character.ProductDrop());
    }

    public void Drop(Product product)
    {
        if (product == null)
            return;

        SettingProduct(product);
    }

}
