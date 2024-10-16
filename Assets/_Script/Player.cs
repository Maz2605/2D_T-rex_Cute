using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animation anim;

    [SerializeField]
    private float jumpForce = 10f;
    
    private float groundCheckRadius = 0.5f;
    private Transform groundCheck;
    [SerializeField]
    private LayerMask ground;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animation>();
    }

    private void Update()
    {
        CheckIfCanJump();
    }
    private void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity =new Vector2(rb.velocity.x, jumpForce);
            Debug.Log("Jump");
        }
    }
    private void CheckIfCanJump()
    {
        if (CheckGrounded())
        {
            Jump();
        }
    }

    private bool CheckGrounded() => Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, ground); 
}
