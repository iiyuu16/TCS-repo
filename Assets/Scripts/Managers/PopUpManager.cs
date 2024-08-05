using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject[] popUpPrefabs;
    [SerializeField] private GameObject canvas;
    [SerializeField] private float spawnInterval = 12f;
    [SerializeField] private int numPopUpsToShow = 3;
    [SerializeField] private int maxPopUpCount = 12;
    [SerializeField] private List<GameObject> activePopUps = new List<GameObject>();

    [SerializeField] public bool isDebuffTriggered = false;

    public static PopUpManager instance;

    private float spawnCooldown = 0f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Update()
    {
        if (isDebuffTriggered && spawnCooldown <= 0f)
        {
            StartCoroutine(SpawnPopUps());
            spawnCooldown = spawnInterval;
        }

        spawnCooldown -= Time.deltaTime;
    }

    public void OnThisManager()
    {
        isDebuffTriggered = true;
    }

    public void OffThisManager()
    {
        isDebuffTriggered = false;
    }

    IEnumerator SpawnPopUps()
    {
        while (true)
        {
            if (activePopUps.Count < maxPopUpCount)
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
            activePopUps.RemoveAll(popUp => popUp == null);

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}