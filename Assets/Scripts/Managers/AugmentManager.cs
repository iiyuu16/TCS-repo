using UnityEngine;
using TMPro;

public class AugmentManager : MonoBehaviour
{
    public static AugmentManager instance;
    public TextMeshProUGUI[] augStatusTexts;

    [Header("Insurance Augment")]
    public bool isInsuranceBought;
    public bool isInsuranceActive;
    public bool isInsuranceOnEffect;

    [Header("Multiplying Augment")]
    public bool isMultiplyingBought;
    public bool isMultiplyingActive;
    public bool isMultiplyingOnEffect;

    [Header("Hollowing Augment")]
    public bool isHollowingBought;
    public bool isHollowingActive;
    public bool isHollowingOnEffect;

    [Header("Augmentless")]
    public bool isAugmentless = true;

    [Header("Starting Prices")]
    public static int insuranceStartingPrice = 2000;
    public static int multiplyingStartingPrice = 1500;
    public static int hollowingStartingPrice = 1800;

    [Header("Current Prices")]
    public int insuranceCurrentPrice;
    public int multiplyingCurrentPrice;
    public int hollowingCurrentPrice;

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

    private void Start()
    {
        LoadAugments();
    }

    public void ResetAugPrices()
    {
        insuranceCurrentPrice = insuranceStartingPrice;
        multiplyingCurrentPrice = multiplyingStartingPrice;
        hollowingCurrentPrice = hollowingStartingPrice;
        Debug.Log("i =" + insuranceCurrentPrice);
        Debug.Log("m =" + multiplyingCurrentPrice);
        Debug.Log("h =" + hollowingCurrentPrice);
    }

    public void SaveAugPrices()
    {
        PlayerPrefs.SetInt("InsuranceCurrentPrice", insuranceCurrentPrice);
        PlayerPrefs.SetInt("MultiplyingCurrentPrice", multiplyingCurrentPrice);
        PlayerPrefs.SetInt("HollowingCurrentPrice", hollowingCurrentPrice);

        PlayerPrefs.Save();
        Debug.Log("Augment prices saved");
    }

    public void LoadAugPrices()
    {
        insuranceCurrentPrice = PlayerPrefs.GetInt("InsuranceCurrentPrice", insuranceStartingPrice);
        multiplyingCurrentPrice = PlayerPrefs.GetInt("MultiplyingCurrentPrice", multiplyingStartingPrice);
        hollowingCurrentPrice = PlayerPrefs.GetInt("HollowingCurrentPrice", hollowingStartingPrice);

        Debug.Log("Augment prices loaded");
        SaveAugPrices();
    }

    public void LoadAugments()
    {
        isInsuranceBought = PlayerPrefs.GetInt("InsuranceBought", 0) == 1;
        isInsuranceActive = PlayerPrefs.GetInt("InsuranceActive", 0) == 1;
        isInsuranceOnEffect = PlayerPrefs.GetInt("InsuranceOnEffect", 0) == 1;

        isMultiplyingBought = PlayerPrefs.GetInt("MultiplyingBought", 0) == 1;
        isMultiplyingActive = PlayerPrefs.GetInt("MultiplyingActive", 0) == 1;
        isMultiplyingOnEffect = PlayerPrefs.GetInt("MultiplyingOnEffect", 0) == 1;

        isHollowingBought = PlayerPrefs.GetInt("HollowingBought", 0) == 1;
        isHollowingActive = PlayerPrefs.GetInt("HollowingActive", 0) == 1;
        isHollowingOnEffect = PlayerPrefs.GetInt("HollowingOnEffect", 0) == 1;

        isAugmentless = PlayerPrefs.GetInt("Augmentless", 0) == 1;

        DisplayCurrentAugments();
        Debug.Log("loaded augs");
    }

    public void SaveAugments()
    {
        PlayerPrefs.SetInt("InsuranceBought", isInsuranceBought ? 1 : 0);
        PlayerPrefs.SetInt("InsuranceActive", isInsuranceActive ? 1 : 0);
        PlayerPrefs.SetInt("InsuranceOnEffect", isInsuranceOnEffect ? 1 : 0);

        PlayerPrefs.SetInt("MultiplyingBought", isMultiplyingBought ? 1 : 0);
        PlayerPrefs.SetInt("MultiplyingActive", isMultiplyingActive ? 1 : 0);
        PlayerPrefs.SetInt("MultiplyingOnEffect", isMultiplyingOnEffect ? 1 : 0);

        PlayerPrefs.SetInt("HollowingBought", isHollowingBought ? 1 : 0);
        PlayerPrefs.SetInt("HollowingActive", isHollowingActive ? 1 : 0);
        PlayerPrefs.SetInt("HollowingOnEffect", isHollowingOnEffect ? 1 : 0);

        PlayerPrefs.SetInt("Augmentless", isAugmentless ? 1 : 0);

        PlayerPrefs.Save();
        Debug.Log("saved augs");
    }

    public void ResetAugments()
    {

        PlayerPrefs.DeleteKey("InsuranceBought");
        PlayerPrefs.DeleteKey("InsuranceActive");
        PlayerPrefs.DeleteKey("InsuranceOnEffect");

        PlayerPrefs.DeleteKey("MultiplyingBought");
        PlayerPrefs.DeleteKey("MultiplyingActive");
        PlayerPrefs.DeleteKey("MultiplyingOnEffect");

        PlayerPrefs.DeleteKey("HollowingBought");
        PlayerPrefs.DeleteKey("HollowingActive");
        PlayerPrefs.DeleteKey("HollowingOnEffect");

        PlayerPrefs.DeleteKey("Augmentless");

        isInsuranceBought = false;
        isInsuranceActive = false;
        isInsuranceOnEffect = false;

        isMultiplyingBought = false;
        isMultiplyingActive = false;
        isMultiplyingOnEffect = false;

        isHollowingBought = false;
        isHollowingActive = false;
        isHollowingOnEffect = false;

        isAugmentless = true;
        Debug.Log("augs resetted");
    }

    public void ActivateAugment(string augmentName)
    {
        isAugmentless = false;

        switch (augmentName)
        {
            case "Insurance Augment":
                if (isInsuranceBought)
                {
                    isInsuranceActive = true;
                    isMultiplyingBought = false;
                    isHollowingBought = false;
                    isMultiplyingActive = false;
                    isHollowingActive = false;
                    isAugmentless = false;
                }
                break;

            case "Multiplying Augment":
                if (isMultiplyingBought)
                {
                    isMultiplyingActive = true;
                    isInsuranceBought = false;
                    isHollowingBought = false;
                    isInsuranceActive = false;
                    isHollowingActive = false;
                    isAugmentless = false;
                }
                break;

            case "Hollowing Augment":
                if (isHollowingBought)
                {
                    isHollowingActive = true;
                    isInsuranceBought = false;
                    isMultiplyingBought = false;
                    isInsuranceActive = false;
                    isMultiplyingActive = false;
                    isAugmentless = false;
                }
                break;
        }

        if (!isInsuranceActive && !isMultiplyingActive && !isHollowingActive)
        {
            isAugmentless = true;
        }

        SaveAugments();
    }

    public void DisplayCurrentAugments()
    {
        if (augStatusTexts == null || augStatusTexts.Length == 0)
        {
            Debug.Log("AugmentStatusText array is null or empty. Cannot update text.");
            return;
        }

        string currentStatus = "";

        if (isInsuranceActive)
        {
            currentStatus += "Insurance Augment: Active\n";
        }
        if (isMultiplyingActive)
        {
            currentStatus += "Multiplying Augment: Active\n";
        }
        if (isHollowingActive)
        {
            currentStatus += "Hollowing Augment: Active\n";
        }
        if (string.IsNullOrEmpty(currentStatus))
        {
            currentStatus = "Augmentless";
        }

        foreach (var augStatusText in augStatusTexts)
        {
            if (augStatusText != null)
            {
                augStatusText.text = currentStatus.TrimEnd('\n');
            }
        }
        Debug.Log("Text updated to: " + currentStatus);
    }
}
