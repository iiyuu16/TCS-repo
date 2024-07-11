using System.Collections;
using UnityEngine;

public class delayGameObj : MonoBehaviour
{
    public GameObject objToBeDelayed;
    public float delayTime;

    private void Start()
    {
        StartCoroutine(startDelaying());
    }


    IEnumerator startDelaying()
    {
        yield return new WaitForSeconds(delayTime);
        objToBeDelayed.SetActive(true);
    }

}
