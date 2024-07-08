using UnityEngine;

public class ShopAugmentItem : MonoBehaviour
{
    public string augmentName;
    public int augmentPrice;

    private MoneyManager moneyManager;

    void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
    }

    public void Purchase()
    {
        if (moneyManager.SpendMoney(augmentPrice))
        {
            Debug.Log("Purchased augment: " + augmentName);
            // Additional logic for when the augment is purchased
        }
        else
        {
            Debug.Log("Failed to purchase augment: " + augmentName);
        }
    }
}
