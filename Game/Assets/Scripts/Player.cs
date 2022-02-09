using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float rollCooldown;
    public float rollSpeed;
    private float speed;
    public float startSpeed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = startSpeed;
    }
   
    void Update()
    {
        playerMovement();
        mouseTracing();
        roll();
    }

    void playerMovement()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }    

    void mouseTracing()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        transform.up = direction;
    }

    void roll()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            Vector3 vector = new Vector3(moveInput.x, moveInput.y, 0);
            Debug.Log("Space");
            transform.position += vector.normalized * rollSpeed * Time.deltaTime;
        }
    }
}
