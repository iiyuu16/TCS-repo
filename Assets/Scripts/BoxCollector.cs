using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BoxCollector : MonoBehaviour
{

    public CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    public int collected = 0;
    public GameObject cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision){
            if(collision.gameObject.name == "ItemCube"){
                collected = 1;
                Debug.Log("COLLECTED, collected var: " + collected);

                vcam.m_Priority = 11;
                StartCoroutine(Wait());
                
                

            }

            
        }

        IEnumerator Wait(){
            Debug.Log("WE WAITED");
            yield return new WaitForSeconds(1.5f);
            GameObject.Find("CubeExit").SetActive(false);
            yield return new WaitForSeconds(1.5f);
            vcam.m_Priority = 9;
        }
}
