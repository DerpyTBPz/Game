using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float startDashCooldown;
    public float dashCooldown;    
    public float dashSpeed;

    private float speed;
    public float startSpeed;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = startSpeed;
        dashCooldown = startDashCooldown;
    }
   
    void Update()
    {
        playerMovement();
        mouseTracing();
        dash();
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

    void dash()
    {       
        if (dashCooldown <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {            
                Vector3 vector = new Vector3(moveInput.x, moveInput.y, 0);                
                transform.position += vector.normalized * dashSpeed * Time.deltaTime;
                Debug.Log("Dash");
                dashCooldown = startDashCooldown;
            }            
        }
        else 
        {
            dashCooldown -= Time.deltaTime;
        }
    }


}
