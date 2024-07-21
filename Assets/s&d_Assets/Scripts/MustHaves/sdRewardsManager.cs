using UnityEngine;
using TMPro;


//note: this script is not up to date!


public class sdRewardsManager : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject loseScreen;
    private bool winScreenActive = false;
    private bool loseScreenActive = false;

    private AugmentManager augmentManager;
    public TextMeshProUGUI statusText;

    void Start()
    {
        augmentManager = FindObjectOfType<AugmentManager>();
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
        }
        else
        {
            statusText.gameObject.SetActive(false);
        }
    }

  

    public string ApplyInsuranceEffect()
    {
        if (loseScreenActive && !winScreenActive)
        {
            return "Insurance Augment in effect! : No punishments received!";
        }
        else if (winScreenActive && !loseScreenActive)
        {
            return "Insurance Augment is active. : Augment prices are reduced by 30%!";
        }
        return "";
    }

    public string ApplyMultiplyingEffect()
    {
        if (loseScreenActive && !winScreenActive)
        {
            return "Multiplying Augment is active. : Augment prices are increased by 70%!";
        }
        else if (winScreenActive && !loseScreenActive)
        {
            sdScoreManager.instance.MultiplyScore(1.2f);
            return "Multiplying Augment in effect! : Obtained additional Fragments!";
        }
        return "";
    }

    public string ApplyHollowingEffect()
    {
        return "Hollowing Augment in effect! : No buffs or debuffs granted!";
    }

    public string defaultEffects()
    {
        if (winScreenActive && !loseScreenActive)
        {
            return "Augmentless : Augment prices are reduced by 30%!";
        }
        else if (loseScreenActive && !winScreenActive)
        {
            return "Augmentless : Augment prices are increased by 70%!";
        }
        return "";
    }

    public void ResetAugments()
    {
        augmentManager.ResetAugments();
    }
}
