using UnityEngine;
using TMPro;

public class sdScoreManager : MonoBehaviour
{
    public static sdScoreManager instance;
    private int score = 0;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI obtainedScoreText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        UpdateObtainedScoreText();

        if (MoneyManager.instance != null)
        {
            MoneyManager.instance.UpdateMoneyFrom_FLM(score);
            Debug.Log("Score sent to MoneyManager: " + score);
        }
        else
        {
            Debug.LogError("MoneyManager instance is null.");
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = FormatScore(score);
        }
    }

    private void UpdateObtainedScoreText()
    {
        if (obtainedScoreText != null)
        {
            obtainedScoreText.text = FormatScore(score) + " Frgz.";
        }
    }

    private string FormatScore(int score)
    {
        string scoreStr = score.ToString();
        return scoreStr.PadLeft(8, ' ');
    }
}
