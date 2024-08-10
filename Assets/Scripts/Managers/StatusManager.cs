using UnityEngine;
using UnityEngine.SceneManagement;

public class StatusManager : MonoBehaviour
{
    public static StatusManager instance;

    private ShopManager shopManager;
    private float priceMultiplier;

    private PopUpManager popUpManager;

    // debuffs
    public bool shopInflation;
    public bool nonStopPopUp;

    // buffs
    public bool shopDiscount;

    // normal states (static)
    public bool shopNormal;
    public bool noPopups;

    // status icons
    public GameObject discountIcon; //shop buff
    public GameObject inflationIcon; // shop debuff
    public GameObject popUpIcon;
    private void Awake()
    {
        instance = this;

        shopManager = FindObjectOfType<ShopManager>();
        if (shopManager == null)
        {
            Debug.LogWarning("ShopManager instance not found in the scene.");
        }

        priceMultiplier = PlayerPrefs.GetFloat("PriceMultiplier", 1.0f);

        popUpManager = FindObjectOfType<PopUpManager>();
        if (popUpManager == null)
        {
            Debug.LogWarning("PopUpManager instance not found in the scene. PopUpDebuffs will not work.");
        }

        //reset statuses
        if (SceneManager.GetActiveScene().name == "VisNov_Prologue")
        {
           setToDefaultStatus();
        }

        //buff icons
        if (discountIcon != null)
        {
            discountIcon.SetActive(false);
        }

        //debuff icons
        if (popUpIcon != null)
        {
            popUpIcon.SetActive(false);
        }

        if (inflationIcon != null)
        {
            inflationIcon.SetActive(false);
        }

        LoadStatus();
    }


    public void SaveStatus()
    {
        //normal states
        PlayerPrefs.SetInt("ShopNormal", shopNormal ? 1 : 0);
        PlayerPrefs.SetInt("NoPopups", noPopups ? 1 : 0);
        //buffs
        PlayerPrefs.SetInt("ShopDiscount", shopDiscount ? 1 : 0);
        //debuffs
        PlayerPrefs.SetInt("ShopInflation", shopInflation ? 1 : 0);
        PlayerPrefs.SetInt("NonStopPopUp", nonStopPopUp ? 1 : 0);

        if (shopManager != null)
        {
            PlayerPrefs.SetFloat("PriceMultiplier", shopManager.shopMultiplier);
        }

        PlayerPrefs.Save();
    }


    public void LoadStatus()
    {
        //normal states
        shopNormal = PlayerPrefs.GetInt("ShopNormal", 0) == 1;
        noPopups = PlayerPrefs.GetInt("NoPopups", 0) == 1;
        //buffs
        shopDiscount = PlayerPrefs.GetInt("ShopDiscount", 0) == 1;
        //debuffs
        shopInflation = PlayerPrefs.GetInt("ShopInflation", 0) == 1;
        nonStopPopUp = PlayerPrefs.GetInt("NonStopPopUp", 0) == 1;

        if (shopManager != null)
        {
            priceMultiplier = PlayerPrefs.GetFloat("PriceMultiplier", shopManager.shopMultiplier);
        }
    }

    public void setToDefaultStatus()
    {
        shopNormalStatus();
        popupDebuffOff();
        Debug.Log("all statuses are resetted");
    }

    public void Update()
    {
        if (shopInflation)
        {
            shopDebuffOn();
        }

        if (shopDiscount)
        {
            shopBuffOn();
        }

        if (shopNormal)
        {
            shopNormalStatus();
        }

        if (nonStopPopUp)
        {
            popupDebuffOn();
        }

        if (noPopups)
        {
            popupDebuffOff();
        }
    }

    // functs are called by rewardManagers from different gamemodes
    public void shopNormalStatus()
    {
        shopInflation = false;
        shopNormal = true;
        shopDiscount = false;

        PlayerPrefs.SetInt("ShopDiscount", 0);
        PlayerPrefs.SetInt("ShopInflation", 0);
        PlayerPrefs.SetInt("ShopNormal", 1);

        if (shopManager != null)
        {
            shopManager.shopMultiplier = 1.0f;
        }
        else
        {
            Debug.LogWarning("ShopManager instance not found. Funct will not work.");
        }

        SaveStatus();
        LoadStatus();
    }

    public void shopDebuffOn()
    {
        shopInflation = true;
        shopNormal = false;
        shopDiscount = false;

        if (inflationIcon != null)
        {
            inflationIcon.SetActive(true);
        }

        PlayerPrefs.SetInt("ShopDiscount", 0);
        PlayerPrefs.SetInt("ShopInflation", 1);
        PlayerPrefs.SetInt("ShopNormal", 0);

        if (shopManager != null)
        {
            shopManager.shopMultiplier = 1.7f;
        }
        else
        {
            Debug.LogWarning("ShopManager instance not found. Funct will not work.");
        }

        SaveStatus();
        LoadStatus();
    }

    public void shopBuffOn()
    {
        shopInflation = false;
        shopNormal = false;
        shopDiscount = true;

        if (discountIcon != null)
        {
            discountIcon.SetActive(false);
        }

        PlayerPrefs.SetInt("ShopDiscount", 1);
        PlayerPrefs.SetInt("ShopInflation", 0);
        PlayerPrefs.SetInt("ShopNormal", 0);

        if (popUpManager != null)
        {
            shopManager.shopMultiplier = 0.85f;
        }
        else
        {
            Debug.LogWarning("ShopManager instance not found. Funct will not work.");
        }

        SaveStatus();
        LoadStatus();
    }

    public void popupDebuffOn()
    {
        nonStopPopUp = true;
        noPopups = false;

        if (popUpIcon != null)
        {
            popUpIcon.SetActive(true);
        }

        if (popUpManager != null)
        {
            popUpManager.OnThisManager();
        }
        else
        {
            Debug.LogWarning("PopUpManager instance not found. PopUpDebuffs will not work.");
        }

        PlayerPrefs.SetInt("NonStopPopUp", 1);
        PlayerPrefs.SetInt("NoPopups", 0);

        SaveStatus();
        LoadStatus();
    }

    public void popupDebuffOff()
    {
        nonStopPopUp = false;
        noPopups = true;

        if (popUpIcon != null)
        {
            popUpIcon.SetActive(false);
        }

        if (popUpManager != null)
        {
            popUpManager.OffThisManager();
        }
        else
        {
            Debug.LogWarning("PopUpManager instance not found. PopUpDebuffs will not work.");
        }

        PlayerPrefs.SetInt("NonStopPopUp", 0);
        PlayerPrefs.SetInt("NoPopups", 1);

        SaveStatus();
        LoadStatus();
    }
}