using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed = 5f;
    private float limitedSpeed;
    private bool isFacingRight = true;
    Rigidbody2D rb;
    float horizontal;
    float vertical;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        FlipCharacter();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        limitedSpeed = speed - 1;

        if (horizontal != 0 && vertical != 0)
            rb.velocity = new Vector2(horizontal * limitedSpeed, vertical * limitedSpeed);
        else
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void FlipCharacter()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}
