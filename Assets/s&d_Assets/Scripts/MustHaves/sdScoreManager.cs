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

    private void Update()
    {
        UpdateScoreText();
        UpdateObtainedScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        UpdateObtainedScoreText();
    }

    public void MultiplierEffect()
    {
        float multiplier = 1.2f;
        int newScore = Mathf.RoundToInt(score * multiplier);
        Debug.Log("Base score: " + score);
        score = newScore;
        Debug.Log("Multiplied score: " + score);
        MoneyManager.instance.UpdateMoneyFromGamemode(newScore);
        UpdateObtainedScoreText();
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
            obtainedScoreText.text = "Got " + FormatScore(score) + " Frgz.";
        }
    }

    private string FormatScore(int score)
    {
        string scoreStr = score.ToString();
        int paddingLength = Mathf.Max(1, scoreStr.Length);
        return scoreStr.PadRight(paddingLength);
    }
}
