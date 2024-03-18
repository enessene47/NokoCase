using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManagers : MonoSingleton<AIManagers>
{
    [HideInInspector] public enum AIState { Wait, CollectUnprocessedProduct, DropUnprocessedProduct, CollectTransformedProduct, DropTransformedProduct }

    public ProductArea collectUnprocessedArea;

    public ProductArea dropUnprocessedArea;

    public ProductArea collectTransformedArea;

    public ProductArea dropTransformedArea;

    public AIState GetAIState(AICharacter ai)
    {
        AIState state = ai.AIActiveTaskState;

        if(state == AIState.Wait)
        {
            if(ai.CollectedProduct.Count == 0)
            {
                if (collectUnprocessedArea.AINeed)
                    return AIState.CollectUnprocessedProduct;
                else if (collectUnprocessedArea.AINeed)
                    return AIState.CollectUnprocessedProduct;
            }
            else if(ai.CollectedProduct.Count < ai.ProductMaxStackCount) 
            {
                if(ai.CollectedProduct.Peek().ProtuctType == Constants.ProductType.Unprocessed)
                    return AIState.CollectUnprocessedProduct;
                else if(ai.CollectedProduct.Peek().ProtuctType == Constants.ProductType.Transformed)
                    return AIState.CollectTransformedProduct;
            }
            else
            {
                if (ai.CollectedProduct.Peek().ProtuctType == Constants.ProductType.Unprocessed)
                    return AIState.DropUnprocessedProduct;
                else if (ai.CollectedProduct.Peek().ProtuctType == Constants.ProductType.Transformed)
                    return AIState.DropTransformedProduct;
            }

        }
        else if(state == AIState.CollectUnprocessedProduct)
        {
            if (ai.CollectedProduct.Count < ai.ProductMaxStackCount)
                return state;
            else if(dropUnprocessedArea.AINeed)
                return AIState.DropUnprocessedProduct;
        }
        else if(state == AIState.DropUnprocessedProduct)
        {
            if (ai.CollectedProduct.Count > 0)
                return state;
            else if(collectTransformedArea.AINeed)
                return AIState.CollectTransformedProduct;
        }
        else if(state == AIState.CollectTransformedProduct)
        {
            if (ai.CollectedProduct.Count < ai.ProductMaxStackCount)
                return state;
            else if(dropTransformedArea.AINeed)
                return AIState.DropTransformedProduct;
        }
        else if(state == AIState.DropTransformedProduct)
        {
            if (ai.CollectedProduct.Count > 0)
                return state;
            else if(collectUnprocessedArea.AINeed)
                return AIState.CollectUnprocessedProduct;
        }

        return AIState.Wait;
    }

    public Transform GetAITarget(AICharacter ai)
    {
        if(ai.AIActiveTaskState == AIState.CollectUnprocessedProduct)
            return collectUnprocessedArea.transform;
        else if (ai.AIActiveTaskState == AIState.DropUnprocessedProduct)
            return dropUnprocessedArea.transform;
        else if (ai.AIActiveTaskState == AIState.CollectTransformedProduct)
            return collectTransformedArea.transform;
        else if (ai.AIActiveTaskState == AIState.DropTransformedProduct)
            return dropTransformedArea.transform;

        return null;
    }
}
