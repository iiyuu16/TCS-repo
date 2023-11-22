using System.Collections;
using TMPro;
using UnityEngine;

public class GlitchText : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private Material originalMaterial;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        originalMaterial = textMesh.fontSharedMaterial;
        StartCoroutine(GlitchEffect());
    }

    IEnumerator GlitchEffect()
    {
        while (true)
        {
            // Introduce glitches by modifying text properties randomly
            textMesh.fontMaterial.SetFloat(ShaderUtilities.ID_GlowPower, Random.Range(0.0f, 1.0f));
            textMesh.fontMaterial.SetFloat(ShaderUtilities.ID_OutlineWidth, Random.Range(0.0f, 0.1f));

            // Apply a random italic effect with reduced frequency
            if (Random.value < 0.2f) // Adjust the value to control the frequency (e.g., 0.2 means 20% chance)
            {
                float italicFactor = Random.Range(-0.2f, 0.2f);
                textMesh.fontStyle = FontStyles.Italic;
                textMesh.fontSharedMaterial.SetFloat(ShaderUtilities.ID_ScaleX, 1 + italicFactor);

                // Wait for a short duration
                yield return new WaitForSeconds(Random.Range(0.1f, 0.5f));

                // Reset the italic effect
                textMesh.fontStyle = FontStyles.Normal;
                textMesh.fontSharedMaterial.SetFloat(ShaderUtilities.ID_ScaleX, 1f);
            }

            // Wait for a short duration before the next glitch
            yield return new WaitForSeconds(Random.Range(0.5f, 1.5f));
        }
    }
}
