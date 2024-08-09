using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public Bullet bulletPrefab;
    public int rateOfFire = 5;
    private ObjectPool bulletPool;

    private void Awake()
    {
        bulletPool = ObjectPool.CreateInstance(bulletPrefab, 100); 
    }

    private void Start()
    {
        StartCoroutine(fire());
    }

    private IEnumerator fire()
    {
        WaitForSeconds Wait = new WaitForSeconds(1f / rateOfFire);

        while (true)
        {
            PoolableObject instance = bulletPool.GetObject();

            if (instance != null)
            {
                instance.transform.SetParent(transform, false);
                instance.transform.localPosition = Vector3.zero;
            }
            yield return Wait;
        }
    }
}
