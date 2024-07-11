using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vnSceneController : MonoBehaviour
{
    private ParticleTransition particleTransition;
    public float delayTimeToPlay;
    public float delayTimeToTransition;

    public GameObject objTransition;

    private void Awake()
    {
        particleTransition = FindObjectOfType<ParticleTransition>();
        if (particleTransition == null)
        {
            Debug.Log("No ParticleTransition found in the scene.");
        }
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "LoadingScreen")
        {
            toVisNov_FLM();
        }
    }

    public void Play()
    {
        Debug.Log("Play");
        if (particleTransition != null)
        {
            particleTransition.TriggerTransition();
        }
        StartCoroutine(DelayedSceneTransition());
        StartCoroutine(DelayedObjTransition());
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void toVisNovPrologue()
    {
        SceneManager.LoadScene("VisNovV2_Prologue");
    }

    public void toLoadingScene()
    {
        StartCoroutine(DelayToLoadingScene());
        StartCoroutine(DelayedObjTransition());
    }

    public void toVisNov_FLM()
    {
        StartCoroutine(DelayToFLM());
        StartCoroutine(DelayedObjTransition());
    }

    IEnumerator DelayToLoadingScene()
    {
        yield return new WaitForSeconds(delayTimeToPlay);
        SceneManager.LoadScene("LoadingScreen");
    }

    IEnumerator DelayToFLM()
    {
        yield return new WaitForSeconds(delayTimeToPlay);
        SceneManager.LoadScene("VisNov_FLM");
    }

    IEnumerator DelayedSceneTransition()
    {
        yield return new WaitForSeconds(delayTimeToPlay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator DelayedObjTransition()
    {
        yield return new WaitForSeconds(delayTimeToTransition);
        objTransition.SetActive(true);
    }
}
