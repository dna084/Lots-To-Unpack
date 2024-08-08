using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpPower = 6.5f;
    [SerializeField] Animator animator;

    bool isGrounded = false;
    float horizontalInput;
    bool doubleJump = true;
    Rigidbody2D rb;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump"))
        {

            if (isGrounded)
            {
                SoundEffectManager.Play("Jumps");
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                animator.SetBool("isJumping", isGrounded);
            }

            if (doubleJump && (isGrounded == false))
            {
                SoundEffectManager.Play("Jumps");
                rb.velocity = new Vector2(rb.velocity.x, jumpPower);
                animator.SetBool("isJumping", isGrounded);
                doubleJump = false;
            }

        } 


        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        if (rb.velocity.x < 0 && isGrounded)
        {
            animator.SetFloat("xVelocity", rb.velocity.x);
        }

        if(rb.velocity.x > 0 && isGrounded)
        {
            animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        }

        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            doubleJump = true;
            animator.SetBool("isJumping", !isGrounded );
            Debug.Log("isGrounded: " + isGrounded);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        Debug.Log("isGrounded: " + isGrounded);
            
    }


}
