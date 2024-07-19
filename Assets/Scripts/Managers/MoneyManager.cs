using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;
    public int currentMoney;
    public TextMeshProUGUI moneyText;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: To keep the MoneyManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadMoney();
        UpdateMoneyText();
    }

    private void OnApplicationQuit()
    {
        SaveMoney();
    }

    private void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            SaveMoney();
        }
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyText();
        Debug.Log("Added money: " + amount + ". Current money: " + currentMoney);
    }

    public void SubtractMoney(int amount)
    {
        currentMoney -= Mathf.Abs(amount);
        UpdateMoneyText();
        Debug.Log("Subtracted money: " + amount + ". Current money: " + currentMoney);
    }

    public bool SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyText();
            Debug.Log("Spent money: " + amount + ". Current money: " + currentMoney);
            return true;
        }
        else
        {
            Debug.Log("Not enough money. Current money: " + currentMoney);
            return false;
        }
    }

    public int GetCurrentMoney()
    {
        return currentMoney;
    }

    public void UpdateMoneyText()
    {
        string moneyString = currentMoney.ToString();
        moneyText.text = "FRGz: " + moneyString;
    }

    public void UpdateMoneyFrom_FLM(int score)
    {
        int moneyFromScore = score / 6;
        AddMoney(moneyFromScore);
        Debug.Log("Money updated from score: " + moneyFromScore);
    }

    private void OnValidate()
    {
        if (moneyText != null)
        {
            UpdateMoneyText();
        }
    }

    private void SaveMoney()
    {
        PlayerPrefs.SetInt("CurrentMoney", currentMoney);
        PlayerPrefs.Save();
    }

    private void LoadMoney()
    {
        currentMoney = PlayerPrefs.GetInt("CurrentMoney", 0);
    }
}
