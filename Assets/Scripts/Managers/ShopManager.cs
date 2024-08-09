using DialogueEditor;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    private MoneyManager moneyManager;
    private AugmentManager augmentManager;

    public float priceMultiplier = 1;

    public GameObject notEnoughMoneyObject;
    public GameObject transactionDeniedObject;
    public GameObject convoManagerObj;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        moneyManager = FindObjectOfType<MoneyManager>();
        augmentManager = FindObjectOfType<AugmentManager>();
    }

    public void PurchaseInsurance()
    {
        int price = GetAdjustedPrice(2000);
        Debug.Log("Attempting to purchase Insurance Augment. Price: " + price + ", Current Money: " + moneyManager.GetCurrentMoney());

        if (augmentManager.isInsuranceBought)
        {
            ShowTransactionDenied();
            return;
        }

        if (CanAfford(price))
        {
            moneyManager.SpendMoney(price);
            augmentManager.isInsuranceBought = true;

            augmentManager.isInsuranceActive = true;
            augmentManager.isMultiplyingActive = false;
            augmentManager.isHollowingActive = false;

            augmentManager.isAugmentless = false;
            augmentManager.SaveAugments();

            convoManagerObj.SetActive(true);
            augmentManager.DisplayCurrentAugments();
        }
        else
        {
            ShowNotEnoughMoney();
            convoManagerObj.SetActive(false);
        }
    }

    public void PurchaseMultiplying()
    {
        int price = GetAdjustedPrice(1200);
        Debug.Log("Attempting to purchase Multiplying Augment. Price: " + price + ", Current Money: " + moneyManager.GetCurrentMoney());

        if (augmentManager.isMultiplyingBought)
        {
            ShowTransactionDenied();
            return;
        }

        if (CanAfford(price))
        {
            moneyManager.SpendMoney(price);
            augmentManager.isMultiplyingBought = true;

            augmentManager.isMultiplyingActive = true;
            augmentManager.isInsuranceActive = false;
            augmentManager.isHollowingActive = false;

            augmentManager.isAugmentless = false;
            augmentManager.SaveAugments();

            convoManagerObj.SetActive(true);
            augmentManager.DisplayCurrentAugments();
        }
        else
        {
            ShowNotEnoughMoney();
            convoManagerObj.SetActive(false);
        }
    }

    public void PurchaseHollowing()
    {
        int price = GetAdjustedPrice(1500);
        Debug.Log("Attempting to purchase Hollowing Augment. Price: " + price + ", Current Money: " + moneyManager.GetCurrentMoney());

        if (augmentManager.isHollowingBought)
        {
            ShowTransactionDenied();
            return;
        }

        if (CanAfford(price))
        {
            moneyManager.SpendMoney(price);
            augmentManager.isHollowingBought = true;

            augmentManager.isHollowingActive = true;
            augmentManager.isMultiplyingActive = false;
            augmentManager.isInsuranceActive = false;

            augmentManager.isAugmentless = false;
            augmentManager.SaveAugments();

            convoManagerObj.SetActive(true);
            augmentManager.DisplayCurrentAugments();
        }
        else
        {
            ShowNotEnoughMoney();
            convoManagerObj.SetActive(false);
        }
    }

    private bool CanAfford(int price)
    {
        return moneyManager.GetCurrentMoney() >= price;
    }

    private int GetAdjustedPrice(int basePrice)
    {
        return Mathf.RoundToInt(basePrice * priceMultiplier);
    }

    private void ShowNotEnoughMoney()
    {
        if (notEnoughMoneyObject != null)
        {
            convoManagerObj.SetActive(false);
            notEnoughMoneyObject.SetActive(true);
        }
        if (transactionDeniedObject != null)
        {
            transactionDeniedObject.SetActive(false);
        }
    }

    private void ShowTransactionDenied()
    {
        if (notEnoughMoneyObject != null)
        {
            notEnoughMoneyObject.SetActive(false);
        }
        if (transactionDeniedObject != null)
        {
            convoManagerObj.SetActive(false);
            transactionDeniedObject.SetActive(true);
        }
    }
}
