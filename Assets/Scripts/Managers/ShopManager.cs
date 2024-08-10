using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public static ShopManager instance;

    private MoneyManager moneyManager;
    private AugmentManager augmentManager;

    public float shopMultiplier = 1f;

    public GameObject notEnoughMoneyObject;
    public GameObject transactionDeniedObject;
    public GameObject convoManagerObj;

    public TextMeshProUGUI insurancePriceText;
    public TextMeshProUGUI multiplyingPriceText;
    public TextMeshProUGUI hollowingPriceText;

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

        moneyManager = FindObjectOfType<MoneyManager>();
        if (moneyManager == null)
        {
            Debug.Log("MoneyManager instance not found in the scene. Money-related functions will not work.");
        }

        augmentManager = FindObjectOfType<AugmentManager>();
        if (augmentManager == null)
        {
            Debug.Log("AugmentManager instance not found in the scene. Augment-related functions will not work.");
        }

        if (SceneManager.GetActiveScene().name == "VisNov_Prologue")
        {
            moneyManager.ResetMoney();
            augmentManager.ResetAugPrices();
            augmentManager.LoadAugPrices();
            Debug.Log("check");
        }
        else
        {
            augmentManager.LoadAugPrices();
        }
    }
    public void Update()
    {
        showPrices();
    }

    public void showPrices()
    {
        if (insurancePriceText != null)
        {
            UpdatePriceDisplay(insurancePriceText, augmentManager.insuranceCurrentPrice);
        }
        else
        {
            Debug.LogWarning("insurancePriceText is not assigned in the Inspector.");
        }

        if (multiplyingPriceText != null)
        {
            UpdatePriceDisplay(multiplyingPriceText, augmentManager.multiplyingCurrentPrice);
        }
        else
        {
            Debug.LogWarning("multiplyingPriceText is not assigned in the Inspector.");
        }

        if (hollowingPriceText != null)
        {
            UpdatePriceDisplay(hollowingPriceText, augmentManager.hollowingCurrentPrice);
        }
        else
        {
            Debug.LogWarning("hollowingPriceText is not assigned in the Inspector.");
        }
    }

    public void PurchaseInsurance()
    {
        int price = GetAdjustedPrice(augmentManager.insuranceCurrentPrice);
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
        int price = GetAdjustedPrice(augmentManager.multiplyingCurrentPrice);
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
        int price = GetAdjustedPrice(augmentManager.hollowingCurrentPrice);
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
        if (moneyManager != null)
        {
            return moneyManager.GetCurrentMoney() >= price;
        }
        else
        {
            Debug.LogWarning("MoneyManager instance not found. Returning false for CanAfford.");
            return false;
        }
    }

    public void UpdatePriceDisplay(TextMeshProUGUI priceText, int basePrice)
    {
        int adjustedPrice = GetAdjustedPrice(basePrice);
        priceText.text = adjustedPrice.ToString();
    }

    private int GetAdjustedPrice(int basePrice)
    {
        return Mathf.RoundToInt(basePrice * shopMultiplier);
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