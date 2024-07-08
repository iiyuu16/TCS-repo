using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private MoneyManager moneyManager;

    public ShopAugmentItem insuranceItem;
    public ShopAugmentItem multiplyingItem;
    public ShopAugmentItem reversalItem;

    void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    public void PurchaseInsurance()
    {
        insuranceItem.Purchase();
    }

    public void PurchaseMultiplying()
    {
        multiplyingItem.Purchase();
    }

    public void PurchaseReversal()
    {
        reversalItem.Purchase();
    }
}
