using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speedMultiplyer = 1f;
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
    public float dashSpeed = 10f;
    public float dashDuration = 0.5f;
    public float dashCooldown = 1f;
    public bool canDash = true;
    private Vector2 preDashVelocity; // Store the player's velocity before the dash



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (groundCheck == null)
        {
            Debug.LogError("GroundCheck not assigned to the player controller!");
        }

    }
     //SpeedBoost
   public void StartSpeedBoost(float multiplyer, float speedBoostTime)
    {
        speedMultiplyer = multiplyer;
        StartCoroutine(SpeedBoostCoroutine(multiplyer, speedBoostTime));

    }

    private IEnumerator SpeedBoostCoroutine(float multiplyer, float speedBoostTime) //Speedboost
    {
        yield return new WaitForSeconds(speedBoostTime);
        speedMultiplyer = 1f;
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
        if (canDash && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
            //Debug.Log("Shift key pressed, starting dash...");
        }


    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed * speedMultiplyer, rb.velocity.y);

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

    IEnumerator Dash()
    {
        canDash = false;

        // Store the player's velocity before the dash
        Vector2 preDashVelocity = rb.velocity;

        // Calculate dash direction based on player's current velocity
        Vector2 dashDir = rb.velocity.normalized;

        // Calculate displacement for the dash
        Vector2 displacement = dashDir * dashSpeed * dashDuration;

        float startTime = Time.time;
        while (Time.time < startTime + dashDuration)
        {
            // Apply displacement to the player's position over time
            transform.Translate(displacement * Time.deltaTime / dashDuration, Space.World);

            // Maintain player's velocity to preserve momentum
            rb.velocity = preDashVelocity;

            yield return null;
        }

        // Cooldown before next dash is allowed
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}