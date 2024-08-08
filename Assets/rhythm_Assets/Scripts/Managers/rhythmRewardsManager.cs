using UnityEngine;
using TMPro;

public class rhythmRewardsManager : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    private rhythmScoreManager _rhythmScoreManager;
    private GameModeManager _gameModeManager;
    private AugmentManager augmentManager;
    public GameObject failTrigger;

    public GameObject winScreen;
    public GameObject loseScreen;
    private bool winScreenActive = false;
    private bool loseScreenActive = false;

    public rhythmMultiScore[] multiScoreEffects;

    private bool scoreTriggered = false;

    void Start()
    {
        augmentManager = AugmentManager.instance;

        if (augmentManager == null)
        {
            Debug.LogError("AugmentManager instance not found in the scene.");
            return;
        }

        _rhythmScoreManager = rhythmScoreManager.instance;

        if (_rhythmScoreManager == null)
        {
            Debug.LogError("RhythmScoreManager instance not found in the scene.");
            return;
        }

        statusText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (rhythmSongManager.Instance.isSongFinished)
        {
            DetermineActiveScreen();
            ApplyAugmentEffects();
        }
    }

    public void DetermineActiveScreen()
    {
        if (failTrigger.activeInHierarchy)
        {
            winScreen.SetActive(false);
            loseScreen.SetActive(true);
        }
        else if (!failTrigger.activeInHierarchy)
        {
            winScreen.SetActive(true);
            loseScreen.SetActive(false);
        }

        winScreenActive = winScreen.activeInHierarchy;
        loseScreenActive = loseScreen.activeInHierarchy;
        statusText.gameObject.SetActive(true);
    }

    private void ApplyAugmentEffects()
    {
        if (!scoreTriggered)
        {
            string effectMessage = "";

            effectMessage = ApplyInsuranceEffect();
            if (string.IsNullOrEmpty(effectMessage)) effectMessage = ApplyMultiplyingEffect();
            if (string.IsNullOrEmpty(effectMessage)) effectMessage = ApplyHollowingEffect();
            if (string.IsNullOrEmpty(effectMessage)) effectMessage = defaultEffects();

            statusText.text = effectMessage.Trim();
            scoreTriggered = true;
        }
    }

    private string ApplyInsuranceEffect()
    {
        if (augmentManager.isInsuranceActive)
        {
            augmentManager.isInsuranceOnEffect = true;
            if (loseScreenActive && !winScreenActive)
            {
                _rhythmScoreManager.BaseScoring();                
                _gameModeManager.UpdateAdwareButton();
                return "Insurance Augment in effect! : No punishments received!\n";

            }
            else if (winScreenActive && !loseScreenActive)
            {
                _rhythmScoreManager.BaseScoring();
                _gameModeManager.UpdateAdwareButton();
                return "Insurance Augment is active! : Augment skill is not triggered.\n";
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
                _rhythmScoreManager.BaseScoring();
                GetRhythmDebuff();
                _gameModeManager.UpdateAdwareButton();
                return "Multiplying Augment is active. : Augment conditions is not triggered.\n";
            }
            else if (winScreenActive && !loseScreenActive)
            {
                if (multiScoreEffects != null)
                {
                    foreach (var multiScore in multiScoreEffects)
                    {
                        if (multiScore != null)
                        {
                            multiScore.enabled = true;
                        }
                    }
                }
                _rhythmScoreManager.MultiplierEffect();
                _gameModeManager.UpdateAdwareButton();
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
            _rhythmScoreManager.BaseScoring();
            _gameModeManager.UpdateAdwareButton();
            return "Hollowing Augment in effect! : No buffs or debuffs granted!\n";
        }
        else
        {
            _rhythmScoreManager.BaseScoring();
            _gameModeManager.UpdateFilelessButton();
        }
        return "";
    }

    private string defaultEffects()
    {
        if (augmentManager.isAugmentless)
        {
            if (winScreenActive && !loseScreenActive)
            {
                _rhythmScoreManager.BaseScoring();
                _gameModeManager.UpdateAdwareButton();
                return "Augmentless : No punishments triggered!\n";
            }
            else if (loseScreenActive && !winScreenActive)
            {
                GetRhythmDebuff();
                _rhythmScoreManager.BaseScoring();
                _gameModeManager.UpdateAdwareButton();
                return "Augmentless : Punishments triggered!\n";
            }
        }

        return "";
    }

    public void GetRhythmDebuff()
    {
        PopUpManager.instance.isDebuffTriggered = true;
        Debug.Log("pop-ups are now enabled");
    }
}