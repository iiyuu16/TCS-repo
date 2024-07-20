using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsuranceAugment : Augment
{
    public float activationChance = 0.6f;

    public override void ApplyEffect()
    {
        Debug.Log("Applying Insurance Augment with " + (activationChance * 100) + "% chance");
        // Implement the logic to prevent punishments and declare the player winner
    }
}
