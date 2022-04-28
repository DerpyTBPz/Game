using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    public float startLifetime;
    private float lifetime;
    public float distance;    
    public LayerMask whatIsSolid;
    
    void Start()
    {
        lifetime = startLifetime;        
    }

    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        
        bulletHit(hitInfo);

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

    void bulletHit(RaycastHit2D hitInfo)
    {
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("hit");
                hitInfo.collider.GetComponent<Enemy>().takeDamage(damage);
                Destroy(gameObject);
            }
            if (hitInfo.collider.CompareTag("Wall"))
            {
                Debug.Log("Wall HIt");
                Destroy(gameObject);
            }
        }
    }

}

