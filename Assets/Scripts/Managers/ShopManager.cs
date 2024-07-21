using UnityEngine;

public class ShopManager : MonoBehaviour
{
    private MoneyManager moneyManager;
    private AugmentManager augmentManager;

    public float priceMultiplier = 1;

    void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        augmentManager = FindObjectOfType<AugmentManager>();
    }

    public void PurchaseInsurance()
    {
        if (CanAfford(2000))
        {
            moneyManager.SpendMoney(GetAdjustedPrice(2000));

            augmentManager.isInsuranceBought = true;
            augmentManager.isAugmentless = false;
            augmentManager.SaveAugments();
        }
    }

    public void PurchaseMultiplying()
    {
        if (CanAfford(1200))
        {
            moneyManager.SpendMoney(GetAdjustedPrice(1200));

            augmentManager.isMultiplyingBought = true;
            augmentManager.isAugmentless = false;
            augmentManager.SaveAugments();
        }
    }

    public void PurchaseHollowing()
    {
        if (CanAfford(1500))
        {
            moneyManager.SpendMoney(GetAdjustedPrice(1500));

            augmentManager.isHollowingBought = true;
            augmentManager.isAugmentless = false;
            augmentManager.SaveAugments();
        }
    }

    private bool CanAfford(int basePrice)
    {
        return moneyManager.GetCurrentMoney() >= GetAdjustedPrice(basePrice);
    }

    private int GetAdjustedPrice(int basePrice)
    {
        return Mathf.RoundToInt(basePrice * priceMultiplier);
    }
}
