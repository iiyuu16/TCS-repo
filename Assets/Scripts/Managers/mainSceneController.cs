using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainSceneController : MonoBehaviour
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
        SceneManager.LoadScene("VisNov_Prologue");
    }

    public void toVisNovMain()
    {
        StartCoroutine(DelayToLoadingScene());
        StartCoroutine(DelayToVNMain());
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

    public void toVisNov_FLM_gamemode()
    {
        StartCoroutine(DelayToFLM_gamemode());
        StartCoroutine(DelayedObjTransition());
    }

    IEnumerator DelayToVNMain()
    {
        yield return new WaitForSeconds(delayTimeToPlay);
        SceneManager.LoadScene("VisNov_Main");
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

    IEnumerator DelayToFLM_gamemode()
    {
        yield return new WaitForSeconds(delayTimeToPlay);
        SceneManager.LoadScene("s&dGM");
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
