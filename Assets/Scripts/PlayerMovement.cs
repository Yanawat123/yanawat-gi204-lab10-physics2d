using System;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    float move;

    public float JumpForce;
    public bool IsJumping;

    Rigidbody2D rb2d;

    Vector2 moveInput; //for walk addforce
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //walk with addforce
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2d.AddForce(moveInput * Speed);
        //walk left-right
        move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * Speed, rb2d.linearVelocity.y);

        //jump
        if (Input.GetButtonDown("Jump") && !IsJumping)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, JumpForce);

            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            IsJumping = true;
        }
    }
}