using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 1f;
    public float speed = 1f;
    public int damage = 1;

    private Vector3 spawnPoint;
    private float timer = 0f;

    void Start()
    {
        spawnPoint = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (timer > bulletLife) Destroy(gameObject);
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector3 Movement(float timer)
    {
        float x = timer * speed * transform.right.x;
        float y = timer * speed * transform.right.y;
        float z = timer * speed * transform.right.z;
        return new Vector2(x + spawnPoint.x, y + spawnPoint.y);
    }
}
