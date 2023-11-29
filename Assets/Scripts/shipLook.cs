using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipLook : MonoBehaviour
{
    public Transform ship;
    public float speed = 1.0f;
    public float turnSpeed = 0.1f;
    public Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if ( Input.GetKey(KeyCode.Comma) ){
            ship.transform.eulerAngles = new Vector3(
            ship.transform.eulerAngles.x,
            ship.transform.eulerAngles.y ,
            ship.transform.eulerAngles.z + turnSpeed
        );
        }
        if ( Input.GetKey(KeyCode.Period) ){
            ship.transform.eulerAngles = new Vector3(
            ship.transform.eulerAngles.x,
            ship.transform.eulerAngles.y ,
            ship.transform.eulerAngles.z - turnSpeed);
        }
        //move left
        
    }
}
