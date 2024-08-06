using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public static StatusManager instance;

    private ShopManager shopManager;
    private float _priceMultiplier;

    private PopUpManager popUpManager;

    // debuffs (static)
    public static bool shopInflation;
    public static bool nonStopPopUp;

    // normal states (static)
    public static bool shopNormal;
    public static bool noPopups;

    public void SaveStatus()
    {
        PlayerPrefs.SetInt("ShopInflation", shopInflation ? 1 : 0);
        PlayerPrefs.SetInt("NonStopPopUp", nonStopPopUp ? 1 : 0);
        PlayerPrefs.SetInt("ShopNormal", shopNormal ? 1 : 0);
        PlayerPrefs.SetInt("NoPopups", noPopups ? 1 : 0);

        PlayerPrefs.SetFloat("PriceMultiplier", shopManager.priceMultiplier);

        PlayerPrefs.Save();
        Debug.Log("Statuses saved");
    }

    public void LoadStatus()
    {
        shopInflation = PlayerPrefs.GetInt("ShopInflation", 0) == 1;
        nonStopPopUp = PlayerPrefs.GetInt("NonStopPopUp", 0) == 1;
        shopNormal = PlayerPrefs.GetInt("ShopNormal", 0) == 1;
        noPopups = PlayerPrefs.GetInt("NoPopups", 0) == 1;

        _priceMultiplier = PlayerPrefs.GetFloat("PriceMultiplier", 1.0f);

        shopManager.priceMultiplier = _priceMultiplier;
    }

    private void Awake()
    {
        instance = this;

        shopManager = FindObjectOfType<ShopManager>();
        if (shopManager == null)
        {
            Debug.Log("ShopManager instance not found in the scene.");
            return;
        }
        _priceMultiplier = PlayerPrefs.GetFloat("PriceMultiplier", 1.0f);

        popUpManager = FindObjectOfType<PopUpManager>();
        if (popUpManager == null)
        {
            Debug.Log("PopUpManager instance not found in the scene.");
            return;
        }

        LoadStatus();
    }

    void Update()
    {
        if (shopInflation)
        {
            shopDebuffOn();
        }
        else if (shopNormal)
        {
            shopDebuffOff();
        }

        if (nonStopPopUp)
        {
            popupDebuffOn();
        }
        else if (noPopups)
        {
            popupDebuffOff();
        }
    }

    // functs are called by rewardManagers from different gamemodes
    public void shopDebuffOn()
    {
        shopInflation = true;
        shopNormal = false;
        shopManager.priceMultiplier = 1.7f;
        PlayerPrefs.SetInt("ShopInflation", 1);
        PlayerPrefs.SetInt("ShopNormal", 0);
        SaveStatus();
        Debug.Log("shop debuff is enabled");
        LoadStatus();
    }

    public void shopDebuffOff()
    {
        shopInflation = false;
        shopNormal = true;
        shopManager.priceMultiplier = 1.0f;
        PlayerPrefs.SetInt("ShopInflation", 0);
        PlayerPrefs.SetInt("ShopNormal", 1);
        SaveStatus();
        Debug.Log("shop debuff is off");
        LoadStatus();
    }

    public void popupDebuffOn()
    {
        nonStopPopUp = true;
        noPopups = false;
        popUpManager.isDebuffTriggered = true;
        PlayerPrefs.SetInt("NonStopPopUp", 1);
        PlayerPrefs.SetInt("NoPopups", 0);
        SaveStatus();
        Debug.Log("popup debuff is enabled");
        LoadStatus();
    }

    public void popupDebuffOff()
    {
        nonStopPopUp = false;
        noPopups = true;
        popUpManager.isDebuffTriggered = false;
        PlayerPrefs.SetInt("NonStopPopUp", 0);
        PlayerPrefs.SetInt("NoPopups", 1);
        SaveStatus();
        Debug.Log("popup debuff is off");
        LoadStatus();
    }
}