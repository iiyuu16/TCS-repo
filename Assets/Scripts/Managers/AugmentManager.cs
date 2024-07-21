using UnityEngine;
using TMPro;

public class AugmentManager : MonoBehaviour
{
    public static AugmentManager instance;
    public TextMeshProUGUI augStatusText;

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

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
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
        DisplayCurrentAugments();
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
        DisplayCurrentAugments();
    }

    public void ResetAugments()
    {
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

        DisplayCurrentAugments();
    }

    public void ActivateAugment(string augmentName)
    {
        switch (augmentName)
        {
            case "Insurance Augment":
                if (isInsuranceBought)
                {
                    isInsuranceActive = true;
                    isInsuranceOnEffect = false;
                }
                break;

            case "Multiplying Augment":
                if (isMultiplyingBought)
                {
                    isMultiplyingActive = true;
                    isMultiplyingOnEffect = false;
                }
                break;

            case "Hollowing Augment":
                if (isHollowingBought)
                {
                    isHollowingActive = true;
                    isHollowingOnEffect = false;
                }
                break;
        }

        SaveAugments();
        DisplayCurrentAugments();
    }

    public void DisplayCurrentAugments()
    {
        if (augStatusText == null)
        {
            Debug.LogError("AugmentStatusText reference is null. Cannot update text.");
            return;
        }

        string currentStatus = "Augmentless";

        if (isInsuranceBought)
        {
            currentStatus = "Insurance Augment: Active";
        }
        else if (isMultiplyingBought)
        {
            currentStatus = "Multiplying Augment: Active";
        }
        else if (isHollowingBought)
        {
            currentStatus = "Hollowing Augment: Active";
        }

        augStatusText.text = currentStatus;
        Debug.Log("Text updated to: " + currentStatus);
    }
}
