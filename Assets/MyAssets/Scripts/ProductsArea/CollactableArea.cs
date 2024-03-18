
public sealed class CollactableArea : ProductArea, ICollactable
{
    public override void CharacterInteraction(Character character)
    {
        if (products.Count == 0)
            return;

        if (!character.Collectable(products.Peek().ProtuctType))
            return;

        var product = Collect();

        if(product != null )
            character.ProductCollect(product);
    }

    public Product Collect()
    {
        return products.Pop();
    }
}
