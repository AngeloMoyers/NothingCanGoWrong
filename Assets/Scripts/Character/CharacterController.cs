using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Animator MyAnimator;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float fallMultiplier = 2.5f;
    [SerializeField] float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private CharacterLoopManager LoopMan;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Transform groundCheck;
    private float originalGravityScale;

    private bool IsPlaying = false;

    public void SetPlaying(bool newPlaying ) { IsPlaying = newPlaying; }

    private void Awake()
    {
        LoopMan = GameObject.FindObjectOfType<CharacterLoopManager>();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = transform.Find("GroundCheck");

        originalGravityScale = rb.gravityScale;
    }

    void Update()
    {
        if ( !IsPlaying)
        {
            return;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        MyAnimator.SetBool("IsJumping", !isGrounded);

        float moveX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            MyAnimator.SetBool("IsJumping", true);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier * originalGravityScale;
        }
        else
        {
            rb.gravityScale = originalGravityScale;
        }

        MyAnimator.SetFloat("Speed",Mathf.Abs( rb.velocity.x));
    }

    public void Die()
    {
        //Do some fancy anim?
        LoopMan.Reset();
    }
}
