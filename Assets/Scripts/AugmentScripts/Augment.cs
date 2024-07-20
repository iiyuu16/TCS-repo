using UnityEngine;

[System.Serializable]
public class Augment : MonoBehaviour
{
    public new string name;  // Use 'new' keyword to hide inherited member
    public bool isBought;

    public virtual void ApplyEffect()
    {
        // Default behavior (if any) for applying the effect
    }
}
