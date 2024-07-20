using UnityEngine;

public class AugmentManager : MonoBehaviour
{
    public Augment[] allAugments;  // Array of all augment prefabs

    void Start()
    {
        // Load and apply augments
        foreach (Augment augment in allAugments)
        {
            if (PlayerPrefs.GetInt(augment.name, 0) == 1)
            {
                augment.isBought = true;
                augment.ApplyEffect();
            }
        }
    }

    // Function to clear augment PlayerPrefs data
    public void ClearAugmentData()
    {
        foreach (Augment augment in allAugments)
        {
            PlayerPrefs.DeleteKey(augment.name);  // Remove the specific augment data from PlayerPrefs
            augment.isBought = false;             // Reset the augment's bought status
        }
        PlayerPrefs.Save();  // Save the changes to PlayerPrefs
    }
}
