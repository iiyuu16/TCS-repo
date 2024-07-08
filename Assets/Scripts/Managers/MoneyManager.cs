using UnityEngine;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int currentMoney;
    public TextMeshProUGUI moneyText;

    void Start()
    {
        currentMoney = 0;
        UpdateMoneyText();
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

    private void UpdateMoneyText()
    {
        string moneyString = "FRGz: " + currentMoney.ToString().PadLeft(9, '0');
        moneyText.text = moneyString;
    }
}
