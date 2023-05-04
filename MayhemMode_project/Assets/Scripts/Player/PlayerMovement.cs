using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float speed;
    private float limitedSpeed;
    private bool isFacingRight = true;
    float horizontal;
    float vertical;
    Rigidbody2D rb;
    Animator anim;
    Quaternion localRotation;
    Character character;
    public Vector2 moveDir;
    AnimationController animator;

    
    void Awake()
    {
        character = GetComponent<Character>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        localRotation = transform.localRotation;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        moveDir = new Vector2(horizontal, vertical);

        AnimateCharacter();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {  
        speed = character.speed;
        limitedSpeed = speed - 1;

        if (horizontal != 0 && vertical != 0)
            rb.velocity = new Vector2(horizontal * limitedSpeed, vertical * limitedSpeed);
        else
            rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    private void AnimateCharacter()
    {
        if (isFacingRight)
            localRotation.y = 180;
        else
            localRotation.y = 0;


        if (horizontal < 0f) 
        {
            anim.SetBool("isWalkingRight", false);
            anim.SetBool("isWalkingLeft", true);
            isFacingRight = false;
        }
        else if (horizontal > 0f)
        {
            anim.SetBool("isWalkingLeft", false);
            anim.SetBool("isWalkingRight", true);
            isFacingRight = true;
        }
        else 
        {
            bool lastFacedDirection = isFacingRight;
            anim.SetBool("isWalkingLeft", false);
            anim.SetBool("isWalkingRight", false);
        }

        transform.localRotation = localRotation;
    }
}
