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
    private StatusManager statusManager;

    public sdMultiScore[] multiScoreEffects;

    void Start()
    {
        augmentManager = AugmentManager.instance;
        if (augmentManager == null)
        {
            Debug.LogError("AugmentManager instance is not found in the scene.");
            return;
        }

        statusManager = FindObjectOfType<StatusManager>();
        if (statusManager == null)
        {
            Debug.LogError("StatusManager instance is not found in the scene.");
            return;
        }
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
            sdScoreManager.instance.obtainedScoreText.gameObject.SetActive(true);
        }
        else
        {
            statusText.gameObject.SetActive(false);
        }
    }

    private void ApplyAugmentEffects()
    {
        string effectMessage = "";

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
                return "Insurance Augment in effect! : No punishments received!\n";
            }
            else if (winScreenActive && !loseScreenActive)
            {
                return "Insurance Augment is active! : Augment skill is not triggered.\n";
            }
        }
        statusManager.shopDebuffOff();
        return "";
    }

    private string ApplyMultiplyingEffect()
    {
        if (augmentManager.isMultiplyingActive)
        {
            augmentManager.isMultiplyingOnEffect = true;
            if (loseScreenActive && !winScreenActive)
            {
                statusManager.shopDebuffOn();
                return "Multiplying Augment is active. : Augment conditions is not triggered.\n";
            }
            else if (winScreenActive && !loseScreenActive)
            {
                /*             if (multiScoreEffects != null)
                             {
                                 foreach (var multiScore in multiScoreEffects)
                                 {
                                     if (multiScore != null)
                                     {
                                         multiScore.enabled = true;
                                     }
                                 }
                             }*/
                statusManager.shopDebuffOff();
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
            statusManager.shopDebuffOff();
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
                statusManager.shopDebuffOff();
                return "Augmentless : No punishments triggered!\n";
            }
            else if (loseScreenActive && !winScreenActive)
            {
                statusManager.shopDebuffOn();
                return "Augmentless : Punishments triggered!\n";
            }
        }
        return "";
    }
}
