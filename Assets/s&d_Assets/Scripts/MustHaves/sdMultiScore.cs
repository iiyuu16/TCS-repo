using UnityEngine;

public class sdMultiScore : MonoBehaviour
{
    void OnEnable()
    {
        Debug.Log("onenable is triggered");

        if (sdScoreManager.instance != null)
        {
            sdScoreManager.instance.MultiplierEffect();
        }
        else
        {
            Debug.LogError("sdScoreManager instance is null.");
        }
    }
}
