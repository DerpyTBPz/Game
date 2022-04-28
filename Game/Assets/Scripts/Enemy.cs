using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    public int health;
    public float speed;
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }
    
    public void takeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Hit");
    }

    public void enemyMove()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Dead");            
        }
        enemyMove();
    }
}
