using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string purchase50 = "com.jordandavid.programmer-idle.50gems";
    private string purchase2500 = "com.jordandavid.programmer-idle.2500gems";

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == purchase50)
        {
            ResourcesManager.instance.AddGems(50);
        }
        else if (product.definition.id == purchase2500)
        {
            ResourcesManager.instance.AddGems(2500);
        }
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(failureReason);
    }
}
