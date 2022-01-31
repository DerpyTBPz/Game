using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rd;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalazed * speed;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * TIme.fixedDeltaTime);
    }
}