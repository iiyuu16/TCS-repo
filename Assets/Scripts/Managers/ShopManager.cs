using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private MoneyManager moneyManager;

    public ShopAugmentItem insuranceItem;
    public ShopAugmentItem multiplyingItem;
    public ShopAugmentItem hollowingItem;

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

    public void PurchaseHollowing()
    {
        hollowingItem.Purchase();
    }
}
