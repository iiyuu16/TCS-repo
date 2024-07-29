using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class sdMultiScore : MonoBehaviour
{
    public float scoreMultiplier = 1.2f;

    void OnEnable()
    {
        if (sdScoreManager.instance != null)
        {
            sdScoreManager.instance.MultiplyAndSendScoreToMoneyManager(scoreMultiplier);
        }
        else
        {
            Debug.LogError("sdScoreManager instance is null.");
        }
    }
}


/*public void MultiplyAndSendScoreToMoneyManager(float multiplier)
{
    long multipliedScore = (long)(score * multiplier);
    UpdateScoreText(multipliedScore);
    UpdateObtainedScoreText(multipliedScore);

    if (MoneyManager.instance != null)
    {
        MoneyManager.instance.UpdateMoneyFrom_FLM((int)Mathf.Clamp(multipliedScore, int.MinValue, int.MaxValue)); // Ensure score is clamped to int range
        Debug.Log("Score multiplied by " + multiplier + " and sent to MoneyManager: " + multipliedScore);
    }
    else
    {
        Debug.LogError("MoneyManager instance is null.");
    }
}*/