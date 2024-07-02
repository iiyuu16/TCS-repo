using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vnSceneController : MonoBehaviour
{
    public void Play()
    {
        Debug.Log("Play");
        StartCoroutine(DelayedLoadScene());
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void toMainMenu()
    {
        SceneManager.GetSceneByName("MainMenu");
    }

    public void toVisNov()
    {
        SceneManager.GetSceneByName("VisNov");
    }


    //misc
    IEnumerator DelayedLoadScene()
    {
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
