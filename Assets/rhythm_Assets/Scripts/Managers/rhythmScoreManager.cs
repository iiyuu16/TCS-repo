using UnityEngine;
using TMPro;

public class rhythmScoreManager : MonoBehaviour
{
    public static rhythmScoreManager instance;

    public AudioSource hitSFX;
    public AudioSource missSFX;
    public TextMeshPro scoreTextMesh;
    public TextMeshProUGUI[] resScoreTexts;
    public static int comboScore;
    public int healthDeduction = 10;

    private void Awake()
    {
        instance = this;
        comboScore = 0;
    }

    public static void Hit()
    {
        comboScore++;
        instance.hitSFX.Play();
    }

    public static void Miss()
    {
        comboScore = 0;
        instance.missSFX.Play();
        DeductHealthOnMiss();
    }

    private static void DeductHealthOnMiss()
    {
        if (rhythmHealthManager.Instance != null)
        {
            rhythmHealthManager.Instance.DeductHealth(instance.healthDeduction);
        }
        else
        {
            Debug.LogWarning("rhythmHealthManager instance not found.");
        }
    }

    private void Update()
    {
        UpdateScoreText();
        UpdateResultScoreText();
    }

    void UpdateScoreText()
    {
        scoreTextMesh.text = comboScore.ToString();
    }

    void UpdateResultScoreText()
    {
        int newScore = Mathf.RoundToInt(comboScore * 1f);
        for (int i = 0; i < resScoreTexts.Length; i++)
        {
            resScoreTexts[i].text = "Got " + newScore.ToString() + " Frgz.";
        }
    }

    public void BaseScoring()
    {
        float baseMultiplier = 1f;
        int newScore = Mathf.RoundToInt(comboScore * baseMultiplier);
        Debug.Log("Base score: " + comboScore);
        Debug.Log("Base multiplied score: " + newScore);

        MoneyManager.instance.UpdateMoneyFromGamemode(newScore);
        UpdateResultScoreText();
    }

    public void MultiplierEffect()
    {
        float augmentMultiplier = 2f;
        float totalMultiplier = augmentMultiplier;

        int newScore = Mathf.RoundToInt(comboScore * totalMultiplier);
        Debug.Log("Base score: " + comboScore);
        Debug.Log("Multiplied score: " + newScore);

        MoneyManager.instance.UpdateMoneyFromGamemode(newScore);
        UpdateResultScoreText();
    }
}