using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] float jumpPower = 6.5f;
    [SerializeField] Animator animator;
    [SerializeField] private int bossHP = 3;
    [SerializeField] public GameObject pauseButtons;
    [SerializeField] private GameObject shaderOnWin;

    bool isGrounded = false;
    float horizontalInput;
    bool doubleJump = true;
    Rigidbody2D rb;
    private Time timeScale;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Time.timeScale = 1;
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


        if (Input.GetKeyDown(KeyCode.P))
        {
            if(Time.timeScale == 1)
            {
                PauseGame();
            }

            else if(Time.timeScale == 0)
            {
                StartGame();
            }
                
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

        else if(collision.gameObject.tag == "Boss")
        {

            bossHP--;
            if (bossHP > 0)
            {
                SoundEffectManager.Play("Hazard");
                Debug.Log("Boss Hurt! HP Left: " +  bossHP);
            }
            else
            {
                Debug.Log("You Beat the Boss!");
                Destroy(collision.gameObject);
                shaderOnWin.SetActive(true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        Debug.Log("isGrounded: " + isGrounded);
            
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseButtons.SetActive(true);
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        pauseButtons.SetActive(false);
    }


}
