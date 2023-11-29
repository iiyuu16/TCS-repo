using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Bullet bulletPrefab;
    public int rateOfFire = 5;
    public Vector3 bulletSpawnOffset = new Vector3(0, 1, 0);
    public LayerMask mask;
    private ObjectPool bulletPool;
    public float attackDelay = 0.5f;
    [SerializeField]


/*    private void Awake(){
        bulletPool = ObjectPool.CreateInstance(bulletPrefab, Mathf.CeilToInt((1/attackDelay) * bulletPrefab.autoDestroyTime));
    }*/

    

    public void Update(){
        if(Input.GetKey(KeyCode.Space)){
            WaitForSeconds Wait = new WaitForSeconds(1f / rateOfFire);

        if(Input.GetKey(KeyCode.Space)){
            PoolableObject instance = bulletPool.GetObject();

            if(instance != null){
                instance.transform.SetParent(transform, false);
                instance.transform.localPosition = Vector3.zero;
            }
        }
        }
        
    }


}
