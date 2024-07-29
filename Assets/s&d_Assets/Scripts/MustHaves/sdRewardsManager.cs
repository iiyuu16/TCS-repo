using UnityEngine;
using TMPro;

public class sdRewardsManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    public TextMeshProUGUI statusText;

    private bool winScreenActive = false;
    private bool loseScreenActive = false;

    private AugmentManager augmentManager;
    private ShopManager shopManager;

    void Start()
    {
        augmentManager = AugmentManager.instance;
        if (augmentManager == null)
        {
            Debug.LogError("AugmentManager instance is not found in the scene.");
            return;
        }

        shopManager = FindObjectOfType<ShopManager>();
        if (shopManager == null)
        {
            Debug.LogError("ShopManager instance is not found in the scene.");
            return;
        }

        DetermineActiveScreen();
    }

    void Update()
    {
        DetermineActiveScreen();
    }

    public void DetermineActiveScreen()
    {
        winScreenActive = winScreen.activeInHierarchy;
        loseScreenActive = loseScreen.activeInHierarchy;

        if (winScreenActive || loseScreenActive)
        {
            statusText.gameObject.SetActive(true);
            ApplyAugmentEffects();
        }
        else
        {
            statusText.gameObject.SetActive(false);
        }
    }

    private void ApplyAugmentEffects()
    {
        string effectMessage = "";

        // Apply each effect and break early if an effect is applied
        effectMessage = ApplyInsuranceEffect();
        if (string.IsNullOrEmpty(effectMessage)) effectMessage = ApplyMultiplyingEffect();
        if (string.IsNullOrEmpty(effectMessage)) effectMessage = ApplyHollowingEffect();
        if (string.IsNullOrEmpty(effectMessage)) effectMessage = defaultEffects();

        statusText.text = effectMessage.Trim();
    }

    private string ApplyInsuranceEffect()
    {
        if (augmentManager.isInsuranceActive)
        {
            augmentManager.isInsuranceOnEffect = true;
            if (loseScreenActive && !winScreenActive)
            {
                shopManager.priceMultiplier = 1.0f; // No change to price
                return "Insurance Augment in effect! : No punishments received!\n";
            }
            else if (winScreenActive && !loseScreenActive)
            {
                shopManager.priceMultiplier = 0.7f; // Reduce price by 30%
                return "Insurance Augment is active! : No punishments triggered!\n";
            }
        }
        return "";
    }

    private string ApplyMultiplyingEffect()
    {
        if (augmentManager.isMultiplyingActive)
        {
            augmentManager.isMultiplyingOnEffect = true;
            if (loseScreenActive && !winScreenActive)
            {
                shopManager.priceMultiplier = 1.7f; // Increase price by 70%
                return "Multiplying Augment is active. : No punishments triggered!\n";
            }
            else if (winScreenActive && !loseScreenActive)
            {
                //sdScoreManager.instance.MultiplyScore(1.2f);
                shopManager.priceMultiplier = 1.0f; // No change to price
                return "Multiplying Augment in effect! : Obtained additional Fragments!\n";
            }
        }
        return "";
    }

    private string ApplyHollowingEffect()
    {
        if (augmentManager.isHollowingActive)
        {
            augmentManager.isHollowingOnEffect = true;
            shopManager.priceMultiplier = 1.0f; // No change to price
            return "Hollowing Augment in effect! : No buffs or debuffs granted!\n";
        }
        return "";
    }

    private string defaultEffects()
    {
        if (augmentManager.isAugmentless)
        {
            if (winScreenActive && !loseScreenActive)
            {
                shopManager.priceMultiplier = 0.7f; // Reduce price by 30%
                return "Augmentless : No punishments triggered!\n";
            }
            else if (loseScreenActive && !winScreenActive)
            {
                shopManager.priceMultiplier = 1.7f; // Increase price by 70%
                return "Augmentless : Punishments triggered!\n";
            }
        }
        return "";
    }

    public void ResetAugments()
    {
        augmentManager.ResetAugments();
    }
}
