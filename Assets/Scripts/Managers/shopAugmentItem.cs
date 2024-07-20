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
            PlayerPrefs.SetInt(augmentName, 1);  // Mark augment as bought
            PlayerPrefs.Save();  // Save PlayerPrefs changes
        }
        else
        {
            Debug.Log("Failed to purchase augment: " + augmentName);
        }
    }
}
