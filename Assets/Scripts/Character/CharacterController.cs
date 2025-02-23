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
    [SerializeField] float MaxInvulnerableTime = 1.0f;

    [Header("Hacks")]
    [SerializeField] float TeleportDashSpeed = 15.0f;
    [SerializeField] float TeleportDuration = 0.1f;
    public LayerMask groundLayer;

    private CharacterLoopManager LoopMan;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Transform groundCheck;
    private float originalGravityScale;

    private bool IsPlaying = false;
    private bool IsInvulnerable = false;
    private bool IsDashing = false;
    private float InvulnTimer = 0.0f;

    private List<TrapType> UnlockedHacks = new List<TrapType>();

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
        if (IsInvulnerable)
        {
            InvulnTimer += Time.deltaTime;
            if (InvulnTimer > MaxInvulnerableTime)
            {
                IsInvulnerable = false;
                InvulnTimer = 0.0f;
                //end invuln anim
            }
        }

        if ( !IsPlaying)
        {
            return;
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        MyAnimator.SetBool("IsJumping", !isGrounded);

        if (!IsDashing)
        {
            float moveX = Input.GetAxis("Horizontal");

            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);

            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                MyAnimator.SetBool("IsJumping", true);
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
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
        if (IsInvulnerable) return; //This may be problematic
        IsPlaying = false;
        rb.velocity = Vector3.zero; // Stop moving

        MyAnimator.SetBool("IsDead", true);
        StartCoroutine(CompleteDeath());
    }

    public void CharacterWon()
    {
        LoopMan.CharacterWon();
    }

    public void OnDeathComplete()
    {
        LoopMan.PlayerWon();
    }

    IEnumerator CompleteDeath()
    {
        yield return new WaitForSeconds(0.28f);

        OnDeathComplete();
    }

    public void OnTrapTriggerEnter(TrapType type)
    {
        if (!UnlockedHacks.Contains(type)) return;
        switch (type)
        {
            case TrapType.kSpike:
                {
                    //Invuln
                    IsInvulnerable = true;
                    //invuln animation?
                    break;
                }
            case TrapType.kFallingSpike:
                {
                    //Teleport forward
                    StartCoroutine(Dash());

                    break;
                }
        }
    }

    public void UnlockHack(TrapType type)
    {
        UnlockedHacks.Add(type);
    }

    IEnumerator Dash()
    {
        IsDashing = true;
        float dir = 0.0f;
        if (rb.velocity.x > 0)
        {
            dir = 1f;
        }
        else if (rb.velocity.x < 0)
        {
            dir = -1f;
        }
        rb.velocity = new Vector2(dir * TeleportDashSpeed, rb.velocity.y);

        yield return new WaitForSeconds(TeleportDuration);
        IsDashing = false;
    }

    public void TestDash()
    {
        StartCoroutine(Dash());
    }
}