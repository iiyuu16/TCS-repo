using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHP : MonoBehaviour
{
    public BoxCollider collide;
    public int HP = 10;

    private int playerHealth = 10;
    // Start is called before the first frame update
    void Start()
    {
        collide = this.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            HP--;
            if (HP < 1)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
