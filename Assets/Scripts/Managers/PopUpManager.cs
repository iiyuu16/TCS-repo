using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class PopUpManager : MonoBehaviour
{
    public GameObject[] popUpPrefabs;
    public GameObject canvas;
    public float spawnInterval = 12f;
    public int numPopUpsToShow = 3;
    private List<GameObject> activePopUps = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnPopUps());
    }

    IEnumerator SpawnPopUps()
    {
        while (true)
        {
            if (activePopUps.Count < 12)
            {
                for (int i = 0; i < numPopUpsToShow; i++)
                {
                    GameObject popUp = Instantiate(popUpPrefabs[Random.Range(0, popUpPrefabs.Length)]);
                    popUp.transform.SetParent(canvas.transform, false);

                    float randomX = Random.Range(-200f, 200f);
                    float randomY = Random.Range(-100f, 100f);
                    popUp.transform.localPosition = new Vector3(randomX, randomY, 0f);

                    activePopUps.Add(popUp);
                }
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public void ClosePopUp(GameObject popUp)
    {
        activePopUps.Remove(popUp);
        Destroy(popUp);
    }
}