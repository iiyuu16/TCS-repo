using System.Collections;
using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        StartCoroutine(BlinkingEffect());
    }

    IEnumerator BlinkingEffect()
    {
        while (true)
        {
            // Toggle the visibility of the text
            textMesh.enabled = !textMesh.enabled;

            // Wait for a short duration
            yield return new WaitForSeconds(1.0f); // Adjust the duration based on your preference
        }
    }
}
