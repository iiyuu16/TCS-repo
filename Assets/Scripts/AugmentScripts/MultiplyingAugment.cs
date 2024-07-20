using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyingAugment : Augment
{
    public float dropRateMultiplier;

    public override void ApplyEffect()
    {
        Debug.Log("Applying Multiplying Augment with drop rate multiplier: " + dropRateMultiplier);
        // Implement the logic to increase drop rates
    }
}
