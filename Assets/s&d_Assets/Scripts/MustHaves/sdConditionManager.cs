using UnityEngine;

public class sdWinConditionManager : MonoBehaviour
{
    public GameObject[] targetGameObjects;
    public GameObject winScreen;
    public GameObject[] objectsToDisable;

    private bool hasWon = false;

    private void Update()
    {
        if (!hasWon && AreAllTargetsDestroyed())
        {
            if (winScreen != null)
            {
                winScreen.SetActive(true);
            }

            DisableGameObjects();
            hasWon = true;
        }
    }

    private bool AreAllTargetsDestroyed()
    {
        foreach (GameObject target in targetGameObjects)
        {
            if (target != null)
            {
                return false;
            }
        }
        return true;
    }

    private void DisableGameObjects()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }
}
