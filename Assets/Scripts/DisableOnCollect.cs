using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnCollect : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ship;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ship.GetComponent<BoxCollector>().collected == 1){
            Debug.Log("delete me");
            this.gameObject.SetActive(false);
        }
    }


}
