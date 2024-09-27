using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    public GameObject baseCam;
    public GameObject shopCam;
    public GameObject mhubCam;

    public void ViewBaseCam()
    {
        baseCam.SetActive(true);
        shopCam.SetActive(false);
        mhubCam.SetActive(false);
    }

    public void ViewShopCam()
    {
        baseCam.SetActive(false);
        shopCam.SetActive(true);
        mhubCam.SetActive(false);
    }

    public void ViewMHubCam()
    {
        baseCam.SetActive(false);
        shopCam.SetActive(false);
        mhubCam.SetActive(true);
    }

}
