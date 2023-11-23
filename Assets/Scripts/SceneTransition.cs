using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1.0f;

    private void Start()
    {
        // Start the transition when the scene begins
        StartCoroutine(TransitionRoutine());
    }

    IEnumerator TransitionRoutine()
    {
        // Set alpha to 1 at the beginning for fade-out effect
        fadeImage.color = new Color(0f, 0f, 0f, 1f);

        // Fade out
        yield return StartCoroutine(Fade(0f, fadeDuration));

        // Load the next scene (replace "YourNextSceneName" with the actual scene name)
        SceneManager.LoadScene("test");
    }

    IEnumerator Fade(float targetAlpha, float duration)
    {
        Color startColor = fadeImage.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);

        float startTime = Time.time;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            fadeImage.color = Color.Lerp(startColor, targetColor, elapsed / duration);
            elapsed = Time.time - startTime;
            yield return null;
        }

        fadeImage.color = targetColor;
    }
}
