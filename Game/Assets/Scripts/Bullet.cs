using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float startLifetime;
    private float lifetime;
    public float distance;

    void Start()
    {
        lifetime = startLifetime;
    }

    void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
        destroyBullet();
    }

    void destroyBullet()
    {
        if (lifetime <= 0)
        {
            Destroy(gameObject);            
        }
        else
        {
            lifetime -= Time.deltaTime;
        }
    }

}

