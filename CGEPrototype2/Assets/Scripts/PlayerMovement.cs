using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float jetpackForce = 20f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public TrailRenderer jetpackParticles; // Reference to the jetpack particle system
    private Rigidbody2D rb;
    private bool isGrounded;
    private float horizontalInput;
    private bool isJetpackActive; // Flag to track if jetpack is currently active

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButton("Jump") && !isGrounded)
        {
            rb.AddForce(Vector2.up * jetpackForce, ForceMode2D.Force);
            //ActivateJetpackParticles(true); // Activate jetpack particles only once
            isJetpackActive = true;
        }
        else if (isJetpackActive)
        {
            //ActivateJetpackParticles(false); // Deactivate jetpack particles only once
            isJetpackActive = false;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }
}