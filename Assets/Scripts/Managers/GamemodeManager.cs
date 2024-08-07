using UnityEngine;
using UnityEngine.UI;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager instance;

    public bool filelessMalwareDone;
    public bool adwareDone;

    private const string FILELESS_MALWARE_DONE_KEY = "FilelessMalwareDone";
    private const string ADWARE_DONE_KEY = "AdwareDone";

    public GameObject filelessMalwareButton;
    public GameObject adwareButton;

    public Color enabledColor;
    public Color disabledColor;

    public Color enabledTextColor;
    public Color disabledTextColor;

    private void Awake()
    {
        instance = this;

        LoadBooleans();
        InvokeRepeating("UpdateFilelessMalwareButton", 1f, 1f);
        InvokeRepeating("UpdateAdwareButton", 1f, 1f);
    }

    public void LoadBooleans()
    {
        filelessMalwareDone = PlayerPrefs.GetInt(FILELESS_MALWARE_DONE_KEY, 0) == 1;
        adwareDone = PlayerPrefs.GetInt(ADWARE_DONE_KEY, 0) == 1;
    }

    public void SaveBooleans()
    {
        PlayerPrefs.SetInt(FILELESS_MALWARE_DONE_KEY, filelessMalwareDone ? 1 : 0);
        PlayerPrefs.SetInt(ADWARE_DONE_KEY, adwareDone ? 1 : 0);
        PlayerPrefs.Save();

        Debug.Log("Boolean values saved");
    }

    public void ResetBooleans()
    {
        filelessMalwareDone = false;
        adwareDone = false;

        PlayerPrefs.SetInt(FILELESS_MALWARE_DONE_KEY, 0);
        PlayerPrefs.SetInt(ADWARE_DONE_KEY, 0);
        PlayerPrefs.Save();

        Debug.Log("Boolean values reset");
    }

    public void UpdateFilelessMalwareButton()
    {
        if (filelessMalwareDone)
        {
            filelessMalwareButton.GetComponent<Image>().color = disabledColor;
            filelessMalwareButton.GetComponent<Button>().interactable = false;
            UpdateFilelessMalwareTextColor(true);
        }
        else
        {
            filelessMalwareButton.GetComponent<Image>().color = enabledColor;
            filelessMalwareButton.GetComponent<Button>().interactable = true;
            UpdateFilelessMalwareTextColor(false);
        }
    }

    public void UpdateAdwareButton()
    {
        if (adwareDone)
        {
            adwareButton.GetComponent<Image>().color = disabledColor;
            adwareButton.GetComponent<Button>().interactable = false;
            UpdateAdwareTextColor(true);
        }
        else
        {
            adwareButton.GetComponent<Image>().color = enabledColor;
            adwareButton.GetComponent<Button>().interactable = true;
            UpdateAdwareTextColor(false);
        }
    }

    public void UpdateButtonTextColor(GameObject button, bool booleanValue)
    {
        Text textComponent = button.GetComponentInChildren<Text>();

        if (booleanValue)
        {
            textComponent.color = disabledTextColor;
        }
        else
        {
            textComponent.color = enabledTextColor;
        }
    }

    public void UpdateFilelessMalwareTextColor(bool booleanValue)
    {
        UpdateButtonTextColor(filelessMalwareButton, booleanValue);
    }

    public void UpdateAdwareTextColor(bool booleanValue)
    {
        UpdateButtonTextColor(adwareButton, booleanValue);
    }
}