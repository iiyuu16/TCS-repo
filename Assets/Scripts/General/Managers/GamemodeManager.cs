using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager instance;

    public bool filelessMalwareDone;
    public bool adwareDone;

    private const string FILELESS_MALWARE_DONE_KEY = "FilelessMalwareDone";
    private const string ADWARE_DONE_KEY = "AdwareDone";

    public GameObject filelessButton;
    public GameObject adwareButton;

    public GameObject malwareFL;
    public GameObject malwareADWARE;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        if (SceneManager.GetActiveScene().name == "VisNov_Prologue")
        {
            ResetGMProgress();
            Debug.Log("GM:scene name is prologue");
        }
        else
        {
            LoadGMProgress();
            Debug.Log("GM:scene name is else");
        }

        if (filelessButton != null)
        {
            InvokeRepeating("UpdateFilelessButton", 1f, 1f);
            Debug.Log("GM:filessbtn not null");
        }
        else
        {
            filelessMalwareDone = false;
            Debug.LogWarning("GM:filessbtn is null");
        }

        if (adwareButton != null)
        {
            InvokeRepeating("UpdateAdwareButton", 1f, 1f);
            Debug.Log("GM:adwarebtn not null");
        }
        else
        {
            adwareDone = false;
            Debug.LogWarning("GM:adwarebtn is null");
        }

        //icon check
        if (malwareFL != null)
        {
            if (filelessMalwareDone)
            {
                malwareFL.SetActive(true);
            }
        }
        if (malwareADWARE != null)
        {
            if (adwareDone)
            {
                malwareADWARE.SetActive(true);
            }
        }

        UpdateAllBtns();
    }

    public void adwareGM_Done()
    {
        adwareDone = true;
        SaveGMProgress();
        LoadGMProgress();
        Debug.LogWarning("check GM bools: adware: "+adwareDone+ ", fl: "+filelessMalwareDone);
    }

    public void filelessGM_Done()
    {
        filelessMalwareDone = true;
        SaveGMProgress();
        LoadGMProgress();
        Debug.LogWarning("check GM bools: adware: " + adwareDone + ", fl: " + filelessMalwareDone);
    }

    public void LoadGMProgress()
    {
        filelessMalwareDone = PlayerPrefs.GetInt(FILELESS_MALWARE_DONE_KEY, 0) == 1;
        adwareDone = PlayerPrefs.GetInt(ADWARE_DONE_KEY, 0) == 1;
        SaveGMProgress();
    }

    public void SaveGMProgress()
    {
        PlayerPrefs.SetInt(FILELESS_MALWARE_DONE_KEY, filelessMalwareDone ? 1 : 0);
        PlayerPrefs.SetInt(ADWARE_DONE_KEY, adwareDone ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void ResetGMProgress()
    {
        filelessMalwareDone = false;
        adwareDone = false;

        PlayerPrefs.SetInt(FILELESS_MALWARE_DONE_KEY, 0);
        PlayerPrefs.SetInt(ADWARE_DONE_KEY, 0);
        PlayerPrefs.Save();

        Debug.Log("GM:gamemodes progress reset");
    }

    public void UpdateButton(GameObject buttonGameObject, bool booleanValue)
    {
        Button buttonComponent = buttonGameObject.GetComponent<Button>();

        buttonComponent.interactable = !booleanValue;
        SaveGMProgress();
        LoadGMProgress();
    }

    public void UpdateAllBtns()
    {
        UpdateAdwareButton();
        UpdateFilelessButton();
    }

    public void UpdateFilelessButton()
    {
        UpdateButton(filelessButton, filelessMalwareDone);
    }

    public void UpdateAdwareButton()
    {
        UpdateButton(adwareButton, adwareDone);
    }
}